using System;
using System.Threading.Tasks;
using Mastodon.Api;
using Mastodon.Model;

namespace Sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SampleTest().Wait();
            Console.WriteLine("Hello World!");
        }

        private static async Task SampleTest()
        {
            var domain = "mstdn.jp";
            var clientName = "Mastodon.Net";
            var userName = "";
            var password = "";

            var oauth = await Apps.Register(domain, clientName,
                scopes: new[] {Scope.Follow, Scope.Read, Scope.Write});
            var token = await OAuth.GetAccessTokenByPassword(domain, oauth.ClientId, oauth.ClientSecret,
                oauth.RedirectUri, userName, password, Scope.Follow, Scope.Read, Scope.Write);

            var timeline = await Timelines.Home(domain, token.AccessToken);
            var notify = await Notifications.Fetching(domain, token.AccessToken);
            var toot = await Statuses.Posting(domain, token.AccessToken, "Toot!");
            Console.ReadKey();
        }
    }
}