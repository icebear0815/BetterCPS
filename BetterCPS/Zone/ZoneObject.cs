using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;
using BetterCPS.Channel;

namespace BetterCPS.Zone
{
    /*
        Zones (64 Bytes per Entry)
        Byte	function
        0	Name Low Byte of first character 
        1	Name High Byte of first character 
        2-31	Name, Remaining 15 characters
        32	Index Number of Channel Low Byte
        33	Index Number of Channel High Byte
        34-63   Index Numbers of remaining channels (up to 16 entries 2 bytes per entry)
     */

    public class ZoneObject
    {
        public const int offset = 0x14C05;
        public const int Length = 64;
        public const int maxCount = 250;

        public const int _GUID = 0;
        public const int _NAME = 1;
        public const int _CHANNEL = 2;


        byte[] rawData;
        BaseName name;
        ChannelId[] channelIDs = new ChannelId[ChannelId.MAX_ID];
        private String guid;

        public ZoneObject()
        {
            guid = System.Guid.NewGuid().ToString();
            initializeRawData();
            setDataFromRawData();
        }


        internal String ZoneName
        {
            get { return name.Value; }
            set { name.Value = value; }
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
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        }
        private void setRawDataFromData()
        {
            initializeRawData();

            rawData = name.toRaw(rawData);
            for (int i = 0; i < ChannelId.MAX_ID; i++)
            {
                rawData = channelIDs[i].toRaw(rawData, i);
            }
        }

        private void setDataFromRawData()
        {
            name = Name.fromRaw(rawData);
            for (int i = 0; i < ChannelId.MAX_ID; i++)
            {
                channelIDs[i] = ChannelId.fromRaw(rawData, i);
            }
        }
        public void SetDataFromCSV(String csvData, Channels allChannels, bool withGUID)
        {
            String[] allFields = csvData.Split(';');
            guid = allFields[_GUID];
            name.Value = allFields[_NAME];
            for (int i = 0; i < allFields.Length - _CHANNEL; i++)
            {
                if (withGUID)
                    channelIDs[i].Value = allChannels.getIdByGUID(allFields[_CHANNEL + i]);
                else
                    channelIDs[i].Value = allChannels.getIdByName(allFields[_CHANNEL + i]);
            }

        }

        public String ToString(Channels allChannels, bool withGUID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(guid);
            sb.Append(";");
            sb.Append(name);
            for (int i = 0; i < ChannelId.MAX_ID; i++)
            {
                sb.Append(";");
                if (withGUID)
                    sb.Append(allChannels.getGUIDById(channelIDs[i].Value));
                else
                    sb.Append(allChannels.getNameById(channelIDs[i].Value));
            }
            return sb.ToString();
        }

        public String ToString(Channels allChannels)
        {
            return ToString(allChannels, false);
        }

        public String toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(guid);
            sb.Append(";");
            sb.Append(name);
            for (int i = 0; i < ChannelId.MAX_ID; i++)
            {
                sb.Append(";");
                sb.Append(channelIDs[i]);
            }
            return sb.ToString();
        }
    }
}
