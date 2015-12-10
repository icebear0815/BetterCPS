using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BetterCPS.Contact
{
    class Contacts
    {
        public const int OFFSET = 0x061A5;
        public const int DATA_WIDTH = 36; 
        public const int MAX = 1000;

        private const int GUID = 0;
        private const int NAME = 1;
        private const int CONTACT = 2;
        private DataTable allContacts;


        public Contacts()
        {
            allContacts = new DataTable();
            allContacts.Columns.Add("GUID", typeof(String));
            allContacts.Columns.Add("Name", typeof(String));
            allContacts.Columns.Add("DATA", typeof(ContactEntry));
        
        }

        public void ContactsFromRawData(byte[] rawData, bool debug)
        {
            int offset = OFFSET;
            for (int i = 0; i < MAX; i++)
            {
                //Console.WriteLine("Contacts: " + i);
                String hex;
                byte[] oneContactRaw = new byte[DATA_WIDTH];
                for (int j = 0; j < DATA_WIDTH; j++)
                {
                    byte value = rawData[offset + j];
                    oneContactRaw[j] = value;
                    if (debug)
                    {
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                }
                if (debug) Console.WriteLine();
                offset += DATA_WIDTH;
                ContactEntry ch = new ContactEntry();
                ch.RawData = oneContactRaw;
                AddContact(ch);
                if (debug)
                {
                    Console.WriteLine(ch.toString());
                    oneContactRaw = ch.RawData;
                    for (int j = 0; j < DATA_WIDTH; j++)
                    {
                        byte value = oneContactRaw[j];
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void AddContact(ContactEntry oneContact)
        {
            allContacts.Rows.Add(oneContact.GUID, oneContact.ContactName, oneContact);
        }
        private int IdConvInput(int id)
        {
            return id - 1;
        }
        private int IdConvOutput(int id)
        {
            return id + 1;
        }
        public ContactEntry getObjectById(int id)
        {
            return (ContactEntry)allContacts.Rows[IdConvInput(id)].ItemArray[CONTACT];
        }

        public ContactEntry getObjectByGUID(String guid)
        {
            DataRow[] result = allContacts.Select("GUID = '" + guid + "'");
            if (result != null)
                return (ContactEntry) result[0].ItemArray[CONTACT];
            return null;
        }
        
        public String getNameById(int id)
        {
            return (String)allContacts.Rows[IdConvInput(id)].ItemArray[NAME];
        }

        public String getGUIDById(int id)
        {
            return (String)allContacts.Rows[IdConvInput(id)].ItemArray[GUID];
        }

        public int getIdByGUID(String guid)
        {
            DataRow[] result = allContacts.Select("GUID = '" + guid + "'");
            if (result != null)
                return IdConvOutput(allContacts.Rows.IndexOf(result[0]));
            return -1;
        }

        public int getIdByName(String name)
        {
            DataRow[] result = allContacts.Select("Name = '" + name + "'");
            if (result != null)
                return IdConvOutput(allContacts.Rows.IndexOf(result[0]));
            return -1;
        }
    }
}
