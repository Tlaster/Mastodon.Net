using System;
using System.Collections.Generic;
using System.Text;

namespace Mastodon.Common
{
    public class MastodonException : Exception
    {
        public MastodonException()
        {
        }

        public MastodonException(string message) : base(message)
        {
        }

        public MastodonException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
