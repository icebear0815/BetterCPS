using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.Zone
{
    class Name : BaseName
    {
        private const int OFFSET = 0x00;

        public Name()
            : base()
        {
            offset = OFFSET;
        }

        public static BaseName fromRaw(byte[] rawData)
        {
            return new BaseName(OFFSET, rawData);
        }
    }
}
