using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    public partial class Timelines : Base
    {
        public Timelines(string domain, string accessToken) : base(domain, accessToken)
        {
        }

        public async Task<ArrayModel<StatusModel>> Home(int max_id = 0, int since_id = 0)
        {
            return await Home(Domain, AccessToken, max_id, since_id);
        }

        public async Task<ArrayModel<StatusModel>> Public(int max_id = 0, int since_id = 0, bool local = false)
        {
            return await Public(Domain, AccessToken, max_id, since_id, local);
        }

        public async Task<ArrayModel<StatusModel>> HashTag(string hashtag, int max_id = 0, int since_id = 0, bool local = false)
        {
            return await HashTag(Domain, AccessToken, hashtag, max_id, since_id, local);
        }
    }
}
