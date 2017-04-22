using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    public partial class Follows : Base
    {

        /// <summary>
        /// Following a remote user
        /// </summary>
        /// <param name="uri">username@domain of the person you want to follow</param>
        /// <returns>Returns the local representation of the followed account, as an <see cref="AccountModel"/></returns>
        public async Task<AccountModel> Following(string uri)
        {
            return await Following(Domain, AccessToken, uri);
        }

        public Follows(string domain, string accessToken) : base(domain, accessToken)
        {
        }
    }
}
