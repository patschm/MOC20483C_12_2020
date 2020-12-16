using System;
using System.Collections.Generic;
using System.Text;

namespace Weird
{
    static class StringUtils
    {
        public static string SponsoredBy(this string target, string merk) // Extension
        {
            return $"{target} is sponsored by {merk}";
        }
    }
}
