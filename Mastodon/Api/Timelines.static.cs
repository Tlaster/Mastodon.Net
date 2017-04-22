using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    /// <summary>
    /// Retrieving a timeline
    /// </summary>
    partial class Timelines
    {
        public static async Task<ArrayModel<StatusModel>> Home(string domain, string token, int max_id = 0, int since_id = 0)
        {
            return await HttpHelper.GetArrayAsync<StatusModel>($"{HttpHelper.HTTPS}{domain}{Constants.TimelineHome}", token, max_id, since_id);
        }

        public static async Task<ArrayModel<StatusModel>> Public(string domain, string token, int max_id = 0, int since_id = 0, bool local = false)
        {
            return await HttpHelper.GetArrayAsync<StatusModel>($"{HttpHelper.HTTPS}{domain}{Constants.TimelinePublic}", token, max_id, since_id, (nameof(local), local.ToString()));
        }

        public static async Task<ArrayModel<StatusModel>> HashTag(string domain, string token, string hashtag, int max_id = 0, int since_id = 0, bool local = false)
        {
            return await HttpHelper.GetArrayAsync<StatusModel>($"{HttpHelper.HTTPS}{domain}{Constants.TimelineTag.Id(hashtag)}", token, max_id, since_id, (nameof(local), local.ToString()));
        }
    }
}
