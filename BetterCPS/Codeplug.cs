using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Channel;
using BetterCPS.Contact;
using BetterCPS.ScanList;
using BetterCPS.Zone;
using BetterCPS.RXGroup;

namespace BetterCPS
{
    
    class Codeplug
    {
        bool debug = false;
        byte[] rawData;
        Contacts allContacts;

        public Codeplug()
        {
            initCodeplug();
        }
        private void initCodeplug()
        {
            allContacts = new Contacts();
            allRXGroups = new RXGroups();
            allScanLists = new ScanLists();
            allZones = new Zones();
            allChannels = new Channels();
        }
        internal Contacts AllContacts
        {
            get { return allContacts; }
            set { allContacts = value; }
        }
        RXGroups allRXGroups;

        internal RXGroups AllRXGroups
        {
            get { return allRXGroups; }
            set { allRXGroups = value; }
        }
        ScanLists allScanLists;

        internal ScanLists AllScanLists
        {
            get { return allScanLists; }
            set { allScanLists = value; }
        }
        Zones allZones;

        internal Zones AllZones
        {
            get { return allZones; }
            set { allZones = value; }
        }
        Channels allChannels;

        internal Channels AllChannels
        {
            get { return allChannels; }
            set { allChannels = value; }
        }
        public void SetBaseRawData(byte[] data)
        {
            rawData = data;
        }
        public byte[] RawData
        {
            get {
                    setRawFromData();
                    return rawData; 
                }
            set { 
                    rawData = value;
                    setDataFromRaw(rawData);
                }
        }

        private void setRawFromData()
        {
            byte[] channelRawData = allChannels.RawDataFromChannels();
            Array.Copy(channelRawData, 0, rawData, Channels.OFFSET, channelRawData.Length);
            byte[] zoneRawData = allZones.RawDataFromZones();
            Array.Copy(zoneRawData, 0, rawData, Zones.OFFSET, zoneRawData.Length);
            byte[] scanListRawData = allScanLists.RawDataFromScanLists();
            Array.Copy(scanListRawData, 0, rawData, ScanLists.OFFSET, scanListRawData.Length);
            byte[] contactRawData = allContacts.RawDataFromContacts();
            Array.Copy(contactRawData, 0, rawData, Contacts.OFFSET, contactRawData.Length);
            

        }
        
        private void setDataFromRaw(byte[] data)
        {
            initCodeplug();
            allContacts.ContactsFromRawData(data, debug);

            allRXGroups.RXGroupsFromRawData(data, debug);

            allScanLists.ScanListsFromRawData(data, debug);

            allZones.ZonesFromRawData(data, debug);

            allChannels.ChannelsFromRawData(data, debug);
        }
    }
}
