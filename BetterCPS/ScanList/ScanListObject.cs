using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;
using BetterCPS.Channel;

namespace BetterCPS.ScanList
{
    /*
        Scan Lists (104 Bytes per Entry)
            Byte	function
            0	Name Low Byte of first character 
            1	Name High Byte of first character 
            2-31	Name, Remaining 15 characters
     *      32+33 Priority Channel 1 (0x0000 = Selected 0xffff= None)
     *      34+35 Priotity Channel 2
     *      36+37 TX Designated Channel (FF FF for "Last Active Channel")
     *      38  Unknown = F1
     *      39  Signaling Hold Time (wert*25 = SHT in ms) -> in GUI Werte von 50 - 6375 in 25'er Schritten
            40	Priority Sampe Time (wert*250 = PST in ms) -> in GUI Werte von 750 - 7750 in 250'er Schritten
            41	Unknown = FF
            42-103	 Index numbers of remaining channels (up to 31 Entries 2 bytes per channel)
     */

    public class ScanListObject
    {
        public const int offset = 0x18A85;
        public const int Length = 104;
        public const int maxCount = 250;

        public const int _GUID = 0;
        public const int _NAME = 1;
        public const int _PRIORITYCHANNEL1 = 2;
        public const int _PRIORITYCHANNEL2 = 3;
        public const int _TXDESIGNATEDCHANNELID = 4;
        public const int _SIGNALINGHOLDTIME = 5;
        public const int _PRIORITYSAMPLETIME = 6;
        public const int _CHANNEL = 7;

        public const int NONE = 0xffff;
        public const int SELECTED = 0x0000;

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
            initializeRawData();
            setDataFromRawData();
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
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF1, 0x00, 
                                   0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
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
            rawData = priorityChannel1.toRaw(rawData, PriorityChannelId.CHANNEL1);
            rawData = priorityChannel2.toRaw(rawData, PriorityChannelId.CHANNEL2);
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

        private int getPriorityChannelValue(Channels allChannels, String valStr, bool withGUID)
        {
            if ("Selected".Equals(valStr))
                return SELECTED;
            else if ("None".Equals(valStr))
                return NONE;
            else if (withGUID)
                return allChannels.getIdByGUID(valStr);
            else
                return allChannels.getIdByName(valStr);
        }
        private int getTXDesignatedChannelValue(Channels allChannels, String valStr, bool withGUID)
        {
            if ("Selected".Equals(valStr))
                return SELECTED;
            else if ("Last Active Channel".Equals(valStr))
                return 0xffff;
            else if (withGUID)
                return allChannels.getIdByGUID(valStr);
            else
                return allChannels.getIdByName(valStr);
        }
        public void SetDataFromCSV(String csvData, Channels allChannels, bool withGUID)
        {
            String[] allFields = csvData.Split(';');
            guid = allFields[_GUID];
            name.Value = allFields[_NAME];
            priorityChannel1.Value = getPriorityChannelValue(allChannels, allFields[_PRIORITYCHANNEL1], withGUID);
            priorityChannel2.Value = getPriorityChannelValue(allChannels, allFields[_PRIORITYCHANNEL2], withGUID);
            txDesignatedChannelId.Value = getTXDesignatedChannelValue(allChannels, allFields[_TXDESIGNATEDCHANNELID], withGUID);
            signalingHoldTime.FromString(allFields[_SIGNALINGHOLDTIME]);
            prioritySampleTime.FromString(allFields[_PRIORITYSAMPLETIME]);
            for (int i = 0; i < allFields.Length - _CHANNEL; i++)
            {
                if (withGUID)
                    channelIDs[i].Value = allChannels.getIdByGUID(allFields[_CHANNEL + i]);
                else
                    channelIDs[i].Value = allChannels.getIdByName(allFields[_CHANNEL + i]);
            }

        }

        public String ToString()
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
        public String ToString(Channels allChannels)
        {
            return ToString(allChannels, false);
        }
        private String getPriorityChannelString(Channels allChannels, int val, bool withGUID)
        {
            if (val == 0x00)
                return "Selected";
            else if (val == 0xffff)
                return "None";
            else if (withGUID)
                return allChannels.getGUIDById(val);
            else
                return allChannels.getNameById(val);
        }
        private String getTXDesignatedChannelString(Channels allChannels, int val, bool withGUID)
        {
            if (val == 0x00)
                return "Selected";
            else if (val == 0xffff)
                return "Last Active Channel";
            else if (withGUID)
                return allChannels.getGUIDById(val);
            else
                return allChannels.getNameById(val);
        }
        public String ToString(Channels allChannels, bool withGUID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(guid);
            sb.Append(";");
            sb.Append(name);
            sb.Append(";");
            sb.Append(getPriorityChannelString(allChannels, priorityChannel1.Value, withGUID));
            sb.Append(";");
            sb.Append(getPriorityChannelString(allChannels, priorityChannel2.Value, withGUID));
            sb.Append(";");
            sb.Append(getTXDesignatedChannelString(allChannels, txDesignatedChannelId.Value, withGUID));
            sb.Append(";");
            sb.Append(signalingHoldTime);
            sb.Append(";");
            sb.Append(prioritySampleTime);
            for (int i = 0; i < ChannelId.MAX_ID; i++)
            {
                sb.Append(";");
                //sb.Append(channelIDs[i]);
                if (withGUID)
                    sb.Append(allChannels.getGUIDById(channelIDs[i].Value));
                else
                    sb.Append(allChannels.getNameById(channelIDs[i].Value));
            }
            return sb.ToString();
        }
    }
}
