using System;
using System.Net.Http;

namespace LauncherLib.Login
{
    /// <summary>
    ///     A login configuration specifying how to send a webrequest
    /// </summary>
    public class LoginConfig
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LoginConfig"/> class.
        /// </summary>
        /// <param name="loginAPI">The login api that web requests will be sent to</param>
        /// <param name="postData">The post data. Includes username and or password</param>
        /// <param name="shouldPost"></param>
        public LoginConfig(Uri loginAPI, FormUrlEncodedContent postData, bool shouldPost = true)
        {
            if (shouldPost && postData == null)
            {
                throw new ArgumentNullException(nameof(postData));
            }

            PostData = postData;
            LoginAPI = loginAPI ?? throw new ArgumentNullException(nameof(loginAPI));
            ShouldPost = shouldPost;
        }
        
        internal FormUrlEncodedContent PostData;

        /// <summary>
        ///     The login api that web requests will be sent to
        /// </summary>
        internal Uri LoginAPI { get; }

        /// <summary>
        ///     Determines whether a POST request should be sent
        ///     instead of a GET request.
        ///     True if POST
        ///     False if GET
        /// </summary>
        internal bool ShouldPost { get; }
    }
}
