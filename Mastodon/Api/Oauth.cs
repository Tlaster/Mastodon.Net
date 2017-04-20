using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model.Apps;
using Mastodon.Model.OAuth;

namespace Mastodon.Api
{
    public class OAuth
    {
        /// <summary>
        /// Mastodon instance domain
        /// </summary>
        public string Domain { get; }

        public string ClientId { get; }

        public string ClientSecret { get; }

        public string RedirectUri { get; }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain">Mastodon instance domain</param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret">left it empty or you want to authorize by password</param>
        /// <param name="redirectUri"></param>
        public OAuth(string domain, string clientId, string clientSecret = "", string redirectUri = Constants.NoRedirect)
        {
            Domain = domain;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        public string GetGrantUrl() =>
            $"{HttpHelper.HTTPS}{Domain}{Constants.OAuthAuthorize}?client_id={ClientId}&response_type=code&redirect_uri={RedirectUri}";

        public async Task<TokenModel> GetAccessTokenByCode(string code) => await GetAccessTokenByCode(Domain, ClientId, ClientSecret, RedirectUri, code);

        public static async Task<TokenModel> GetAccessTokenByCode(string domain, string client_id, string client_secret, string redirect_uri, string code)
        {
            return await HttpHelper.PostAsync<TokenModel, StringContent>($"{HttpHelper.HTTPS}{domain}{Constants.OAuthToken}", null,
                new Dictionary<string, StringContent>
                {
                    { nameof(client_id), new StringContent(client_id) },
                    { nameof(client_secret), new StringContent(client_secret) },
                    { nameof(redirect_uri), new StringContent(redirect_uri) },
                    { "grant_type", new StringContent("authorization_code") },
                    { nameof(code), new StringContent(code) }
                });
        }

        public async Task<TokenModel> GetAccessTokenByPassword(string username, string password) => await GetAccessTokenByPassword(Domain, ClientId, ClientSecret, RedirectUri, username, password);

        public static async Task<TokenModel> GetAccessTokenByPassword(string domain, string client_id, string client_secret, string redirect_uri, string username, string password)
        {
            return await HttpHelper.PostAsync<TokenModel, StringContent>($"{HttpHelper.HTTPS}{domain}{Constants.OAuthToken}", null,
                new Dictionary<string, StringContent>
                {
                    { nameof(client_id), new StringContent(client_id) },
                    { nameof(client_secret), new StringContent(client_secret) },
                    { nameof(redirect_uri), new StringContent(redirect_uri) },
                    { "grant_type", new StringContent("password") },
                    { nameof(username), new StringContent(username) },
                    { nameof(password), new StringContent(password) }
                });
        }
    }
}
