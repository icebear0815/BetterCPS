using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.Contact
{
    class CType : Parameter
    {
        //Type      0=blank 1=Group 2=Private 3=All   (Ex=Call Tone)
        public const int BLANK = 0x00;
        public const int GROUP = 0x01;
        public const int PRIVATE = 0x02;
        public const int ALL = 0x03;
        public CType()
        {
            offset = 0x03;
            mask = 0x03;

        }

        public static CType fromRaw(byte[] rawData)
        {
            CType ct = new CType();
            byte oneByte = rawData[ct.offset];
            ct.Value = oneByte & ct.mask;
            return ct;
        }

        public override string ToString()
        {
            if (BLANK == value)
                return "Blank";
            else if (GROUP == value)
                return "Group Call";
            else if (PRIVATE == value)
                return "Private Call";
            else if (ALL == value)
                return "All Call";
            else
                return "Unknown";
        }
    }
}
