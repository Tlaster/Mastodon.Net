using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    /// <summary>
    ///     Retrieving a timeline
    /// </summary>
    internal class Timelines
    {
        public static async Task<MastodonList<Status>> Home(string domain, string token, int max_id = 0,
            int since_id = 0)
        {
            return await HttpHelper.GetArrayAsync<Status>($"{HttpHelper.HTTPS}{domain}{Constants.TimelineHome}", token,
                max_id, since_id);
        }

        public static async Task<MastodonList<Status>> Public(string domain, int max_id = 0, int since_id = 0,
            bool local = false)
        {
            return await HttpHelper.GetArrayAsync<Status>($"{HttpHelper.HTTPS}{domain}{Constants.TimelinePublic}",
                string.Empty, max_id, since_id, (nameof(local), local.ToString()));
        }

        public static async Task<MastodonList<Status>> HashTag(string domain, string hashtag, int max_id = 0,
            int since_id = 0, bool local = false)
        {
            return await HttpHelper.GetArrayAsync<Status>(
                $"{HttpHelper.HTTPS}{domain}{Constants.TimelineTag.Id(hashtag)}", string.Empty, max_id, since_id,
                (nameof(local), local.ToString()));
        }
    }
}