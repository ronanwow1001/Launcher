using Newtonsoft.Json;

namespace LauncherLib.Login
{
    /// <summary>
    ///     Represents a login server response
    /// </summary>
    public class LoginAPIResponse : ILoginAPIResponse
    {
        /// <summary>
        ///     A constant response for a "Good" login
        /// </summary>
        [JsonIgnore]
        public const bool Good = true;

        /// <summary>
        ///     A constant response for a "Bad" login
        /// </summary>
        [JsonIgnore]
        public const bool Bad = false;

        /// <summary>
        ///     An empty response
        /// </summary>
        [JsonIgnore]
        public static readonly LoginAPIResponse Empty = new LoginAPIResponse(false, "Empty", "Empty");
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="LoginAPIResponse"/> class.
        /// </summary>
        /// <param name="status">The response status</param>
        /// <param name="friendlyReason">The response reason</param>
        /// <param name="token">The response token</param>
        public LoginAPIResponse(bool status, string reason, string token)
        {
            Status = status;
            Reason = reason;
            Token = token;
        }

        /// <summary>
        ///     The login status
        /// </summary>
        [JsonProperty("status")]
        public bool Status { get; }

        /// <summary>
        ///     The reason
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <summary>
        ///     The login token
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; }

    }
}
