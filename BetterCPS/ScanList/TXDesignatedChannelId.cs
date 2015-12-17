using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.ScanList
{
    class TXDesignatedChannelId :Parameter
    {
        public TXDesignatedChannelId()
        {
            offset = 0x24;
        }
        public static TXDesignatedChannelId fromRaw(byte[] rawData)
        {
            TXDesignatedChannelId ci = new TXDesignatedChannelId();
            byte lower = rawData[ci.offset];
            byte upper = rawData[ci.offset + 1];
            ci.value = upper;
            ci.value = ci.value << 8;
            ci.value ^= lower;
            return ci;
        }

        public byte[] toRaw(byte[] rawData)
        {
            uint number = Convert.ToUInt32(value);
            byte upper = (byte)(number >> 8);
            byte lower = (byte)(number & 0xff);
            rawData[offset] = lower;
            rawData[offset + 1] = upper;
            return rawData;
        }
    }
}
