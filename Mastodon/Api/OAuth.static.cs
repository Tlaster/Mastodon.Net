using Mastodon.Common;
using Mastodon.Model.OAuth;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mastodon.Api
{
    public partial class OAuth
    {
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
