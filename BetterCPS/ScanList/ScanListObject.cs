using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.ScanList
{
    /*
        Scan Lists (104 Bytes per Entry)
            Byte	function
            0	Name Low Byte of first character 
            1	Name High Byte of first character 
            2-31	Name, Remaining 15 characters
     *      32+33 Priority Channel 1
     *      34+35 Priotity Channel 2
     *      36+37 TX Designated Channel (FF FF for "Last Active Channel")
     *      38  Unknown = F1
     *      39  Signaling Hold Time (wert*25 = SHT in ms) -> in GUI Werte von 50 - 6375 in 25'er Schritten
            40	Priority Sampe Time (wert*250 = PST in ms) -> in GUI Werte von 750 - 7750 in 250'er Schritten
            41	Unknown = FF
            42-103	 Index numbers of remaining channels (up to 31 Entries 2 bytes per channel)
     */

    class ScanListObject
    {
        public const int offset = 0x18A85;
        public const int Length = 104;
        public const int maxCount = 250;

        byte[] rawData;
        BaseName name;
        ChannelId[] channelIDs = new ChannelId[ChannelId.MAX_ID];
        PriorityChannelId priorityChannel1;
        PriorityChannelId priorityChannel2;
        SignalingHoldTime signalingHoldTime;
        PrioritySampleTime prioritySampleTime;
        TXDesignatedChannelId txDesignatedChannelId;
        private String guid;

        internal String ScanListName
        {
            get { return name.Value; }
            set { name.Value = value; }
        }

        public ScanListObject()
        {
            guid = System.Guid.NewGuid().ToString();
        }

        public String GUID
        {
            get { return guid; }
            set { guid = value; }
        }

        public byte[] RawData
        {
            get
            {
                setRawDataFromData();
                return rawData;
            }
            set
            {
                rawData = value;
                setDataFromRawData();
            }
        }

        private void initializeRawData()
        {
            rawData = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

        }
        private void setRawDataFromData()
        {
            initializeRawData();

            rawData = name.toRaw(rawData);
            rawData = priorityChannel1.toRaw(rawData);
            rawData = priorityChannel2.toRaw(rawData);
            rawData = txDesignatedChannelId.toRaw(rawData);
            rawData = signalingHoldTime.toRaw(rawData);
            rawData = prioritySampleTime.toRaw(rawData);
            for (int i = 0; i < ChannelId.MAX_ID; i++)
            {
                rawData = channelIDs[i].toRaw(rawData, i);
            }
        }

        private void setDataFromRawData()
        {
            name = Name.fromRaw(rawData);
            priorityChannel1 = PriorityChannelId.fromRaw(rawData, PriorityChannelId.CHANNEL1);
            priorityChannel2 = PriorityChannelId.fromRaw(rawData, PriorityChannelId.CHANNEL2);
            txDesignatedChannelId = TXDesignatedChannelId.fromRaw(rawData);
            signalingHoldTime = SignalingHoldTime.fromRaw(rawData);
            prioritySampleTime = PrioritySampleTime.fromRaw(rawData);

            for (int i = 0; i < ChannelId.MAX_ID; i++)
            {
                channelIDs[i] = ChannelId.fromRaw(rawData, i);
            }
        }

        public String toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(guid);
            sb.Append(";");
            sb.Append(name);
            sb.Append(";");
            sb.Append(priorityChannel1);
            sb.Append(";");
            sb.Append(priorityChannel2);
            sb.Append(";");
            sb.Append(txDesignatedChannelId);
            sb.Append(";");
            sb.Append(signalingHoldTime);
            sb.Append(";");
            sb.Append(prioritySampleTime);
            for (int i = 0; i < ChannelId.MAX_ID; i++)
            {
                sb.Append(";");
                sb.Append(channelIDs[i]);
            }
            return sb.ToString();
        }
    }
}
