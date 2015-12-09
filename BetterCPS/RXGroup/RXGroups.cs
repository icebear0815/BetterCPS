using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BetterCPS.RXGroup
{
    class RXGroups
    {
        public const int OFFSET = 0x0EE45;
        public const int DATA_WIDTH = 96; 
        public const int MAX = 250;

        private const int GUID = 0;
        private const int NAME = 1;
        private const int RXGroup = 2;
        private DataTable allRXGroups;


        public RXGroups()
        {
            allRXGroups = new DataTable();
            allRXGroups.Columns.Add("GUID", typeof(String));
            allRXGroups.Columns.Add("Name", typeof(String));
            allRXGroups.Columns.Add("DATA", typeof(RXGroupObject));
        
        }

        public void RXGroupsFromRawData(byte[] rawData, bool debug)
        {
            int offset = OFFSET;
            for (int i = 0; i < MAX; i++)
            {
                //Console.WriteLine("RXGroups: "+i);
                String hex;
                byte[] oneRXGroupRaw = new byte[DATA_WIDTH];
                for (int j = 0; j < DATA_WIDTH; j++)
                {
                    byte value = rawData[offset + j];
                    oneRXGroupRaw[j] = value;
                    if (debug)
                    {
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                }
                if (debug) Console.WriteLine();
                offset += DATA_WIDTH;
                RXGroupObject ch = new RXGroupObject();
                ch.RawData = oneRXGroupRaw;
                AddRXGroup(ch);
                if (debug)
                {
                    Console.WriteLine(ch.toString());
                    oneRXGroupRaw = ch.RawData;
                    for (int j = 0; j < DATA_WIDTH; j++)
                    {
                        byte value = oneRXGroupRaw[j];
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void AddRXGroup(RXGroupObject oneRXGroup)
        {
            allRXGroups.Rows.Add(oneRXGroup.GUID, oneRXGroup.RXGroupName, oneRXGroup);
        }

        public RXGroupObject getObjectById(int id)
        {
            return (RXGroupObject)allRXGroups.Rows[id].ItemArray[RXGroup];
        }

        public RXGroupObject getObjectByGUID(String guid)
        {
            DataRow[] result = allRXGroups.Select("GUID = '" + guid + "'");
            if (result != null)
                return (RXGroupObject) result[0].ItemArray[RXGroup];
            return null;
        }
        
        public String getNameById(int id)
        {
            return (String)allRXGroups.Rows[id-1].ItemArray[NAME];
        }

        public String getGUIDById(int id)
        {
            return (String)allRXGroups.Rows[id].ItemArray[GUID];
        }

        public int getIdByGUID(String guid)
        {
            DataRow[] result = allRXGroups.Select("GUID = '" + guid + "'");
            if (result != null)
                return allRXGroups.Rows.IndexOf(result[0]);
            return -1;
        }

    }
}
