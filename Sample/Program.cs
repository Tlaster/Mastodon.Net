using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mastodon.Api;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
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

            var oauth = await Apps.Register(domain, clientName, scopes: new[] {Apps.SCOPE_READ, Apps.SCOPE_WRITE, Apps.SCOPE_FOLLOW});
            var token = await OAuth.GetAccessTokenByPassword(domain, oauth.ClientId, oauth.ClientSecret, oauth.RedirectUri, userName, password, Apps.SCOPE_READ, Apps.SCOPE_WRITE, Apps.SCOPE_FOLLOW);

            var timeline = await Timelines.Home(domain, token.AccessToken);
            var notify = await Notifications.Fetching(domain, token.AccessToken);
            Console.ReadKey();
        }
    }
}