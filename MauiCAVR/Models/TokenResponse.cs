using Newtonsoft.Json;
using SQLite;

namespace MauiCAVR.Models;

public class TokenResponse
{
    #region Properties

    [PrimaryKey, AutoIncrement]
    public int TokenResponseId { get; set; }

    [JsonProperty(PropertyName = "access_token")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "token_type")]
    public string TokenType { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty(PropertyName = "userName")]
    public string UserName { get; set; } = string.Empty;

    [JsonProperty(PropertyName = ".issued")]
    public DateTime Issued { get; set; }

    [JsonProperty(PropertyName = ".expires")]
    public DateTime Expires { get; set; }

    [JsonProperty(PropertyName = "error_description")]
    public string ErrorDescription { get; set; } = string.Empty;

    public bool IsRemembered
    {
        get;
        set;
    }
    #endregion
    #region Methods


    public override int GetHashCode()
    {
        return TokenResponseId;
    }
    #endregion
}
