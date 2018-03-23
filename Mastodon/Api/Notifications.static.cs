using System.Net.Http;
using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    public class Notifications
    {
        /// <summary>
        ///     Fetching a user's notifications
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="token"></param>
        /// <param name="max_id"></param>
        /// <param name="since_id"></param>
        /// <returns>Returns a list of <see cref="NotificationModel" /> for the authenticated user</returns>
        public static async Task<MastodonList<Notification>> Fetching(string domain, string token, int max_id = 0,
            int since_id = 0)
        {
            return await HttpHelper.GetArrayAsync<Notification>(
                $"{HttpHelper.HTTPS}{domain}{Constants.NotificationsFetching}", token, max_id, since_id);
        }

        /// <summary>
        ///     Getting a single notification
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="token"></param>
        /// <param name="id"></param>
        /// <returns>Returns the <see cref="NotificationModel" />.</returns>
        public static async Task<Notification> GetSingle(string domain, string token, int id)
        {
            return await HttpHelper.GetAsync<Notification>(
                $"{HttpHelper.HTTPS}{domain}{Constants.NotificationsSingle.Id(id.ToString())}", token, null);
        }

        /// <summary>
        ///     Clearing notifications
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="token"></param>
        /// <returns>Deletes all notifications from the Mastodon server for the authenticated user. Returns an empty object.</returns>
        public static async Task Clear(string domain, string token)
        {
            await HttpHelper.PostAsync<HttpContent>($"{HttpHelper.HTTPS}{domain}{Constants.NotificationsClear}", token,
                null);
        }
    }
}