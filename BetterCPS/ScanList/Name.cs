using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.ScanList
{
    /*
     Scan Lists (104 Bytes per Entry)
        Byte	function
        0	Name Low Byte of first character 
        1	Name High Byte of first character 
        2-31	Name, Remaining 15 characters
        32-39	Unknown (probably Priority Chans and hold times)
        40	Index number of Channel Low Byte
        41	Index number of Channel High Byte
        42-103	 Index numbers of remaining channels (up to 32 Entries 2 bytes per channel)
*/
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
