using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    public static class Instances
    {
        public static async Task<Instance> Instance(string domain)
        {
            return await HttpHelper.GetAsync<Instance>($"{HttpHelper.HTTPS}{domain}{Constants.Instance}", string.Empty,
                null);
        }
    }
}