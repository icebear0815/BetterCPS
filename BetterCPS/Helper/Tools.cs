using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Helper
{
    class Tools
    {
        public static Boolean IsEmpty(String str)
        {
            if (str == null) return true;
            str = str.Trim();
            if ("".Equals(str)) return true;
            else if (str.StartsWith("\0")) return true;
            else if (str.StartsWith(" \0")) return true;
            else return false;
        }
    }
}
