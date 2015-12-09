using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BetterCPS.Zone
{
    class Zones
    {
        public const int OFFSET = 0x18A85;
        public const int DATA_WIDTH = 104; 
        public const int MAX = 250;

        private const int GUID = 0;
        private const int NAME = 1;
        private const int Zone = 2;
        private DataTable allZones;

        
        public Zones()
        {
            allZones = new DataTable();
            allZones.Columns.Add("GUID", typeof(String));
            allZones.Columns.Add("Name", typeof(String));
            allZones.Columns.Add("DATA", typeof(ZoneObject));
        }

        public void ZonesFromRawData(byte[] rawData, bool debug)
        {
            int offset = OFFSET;
            for (int i = 0; i < MAX; i++)
            {
                //Console.WriteLine("Zones: "+i);
                String hex;
                byte[] oneZoneRaw = new byte[DATA_WIDTH];
                for (int j = 0; j < DATA_WIDTH; j++)
                {
                    byte value = rawData[offset + j];
                    oneZoneRaw[j] = value;
                    if (debug)
                    {
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                }
                if (debug) Console.WriteLine();
                offset += DATA_WIDTH;
                ZoneObject ch = new ZoneObject();
                ch.RawData = oneZoneRaw;
                AddZone(ch);
                if (debug)
                {
                    Console.WriteLine(ch.toString());
                    oneZoneRaw = ch.RawData;
                    for (int j = 0; j < DATA_WIDTH; j++)
                    {
                        byte value = oneZoneRaw[j];
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void AddZone(ZoneObject oneZone)
        {
            allZones.Rows.Add(oneZone.GUID, oneZone.ZoneName, oneZone);
        }

        public ZoneObject getObjectById(int id)
        {
            return (ZoneObject)allZones.Rows[id-1].ItemArray[Zone];
        }

        public ZoneObject getObjectByGUID(String guid)
        {
            DataRow[] result = allZones.Select("GUID = '" + guid + "'");
            if (result != null)
                return (ZoneObject) result[0].ItemArray[Zone];
            return null;
        }
        
        public String getNameById(int id)
        {
            return (String)allZones.Rows[id].ItemArray[NAME];
        }

        public String getGUIDById(int id)
        {
            return (String)allZones.Rows[id].ItemArray[GUID];
        }

        public int getIdByGUID(String guid)
        {
            DataRow[] result = allZones.Select("GUID = '" + guid + "'");
            if (result != null)
                return allZones.Rows.IndexOf(result[0]);
            return -1;
        }

    }
}
