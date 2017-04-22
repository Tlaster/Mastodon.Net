using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    public partial class Mutes : Base
    {
        public Mutes(string domain, string accessToken) : base(domain, accessToken)
        {
        }
        /// <summary>
        /// Fetching a user's mutes
        /// </summary>
        /// <param name="max_id"></param>
        /// <param name="since_id"></param>
        /// <returns>Returns an array of <see cref="AccountModel"/> muted by the authenticated user</returns>
        public async Task<ArrayModel<AccountModel>> Fetching(int max_id = 0, int since_id = 0)
        {
            return await Fetching(Domain, AccessToken, max_id, since_id);
        }
    }
}
