using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model.Apps;

namespace Mastodon.Api
{
    public class Apps
    {
        /// <summary>
        /// Read data
        /// </summary>
        public const string SCOPE_READ = "read";
        /// <summary>
        /// Post statuses and upload media for statuses
        /// </summary>
        public const string SCOPE_WRITE = "write";
        /// <summary>
        /// Follow, unfollow, block, unblock
        /// </summary>
        public const string SCOPE_FOLLOW = "follow";

        /// <summary>
        /// Mastodon instance domain
        /// </summary>
        public string Domain { get; }
        /// <summary>
        /// Name of your application
        /// </summary>
        public string ClientName { get; }
        /// <summary>
        /// Where the user should be redirected after authorization (for no redirect, use <see cref="Constants.NoRedirect"/>)
        /// </summary>
        public string RedirectUris { get; }
        /// <summary>
        /// This can be a space-separated list of the following items: <see cref="SCOPE_READ"/>, <see cref="SCOPE_WRITE"/> and <see cref="SCOPE_FOLLOW"/>
        /// </summary>
        public string[] Scopes { get; }
        /// <summary>
        /// (optional) URL to the homepage of your app
        /// </summary>
        public string Website { get; }


        /// <summary>
        /// Register and auth
        /// </summary>
        /// <param name="domain">Mastodon instance domain</param>
        /// <param name="clientName">Name of your application</param>
        /// <param name="website">(optional) URL to the homepage of your app</param>
        /// <param name="redirectUris">Where the user should be redirected after authorization (for no redirect, use <see cref="Constants.NoRedirect"/>)</param>
        /// <param name="scopes">This can be a space-separated list of the following items: <see cref="SCOPE_READ"/>, <see cref="SCOPE_WRITE"/> and <see cref="SCOPE_FOLLOW"/></param>
        public Apps(string domain, string clientName, string website = "",  string redirectUris = Constants.NoRedirect, params string[] scopes)
        {
            ClientName = clientName;
            RedirectUris = redirectUris;
            Website = website;
            Domain = domain;
            Scopes = scopes;
        }

        /// <summary>
        /// Registering an application
        /// </summary>
        /// <returns><see cref="OAuthModel"/></returns>
        public async Task<OAuthModel> Register() => await Register(Domain, ClientName, Website, RedirectUris, Scopes);


        /// <summary>
        /// Registering an application
        /// </summary>
        /// <param name="domain">mastodon instance domain</param>
        /// <param name="client_name">Name of your application</param>
        /// <param name="website">(optional) URL to the homepage of your app</param>
        /// <param name="redirect_uris">Where the user should be redirected after authorization (for no redirect, use <see cref="Constants.NoRedirect"/>)</param>
        /// <param name="scopes">This can be a space-separated list of the following items: <see cref="SCOPE_READ"/>, <see cref="SCOPE_WRITE"/> and <see cref="SCOPE_FOLLOW"/></param>
        /// <returns><see cref="OAuthModel"/></returns>
        public static async Task<OAuthModel> Register(string domain, string client_name, string website = "", string redirect_uris = Constants.NoRedirect, params string[] scopes)
        {
            return await HttpHelper.PostAsync<OAuthModel, StringContent>($"{HttpHelper.HTTPS}{domain}{Constants.AppsRegistering}", null,
                new Dictionary<string, StringContent>
                {
                    { nameof(client_name), new StringContent(client_name) },
                    { nameof(redirect_uris), new StringContent(redirect_uris) },
                    { nameof(website), new StringContent(website) },
                    { nameof(scopes), new StringContent(string.Join(" ", scopes)) }
                });
        }

    }
}
