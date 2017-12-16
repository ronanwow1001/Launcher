using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LauncherLib.Login;
using LauncherLib.Update;
using Newtonsoft.Json;

namespace LauncherLib.Net
{
    internal static class Http
    {
        /// <summary>
        ///     The HttpClient used for networking
        /// </summary>
        private static readonly HttpClient Client = new HttpClient();

        /// <summary>
        ///     Contacts the login api server and gets a login response
        /// </summary>
        /// <param name="account">The account credentials</param>
        /// <param name="config">The login configuration</param>
        /// <returns>An instance of <typeparam name="T"></typeparam> with deserialized values if successful, otherwise a default instance.</returns>
        internal static async Task<T> GetLoginAPIResponse<T>(IAccount account, LoginConfig config)
        {
            try
            {
                HttpResponseMessage message;
                if (config.ShouldPost)
                {
                    // Post to server
                    message = await Client.PostAsync(config.LoginAPI, config.PostData);
                }
                else
                {
                    // Send a get request
                    message = await Client.GetAsync(config.LoginAPI);
                }

                // Get response
                var responseString = await message.Content.ReadAsStringAsync();


                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        ///     Contacts the file api server gets the file manifest
        /// </summary>
        /// <returns>A <see cref="IFileManifestCollection"/> if successful, otherwise null</returns>
        internal static async Task<IFileManifestCollection> GetFileManifest(Uri fileApi)
        {
            try
            {
                // Get the raw manifest from the file api
                var rawManifest = await Client.GetStringAsync(fileApi);

                // Return the raw manifest as a collection
                return new FileManifestCollection(rawManifest);
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal static async Task<string> GetGameServer(Uri uri)
        {
            return await Client.GetStringAsync(uri);
        }
    }
}
