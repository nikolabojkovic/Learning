using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge_Example
{
    public class BackwardsFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return string.Format("{0}: {1}", key, new string(value.Reverse().ToArray()));
        }
    }
}
