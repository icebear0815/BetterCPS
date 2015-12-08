using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    abstract class ChannelParameter
    {
        protected int value;
        protected int offset;
        protected int mask;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

       // abstract public ChannelParameter<T> fromRaw(byte[] rawData);
        public virtual byte[] toRaw(byte[] rawData)
        {
            byte oneByte = rawData[offset];
            byte tmpMask = (byte)~mask; //bitwise NOT
            oneByte &= tmpMask;
            oneByte |= (byte)value;
            rawData[offset] = oneByte;
            return rawData;
        }
        public override String ToString()
        {
            return value.ToString() ;
        }
    }
}
