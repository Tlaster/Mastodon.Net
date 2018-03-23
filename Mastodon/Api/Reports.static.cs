using System.Linq;
using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    public class Reports
    {
        /// <summary>
        ///     Fetching a user's reports
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="token"></param>
        /// <param name="max_id"></param>
        /// <param name="since_id"></param>
        /// <returns>Returns a list of <see cref="ReportModel" /> made by the authenticated user</returns>
        public static async Task<MastodonList<Report>> Fetching(string domain, string token, int max_id = 0,
            int since_id = 0)
        {
            return await HttpHelper.GetArrayAsync<Report>($"{HttpHelper.HTTPS}{domain}{Constants.ReportsFetching}",
                token, max_id, since_id);
        }

        /// <summary>
        ///     Reporting a user
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="token"></param>
        /// <param name="account_id">The ID of the account to report</param>
        /// <param name="comment">A comment to associate with the report</param>
        /// <param name="status_ids">The IDs of statuses to report (can be an array)</param>
        /// <returns>Returns the finished <see cref="ReportModel" />.</returns>
        public static async Task<Report> Reporting(string domain, string token, int account_id, string comment,
            params int[] status_ids)
        {
            var param = HttpHelper.ArrayEncode(nameof(status_ids), status_ids.Select(v => v.ToString()).ToArray())
                .ToList();
            param.Add((nameof(account_id), account_id.ToString()));
            param.Add((nameof(comment), comment));
            return await HttpHelper.PostAsync<Report, string>($"{HttpHelper.HTTPS}{domain}{Constants.ReportsReporting}",
                token, param);
        }
    }
}