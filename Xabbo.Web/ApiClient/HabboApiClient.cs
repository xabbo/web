﻿using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using Xabbo.Web.Serialization;

namespace Xabbo.Web;

/// <summary>
/// A client for the Habbo web API.
/// </summary>
public sealed partial class HabboApiClient : IDisposable
{
    private readonly JsonSerializerOptions _jsonOptions;

    private bool _disposed;

    public HttpClient HttpClient { get; }

    public HabboApiClient(string baseAddress = "https://www.habbo.com/")
    {
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = {
                new DateTimeConverter(),
                new HabboUniqueUserIdConverter()
            }
        };

        HttpClient = new()
        {
            BaseAddress = new Uri(baseAddress),
            DefaultRequestHeaders =
            {
                { "User-Agent", "Xabbo.Web" }
            }
        };
    }

    private async Task<UserInfo> GetUserInfoAsync(Uri requestUri, HabboUniqueUserId? uniqueId, string? name, bool checkBanned, CancellationToken cancellationToken)
    {
        var res = await HttpClient.GetAsync(requestUri);
        if (res.StatusCode == HttpStatusCode.NotFound)
        {
            if (checkBanned && !string.IsNullOrWhiteSpace(name))
            {
                res = await HttpClient.SendAsync(
                    new HttpRequestMessage
                    {
                        Method = HttpMethod.Head,
                        RequestUri = new Uri($"/habbo-imaging/avatarimage?user={WebUtility.UrlEncode(name)}")
                    },
                    cancellationToken
                );
                if (res.IsSuccessStatusCode)
                    throw new UserBannedException(name);
            }
            throw new UserNotFoundException(uniqueId, name);
        }

        res.EnsureSuccessStatusCode();
        return (await res.Content.ReadFromJsonAsync<UserInfo>(_jsonOptions, cancellationToken))!;
    }

    /// <summary>
    /// Gets the info a user by their name.
    /// </summary>
    /// <param name="name">The user's name.</param>
    /// <param name="checkBanned">
    /// Whether to check if the user is banned or not.
    /// If the user's information is not found, an additional API request will be made to check if the user's avatar image exists.
    /// If it does exist, it means the user's information has been removed from the public API, indicating that they are banned.
    /// If a ban is detected, a <see cref="UserBannedException"/> will be thrown.
    /// </param>
    /// <param name="cancellationToken">A token used to cancel the request.</param>
    /// <returns>The user's information</returns>
    /// <exception cref="UserNotFoundException">If the user was not found.</exception>
    public Task<UserInfo> GetUserInfoAsync(string name, bool checkBanned = true, CancellationToken cancellationToken = default)
        => GetUserInfoAsync(new Uri($"/api/public/users?name={WebUtility.UrlEncode(name)}"), null, name, checkBanned, cancellationToken);

    /// <summary>
    /// Gets the info a user by their unique ID.
    /// </summary>
    /// <param name="uniqueId">The user's unique ID.</param>
    /// <param name="cancellationToken">A token used to cancel the request.</param>
    /// <returns>The user's information.</returns>
    /// <exception cref="UserNotFoundException">
    /// If the user was not found. May also be thrown if the user is banned.
    /// It is not possible to detect whether a user is banned without their name.
    /// </exception>
    public Task<UserInfo> GetUserInfoAsync(HabboUniqueUserId uniqueId, CancellationToken cancellationToken = default)
        => GetUserInfoAsync(new Uri($"/api/public/users/{uniqueId}"), uniqueId, null, false, cancellationToken);

    /// <summary>
    /// Gets the profile of a user by their name.       
    /// </summary>
    /// <param name="name">The user's name.</param>
    /// <param name="checkBanned">
    /// Whether to check if the user is banned.
    /// If the user's information is not found, an additional API request will be made to check if the user's avatar image exists.
    /// If it does exist, it means that the user's information has been removed from the public API, indicating that they are banned.
    /// If a ban is detected, a <see cref="UserBannedException"/> will be thrown.
    /// </param>
    /// <param name="cancellationToken">A token used to cancel the request.</param>
    /// <returns>The user's profile.</returns>
    /// <exception cref="UserNotFoundException">If the user was not found.</exception>
    /// <exception cref="ProfileNotVisibleException">If the user's profile is not visible.</exception>
    /// <exception cref="UserBannedException">If the user is detected to be banned.</exception>
    public async Task<UserProfile> GetUserProfileAsync(string name, bool checkBanned = true, CancellationToken cancellationToken = default)
    {
        var userInfo = await GetUserInfoAsync(name, checkBanned, cancellationToken);
        if (!userInfo.IsProfileVisible)
            throw new ProfileNotVisibleException(name, userInfo);
        return await GetUserProfileAsync(userInfo.UniqueId, false, cancellationToken);
    }

    /// <summary>
    /// Gets the profile of a user by their unique ID.
    /// </summary>
    /// <param name="uniqueId">The user's unique ID.</param>
    /// <param name="checkNotVisible">
    /// Whether to check if the user's profile is not visible.
    /// If the user's profile is not found, an additional API request
    /// will be made to check if the user's information can be found,
    /// indicating that the user's profile is not visible.
    /// </param>
    /// <param name="cancellationToken">A token used to cancel the request.</param>
    /// <returns>The user's profile.</returns>
    /// <exception cref="UserNotFoundException">
    /// If the user was not found. May also be thrown if the user is banned.
    /// It is not possible to detect whether a user is banned without their name.
    /// </exception>
    /// <exception cref="ProfileNotVisibleException">If the user's profile is not visible.</exception>
    public async Task<UserProfile> GetUserProfileAsync(HabboUniqueUserId uniqueId, bool checkNotVisible = true, CancellationToken cancellationToken = default)
    {
        var res = await HttpClient.GetAsync($"/api/public/users/{uniqueId}/profile", cancellationToken);
        if (res.StatusCode == HttpStatusCode.NotFound)
        {
            if (checkNotVisible)
            {
                var userInfo = await GetUserInfoAsync(uniqueId, cancellationToken);
                throw new ProfileNotVisibleException(userInfo.Name, userInfo);
            }
            throw new UserNotFoundException(uniqueId, null);
        }

        res.EnsureSuccessStatusCode();
        return (await res.Content.ReadFromJsonAsync<UserProfile>(_jsonOptions, cancellationToken))!;
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        _disposed = true;

        if (disposing)
        {
            HttpClient.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}