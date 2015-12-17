using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.ScanList
{
    class PriorityChannelId : Parameter
    {
        public const int CHANNEL1 = 0x00;
        public const int CHANNEL2 = 0x01;

        public PriorityChannelId()
        {
            offset = 0x20;
        }
        public static PriorityChannelId fromRaw(byte[] rawData, int id)
        {
            PriorityChannelId ci = new PriorityChannelId();
            id = id * 2;
            byte lower = rawData[ci.offset + id];
            byte upper = rawData[ci.offset + id + 1];
            ci.value = upper;
            ci.value = ci.value << 8;
            ci.value ^= lower;
            return ci;
        }

        public byte[] toRaw(byte[] rawData, int id)
        {
            id = id * 2;
            uint number = Convert.ToUInt32(value);
            byte upper = (byte)(number >> 8);
            byte lower = (byte)(number & 0xff);
            rawData[offset] = lower;
            rawData[offset + id + 1] = upper;
            return rawData;
        }

    }
}
