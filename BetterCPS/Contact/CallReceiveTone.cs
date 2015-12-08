using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.Contact
{
    class CallReceiveTone : SimpleParameter
    {
        public const int YES = 0x01;
        public const int NO = 0x00;
        
        public CallReceiveTone(int offset, int bit) : base(offset, bit)
        {
            this.offset = offset;
            this.bit = bit;
            this.invert = false;
        }
        public CallReceiveTone(int offset, int bit, bool invert) : base(offset, bit, invert)
        {
            this.offset = offset;
            this.bit = bit;
            this.invert = invert;
        }
        public static CallReceiveTone fromRaw(byte[] rawData, int offset, int bit)
        {
            CallReceiveTone sp = new CallReceiveTone(offset, bit);
            sp.fromRaw(rawData);
            return sp;
        }
        public override string ToString()
        {
            if (YES == value)
                return "Yes";
            else if (NO == value)
                return "No";
            else
                return "Unknown";
        }
    }
}
