using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.ScanList
{
    class PrioritySampleTime : Parameter
    {
        public PrioritySampleTime()
        {
            offset = 0x28;
        }

        public static PrioritySampleTime fromRaw(byte[] rawData)
        {
            PrioritySampleTime ps = new PrioritySampleTime();
            ps.Value = rawData[ps.offset];
            return ps;
        }

        public byte[] toRaw(byte[] rawData)
        {
            rawData[offset] = (byte)value;
            return rawData;
        }

        public override string ToString()
        {
            return Convert.ToString(value * 250);
        }
    }
}
