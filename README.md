# Mastodon.Net
.Net wrapper(.Net Standard 1.4) for [Mastodon](https://github.com/tootsuite/mastodon) Api  

# Getting Start  
[![NuGet version](https://badge.fury.io/nu/Mastodon.Net.svg)](https://badge.fury.io/nu/Mastodon.Net)
[![Build status](https://ci.appveyor.com/api/projects/status/m1gli5hd3yk30rl2?svg=true)](https://ci.appveyor.com/project/Tlaster/mastodon-net)


# Sample  
```C#            
var domain = "mstdn.jp";
var clientName = "Mastodon.Net";
var userName = "";
var password = "";

var oauth = await Apps.Register(domain, clientName, scopes: new[] { Scope.Read, Scope.Write, Scope.Follow });
var token = await OAuth.GetAccessTokenByPassword(domain, oauth.ClientId, oauth.ClientSecret, userName, password, Scope.Read, Scope.Write, Scope.Follow);

var timeline = await Timelines.Home(domain, token.AccessToken);
var notify = await Notifications.Fetching(domain, token.AccessToken);
var toot = await Statuses.Posting(domain, token.AccessToken, "Toot!");
```

# License
```
MIT License

Copyright (c) 2017 Tlaster

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
