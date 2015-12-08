using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BetterCPS.Channel
{
    class Channels
    {
        public const int OFFSET = 0x1f025;
        public const int DATA_WIDTH = 64; 
        public const int MAX = 999;

        private const int GUID = 0;
        private const int NAME = 1;
        private const int CHANNEL = 2;
        private DataTable allChannels;
        

        public Channels()
        {
            allChannels = new DataTable();
            allChannels.Columns.Add("GUID", typeof(String));
            allChannels.Columns.Add("Name", typeof(String));
            allChannels.Columns.Add("DATA", typeof(ChannelObject));
        
        }

        public void ChannelsFromRawData(byte[] rawData, bool debug)
        {
            int offset = OFFSET;
            for (int i = 0; i < MAX; i++)
            {
                String hex;
                byte[] oneChannelRaw = new byte[DATA_WIDTH];
                for (int j = 0; j < DATA_WIDTH; j++)
                {
                    byte value = rawData[offset + j];
                    oneChannelRaw[j] = value;
                    if (debug)
                    {
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                }
                if (debug) Console.WriteLine();
                offset += DATA_WIDTH;
                ChannelObject ch = new ChannelObject();
                ch.RawData = oneChannelRaw;
                AddChannel(ch);
                if (debug)
                {
                    Console.WriteLine(ch.toString());
                    oneChannelRaw = ch.RawData;
                    for (int j = 0; j < DATA_WIDTH; j++)
                    {
                        byte value = oneChannelRaw[j];
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void AddChannel(ChannelObject oneChannel)
        {
            allChannels.Rows.Add(oneChannel.GUID, oneChannel.Name, oneChannel);
        }

        public ChannelObject getChannelById(int id)
        {
            return (ChannelObject)allChannels.Rows[id].ItemArray[CHANNEL];
        }

        public ChannelObject getChannelByGUID(String guid)
        {
            DataRow[] result = allChannels.Select("GUID = '" + guid + "'");
            if (result != null)
                return (ChannelObject) result[0].ItemArray[CHANNEL];
            return null;
        }
        
        public String getNameById(int id)
        {
            return (String)allChannels.Rows[id].ItemArray[NAME];
        }

        public String getGUIDById(int id)
        {
            return (String)allChannels.Rows[id].ItemArray[GUID];
        }

        public int getIdByGUID(String guid)
        {
            DataRow[] result = allChannels.Select("GUID = '" + guid + "'");
            if (result != null)
                return allChannels.Rows.IndexOf(result[0]);
            return -1;
        }

    }
}
