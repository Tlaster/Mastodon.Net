using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    public static class Lists
    {
        public static async Task<MastodonList<List>> GetLists(string domain, string token)
        {
            return await HttpHelper.Instance.GetListAsync<List>($"{HttpHelper.HTTPS}{domain}{Constants.List}", token);
        }

        public static async Task<MastodonList<List>> ListsByMembership(string domain, string token)
        {
            return await HttpHelper.Instance.GetListAsync<List>($"{HttpHelper.HTTPS}{domain}{Constants.ListsByMembership}",
                token);
        }

        public static async Task<MastodonList<List>> AccountsInList(string domain, string token)
        {
            return await HttpHelper.Instance.GetListAsync<List>($"{HttpHelper.HTTPS}{domain}{Constants.AccountsInList}", token);
        }

        public static async Task<List> ListById(string domain, string token, string id)
        {
            return await HttpHelper.Instance.GetAsync<List>($"{HttpHelper.HTTPS}{domain}{Constants.ListById}", token,
                param: (nameof(id), id));
        }

        public static async Task<List> CreateList(string domain, string token, string title)
        {
            return await HttpHelper.Instance.PostAsync<List, string>($"{HttpHelper.HTTPS}{domain}{Constants.List}", token,
                (nameof(title), title));
        }

        public static async Task<List> UpdateList(string domain, string token, string id)
        {
            return await HttpHelper.Instance.PutAsync<List, string>($"{HttpHelper.HTTPS}{domain}{Constants.ListById}", token,
                param: (nameof(id), id));
        }
        
        public static async Task<List> DeleteList(string domain, string token, string id)
        {
            return await HttpHelper.Instance.DeleteAsync<List, string>($"{HttpHelper.HTTPS}{domain}{Constants.ListById}", token,
                param: (nameof(id), id));
        }

        public static async Task AddAccount(string domain, string token, string id)
        {
            await HttpHelper.Instance.PostAsync($"{HttpHelper.HTTPS}{domain}{Constants.AccountsInList}", token,
                (nameof(id), id));
        }
        
        public static async Task RemoveAccount(string domain, string token, string id)
        {
            await HttpHelper.Instance.DeleteAsync($"{HttpHelper.HTTPS}{domain}{Constants.AccountsInList}", token,
                (nameof(id), id));
        }
        
    }
}