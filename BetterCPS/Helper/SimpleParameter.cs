using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Helper
{
    class SimpleParameter : Parameter
    {
        protected int bit;
        protected bool invert;
          
        public SimpleParameter(int offset, int bit)
        {
            this.offset = offset;
            this.bit = bit;
            this.invert = false;
        }
        public SimpleParameter(int offset, int bit, bool invert)
        {
            this.offset = offset;
            this.bit = bit;
            this.invert = invert;
        }
        public void fromRaw(byte[] rawData)
        {
            byte oneByte = rawData[offset];
            value = getBit(rawData);
        }
        public static SimpleParameter fromRaw(byte[] rawData, int offset, int bit)
        {
            SimpleParameter sp = new SimpleParameter(offset, bit);
            sp.fromRaw(rawData);
            return sp;
        }
        public override byte[] toRaw(byte[] rawData)
        {
            setBit(rawData);            
            return rawData;
        }
        private int getBit(byte[] rawData)
        {
            int oneByte = rawData[offset];
            int mask = 0x01;
            mask <<= bit;
            if (invert)
                return (oneByte & mask) > 0 ? 0 : 1;
            else
                return (oneByte & mask) > 0 ? 1 : 0;
        }
        private void setBit(byte[] rawData)
        {
            byte oneByte = rawData[offset];
            byte mask = 0x01;
            byte tmpValue;
            if (invert)
                tmpValue = (byte)(value > 0 ? 0 : 1);
            else
                tmpValue = (byte)(value > 0 ? 1 : 0);
            mask <<= bit;
            tmpValue <<= bit;
            byte tmpMask = (byte)(~mask);
            oneByte &= tmpMask;
            oneByte |= (byte)tmpValue;
            rawData[offset] = oneByte;
        }
        /*public override string ToString()
        {
            throw new NotImplementedException();
        }*/
    }
}
