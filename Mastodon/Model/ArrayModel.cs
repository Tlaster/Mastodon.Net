using System;
using System.Collections.Generic;
using System.Text;

namespace Mastodon.Model
{
    public class ArrayModel<T>
    {
        public List<T> Result { get; set; }
        public int MaxId { get; set; }
        public int SinceId { get; set; }
    }
}
