using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.ScanList
{
    class SignalingHoldTime : Parameter
    {
        public SignalingHoldTime()
        {
            offset = 0x27;
        }

        public static SignalingHoldTime fromRaw(byte[] rawData)
        {
            SignalingHoldTime ps = new SignalingHoldTime();
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
            return Convert.ToString(value * 25);
        }
    }
}
