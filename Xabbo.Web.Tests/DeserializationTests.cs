using System.Text.Json;
using Xabbo.Web.Serialization;

namespace Xabbo.Web.Tests;

public class DeserializationTests
{
    public readonly JsonSerializerOptions SerializerOptions;

    public DeserializationTests()
    {
        SerializerOptions = new HabboApiClient().SerializerOptions;
    }


    [Fact(DisplayName = "Deserializes to BasicUserInfo when profileVisible property is not present")]
    public void DeserializeToBasicUserInfo()
    {
        string json = File.ReadAllText(@"Payloads\BasicUserInfo.json");
        var userInfo = JsonSerializer.Deserialize<UserInfoBase>(json, SerializerOptions);
        Assert.IsType<BasicUserInfo>(userInfo);
    }

    [Fact(DisplayName = "Deserializes to UserInfo when profileVisible is true")]
    public void DeserializeToUserInfo()
    {
        string json = File.ReadAllText(@"Payloads\UserInfo.json");
        var userInfo = JsonSerializer.Deserialize<UserInfoBase>(json, SerializerOptions);
        Assert.IsType<UserInfo>(userInfo);
    }

    [Fact(DisplayName = "Deserializes to ExtendedUserInfo when profileVisible is false")]
    public void DeserializeToExtendedUserInfo()
    {
        string json = File.ReadAllText(@"Payloads\ExtendedUserInfo.json");
        var userInfo = JsonSerializer.Deserialize<UserInfoBase>(json, SerializerOptions);
        Assert.IsType<ExtendedUserInfo>(userInfo);
    }
}