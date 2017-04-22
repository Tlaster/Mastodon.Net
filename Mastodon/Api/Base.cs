using System;
using System.Collections.Generic;
using System.Text;

namespace Mastodon.Api
{
    public abstract class Base
    {

        public string Domain { get; }
        public string AccessToken { get; }

        protected Base(string domain, string accessToken)
        {
            Domain = domain;
            AccessToken = accessToken;
        }

    }
}
