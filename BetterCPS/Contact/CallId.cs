using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.Contact
{
    class CallId : Parameter
    {
        public CallId()
        {
            offset = 0x00;
        }
        public static CallId fromRaw(byte[] rawData)
        {
            CallId ci = new CallId();
            byte lower = rawData[ci.offset];
            byte middle = rawData[ci.offset + 1];
            byte upper = rawData[ci.offset + 2];
            ci.value = upper;
            ci.value = ci.value << 8;
            ci.value ^= middle;
            ci.value = ci.value << 8;
            ci.value ^= lower;
            return ci;
        }

        public override byte[]  toRaw(byte[] rawData)
        {
            uint number = Convert.ToUInt32(value);
            byte upper = (byte) (number >> 16);
            byte middle = (byte)(number >> 8);
            byte lower = (byte) (number & 0xff);
            rawData[offset] = lower;
            rawData[offset + 1] = middle;
            rawData[offset + 2] = upper;
            return rawData;
        }
    }
}
