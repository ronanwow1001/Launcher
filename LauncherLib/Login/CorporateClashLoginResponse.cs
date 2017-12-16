using Newtonsoft.Json;

namespace LauncherLib.Login
{
    /// <summary>
    ///     Represents a login server response for Corporate Clash
    /// </summary>
    public class CorporateClashLoginResponse : ILoginAPIResponse
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CorporateClashLoginResponse"/> class.
        /// </summary>
        /// <param name="status">The login status</param>
        /// <param name="reason">The login reason</param>
        /// <param name="token">The login token</param>
        public CorporateClashLoginResponse(bool status, string reason, string token)
        {
            Status = status;
            Reason = reason;
            Token = token;
        }

        /// <inheritdoc />
        [JsonProperty("status")]
        public bool Status { get; }

        /// <summary>
        ///     The friendly reason
        /// </summary>
        [JsonProperty("friendlyreason")]
        public string Reason { get; }

        /// <summary>
        ///     The login token
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; }
    }
}
