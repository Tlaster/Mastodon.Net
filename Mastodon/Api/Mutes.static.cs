using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    public class Mutes
    {
        /// <summary>
        ///     Fetching a user's mutes
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="token"></param>
        /// <param name="max_id"></param>
        /// <param name="since_id"></param>
        /// <returns>Returns an array of <see cref="AccountModel" /> muted by the authenticated user</returns>
        public static async Task<MastodonList<Account>> Fetching(string domain, string token, int max_id = 0,
            int since_id = 0)
        {
            return await HttpHelper.GetArrayAsync<Account>($"{HttpHelper.HTTPS}{domain}{Constants.MutesFetching}",
                token, max_id, since_id);
        }
    }
}