using System;

namespace Mastodon.Model
{
    [Flags]
    public enum Scope
    {
        Read = 1,
        Write = 2,
        Follow = 4
    }
}