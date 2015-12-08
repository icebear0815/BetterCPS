using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class RepeaterSlot : ChannelParameter
    {
                

        public RepeaterSlot()
        {
            mask = 0x0C;
            offset = 0x01;
        }
        public static RepeaterSlot fromRaw(byte[] rawData)
        {
            RepeaterSlot rs = new RepeaterSlot();
            byte oneByte = rawData[rs.offset];
            rs.Value = oneByte & rs.mask;
            rs.Value = (byte)(rs.Value >> 2);
            return rs;
        }

        public override byte[] toRaw(byte[] rawData)
        {
            byte oneByte = rawData[offset];
            byte tmpMask = (byte)(~mask);
            oneByte &= tmpMask; //set the masked bits to 0
            byte tmpValue = (byte) (value << 2);
            oneByte |= tmpValue;
            rawData[offset] = oneByte;
            return rawData;
        }
       
    }
}
