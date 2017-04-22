using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    public static class Instances
    {
        public static async Task<InstanceModel> Instance(string domain)
        {
            return await HttpHelper.GetAsync<InstanceModel>($"{HttpHelper.HTTPS}{domain}{Constants.Instance}", string.Empty, null);
        }
    }
}
