namespace LauncherLib.Login
{
    public interface ILoginAPIResponse
    {
        /// <summary>
        ///     The login status
        /// </summary>
        bool Status { get; }

        /// <summary>
        ///     The reason
        /// </summary>
        string Reason { get; }

        /// <summary>
        ///     The login token
        /// </summary>
        string Token { get; }
    }
}