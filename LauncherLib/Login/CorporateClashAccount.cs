using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LauncherLib.Net;

namespace LauncherLib.Login
{
    public class CorporateClashAccount : IAccount
    {
        public CorporateClashAccount(string username, string password)
        {
            Username = username;
            Password = password;

            Config = new LoginConfig(new Uri($"https://corporateclash.net/api/v1/login/{Username}"),
            new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { PassParameter, Password }
            }));
        }

        public string Username { get; }
        public string Password { get; }
        private const string PassParameter = "p";

        internal LoginConfig Config;

        public async Task<ILoginAPIResponse> Login() => await Http.GetLoginAPIResponse<CorporateClashLoginResponse>(this, Config);
    }
}
