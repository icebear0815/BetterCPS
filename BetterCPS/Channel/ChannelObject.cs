using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Contact;
using BetterCPS.RXGroup;
using BetterCPS.ScanList;
using BetterCPS.Zone;

namespace BetterCPS.Channel
{
    class ChannelObject
    {
        /*
         * Define CONST
         */
        public const int _GUID = 0;
        public const int _MODE = 1;
        public const int _NAME = 2;
        public const int _RXFREQ = 3;
        public const int _TXFREQ = 4;
        public const int _BANDWIDTH = 5;
        public const int _SCANLISTID = 6;
        public const int _SQUELCH = 7;
        public const int _RXREFFREQUENCY = 8;
        public const int _TXREFFREQUENCY = 9;
        public const int _TOT = 10;
        public const int _REKEYDELAY = 11;
        public const int _POWER = 12;
        public const int _ADMITCRITERIA = 13;
        public const int _AUTOSCAN = 14;
        public const int _RXONLY = 15;
        public const int _LONEWORKER = 16;
        public const int _VOX = 17;
        public const int _ALLOWTALKAROUNG = 18;
        public const int _ENCCTCSS = 19;
        public const int _DECCTCSS = 20;
        public const int _QTREVERSE = 21;
        public const int _RXSIGNALINGSYSTEM = 22;
        public const int _TXSIGNALINGSYSTEM = 23;
        public const int _REVERSEBURST = 24;
        public const int _DISPLAYPTTID = 25;
        public const int _DECODE1 = 26;
        public const int _DECODE2 = 27;
        public const int _DECODE3 = 28;
        public const int _DECODE4 = 29;
        public const int _DECODE5 = 30;
        public const int _DECODE6 = 31;
        public const int _DECODE7 = 32;
        public const int _DECODE8 = 33;
        public const int _PRIVATECALLCONFIRMED = 34;
        public const int _EMERGENCYCALLACK = 35;
        public const int _DATACALLCONFIRMED = 36;
        public const int _COMPRESSEDUPDHEADER = 37;
        public const int _EMERGENCYSYSTEMID = 38;
        public const int _CONTACTID = 39;
        public const int _GROUPLISTID = 40;
        public const int _COLORCODE = 41;
        public const int _PRIVACY = 42;
        public const int _PRIVACYNO = 43;
        public const int _REPEATERSLOT = 44;

        byte[] rawData;
        ChannelMode mode;

        internal ChannelMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        ChannelName name;

        internal ChannelName Name
        {
            get { return name; }
            set { name = value; }
        }
        RXFrequency rxFreq;
        TXFrequency txFreq;
        Bandwidth bandwidth;
        int scanListId;
        Squelch squelch;
        RxTxRefFrequency rxRefFrequency;
        RxTxRefFrequency txRefFrequency;
        TimeOutTimer tot;
        int rekeyDelay;
        TXPower power;
        AdmitCriteria admitCriteria;
        SimpleChannelParameter autoScan = new SimpleChannelParameter(0, 4);
        SimpleChannelParameter rxOnly = new SimpleChannelParameter(1, 1);
        SimpleChannelParameter loneWorker = new SimpleChannelParameter(0, 7);
        SimpleChannelParameter vox = new SimpleChannelParameter(4, 4);
        SimpleChannelParameter allowTalkAroung = new SimpleChannelParameter(1, 0);
        CTCSS encCTCSS;
        CTCSS decCTCSS;
        QTReverse qtReverse;
        SignalingSystem rxSignalingSystem;
        SignalingSystem txSignalingSystem;
        SimpleChannelParameter reverseBurst = new SimpleChannelParameter(4, 2);
        SimpleChannelParameter displayPTTId = new SimpleChannelParameter(3, 7, true);
        SimpleChannelParameter decode1 = new SimpleChannelParameter(14, 0);
        SimpleChannelParameter decode2 = new SimpleChannelParameter(14, 1);
        SimpleChannelParameter decode3 = new SimpleChannelParameter(14, 2);
        SimpleChannelParameter decode4 = new SimpleChannelParameter(14, 3);
        SimpleChannelParameter decode5 = new SimpleChannelParameter(14, 4);
        SimpleChannelParameter decode6 = new SimpleChannelParameter(14, 5);
        SimpleChannelParameter decode7 = new SimpleChannelParameter(14, 6);
        SimpleChannelParameter decode8 = new SimpleChannelParameter(14, 7);
        SimpleChannelParameter privateCallConfirmed = new SimpleChannelParameter(2, 6);
        SimpleChannelParameter emergencyCallAck = new SimpleChannelParameter(3, 3);
        SimpleChannelParameter dataCallConfirmed = new SimpleChannelParameter(2, 7);
        SimpleChannelParameter compressedUPDHeader = new SimpleChannelParameter(3, 6, true);
        int emergencySystemId;
        ContactId contactId;
        int groupListId;
        ColorCode colorCode;
        Privacy privacy;
        PrivacyNo privacyNo;
        RepeaterSlot repeaterSlot;
        private String guid;

        public ChannelObject()
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
                    return rawData; }
            set { 
                    rawData = value; 
                    setDataFromRawData();
                }
        }
        private int getBit(int offset, int bit)
        {
            int oneByte = rawData[offset];
            int mask = 0x01;
            mask = mask << bit;
            return (oneByte & mask)>0?1:0;
        }
        private void setBit(int value, int offset, int bit)
        {
            byte oneByte = rawData[offset];
            int mask = 0x01;
            mask = mask << bit;
            int tmpMask = ~mask;
            tmpMask &= value;
            oneByte |= (byte)tmpMask;
            rawData[offset] = oneByte;
        }
        private void initializeRawData()
        {
            rawData = new byte[] { 0x40, 0x00, 0x00, 0x20, 0x00, 0xC3, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xff, 0xff, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        }
        private void setRawDataFromData()
        {
            initializeRawData();

            //Mode	
            rawData = mode.toRaw(rawData);
            //ChannelName	
            rawData = name.toRaw(rawData);
            //RxFreq
            rawData = rxFreq.toRaw(rawData);
            //TxFreq
            rawData = txFreq.toRaw(rawData);
            //BW
            rawData = bandwidth.toRaw(rawData);
            //ScnLst
            rawData[11] = (byte)scanListId;
            //Sql
            rawData = squelch.toRaw(rawData);
            //RxRef
            rawData = rxRefFrequency.toRaw(rawData);
            //TxRef
            rawData = txRefFrequency.toRaw(rawData);
            //TOT
            rawData = tot.toRaw(rawData);
            //Rekey
            rawData[9] = (byte)rekeyDelay;
            //Power
            rawData = power.toRaw(rawData);
            //Admit
            rawData = admitCriteria.toRaw(rawData);
            //AScn
            rawData = autoScan.toRaw(rawData);
            //RxOnly
            rawData = rxOnly.toRaw(rawData);
            //Lone
            rawData = loneWorker.toRaw(rawData);
            //VOX
            rawData = vox.toRaw(rawData);
            //ATA
            rawData = allowTalkAroung.toRaw(rawData);
            //Enc			
            rawData = encCTCSS.toRaw(rawData);
            //Dec
            rawData = decCTCSS.toRaw(rawData);
            //QtRev
            rawData = qtReverse.toRaw(rawData);
            //RxSig
            rawData = rxSignalingSystem.toRaw(rawData);
            //TxSig
            rawData = txSignalingSystem.toRaw(rawData);
            //RBurst
            rawData = reverseBurst.toRaw(rawData);
            //PTTID
            rawData = displayPTTId.toRaw(rawData);
            //Dec1
            rawData = decode1.toRaw(rawData);
            //Dec2	
            rawData = decode2.toRaw(rawData);
            //Dec3	
            rawData = decode3.toRaw(rawData);
            //Dec4
            rawData = decode4.toRaw(rawData);
            //Dec5
            rawData = decode5.toRaw(rawData);
            //Dec6
            rawData = decode6.toRaw(rawData);
            //Dec7
            rawData = decode7.toRaw(rawData);
            //Dec8
            rawData = decode8.toRaw(rawData);
            //PCC	
            rawData = privateCallConfirmed.toRaw(rawData);
            //EAA
            rawData = emergencyCallAck.toRaw(rawData);
            //DCC
            rawData = dataCallConfirmed.toRaw(rawData);
            //UDP	
            rawData = compressedUPDHeader.toRaw(rawData);
            //ESyst	
            rawData[10] = (byte) emergencySystemId;
            //Contact
            rawData = contactId.toRaw(rawData);
            //GrpLst
            rawData[12] = (byte) groupListId;
            //Color
            rawData = colorCode.toRaw(rawData);
            //Priv
            rawData = privacy.toRaw(rawData);
            //PrivNo
            rawData = privacyNo.toRaw(rawData);
            //Slot
            rawData = repeaterSlot.toRaw(rawData);
        }
        private void setDataFromRawData()
        {
            //Mode	
            mode = ChannelMode.fromRaw(rawData);
            //ChannelName	
            name = ChannelName.fromRaw(rawData);
            //RxFreq
            rxFreq = RXFrequency.fromRaw(rawData);
            //TxFreq
            txFreq = TXFrequency.fromRaw(rawData);
            //BW
            bandwidth = Bandwidth.fromRaw(rawData);
            //ScnLst
            scanListId = rawData[11];
            //Sql
            squelch = Squelch.fromRaw(rawData);
            //RxRef
            rxRefFrequency = RxTxRefFrequency.fromRaw(rawData, RxTxRefFrequency.OFFSET_RX);
            //TxRef
            txRefFrequency = RxTxRefFrequency.fromRaw(rawData, RxTxRefFrequency.OFFSET_TX);
            //TOT
            tot = TimeOutTimer.fromRaw(rawData);
            //Rekey
            rekeyDelay = rawData[9];
            //Power
            power = TXPower.FromRaw(rawData);
            //Admit
            admitCriteria = AdmitCriteria.fromRaw(rawData);
            //AScn
            autoScan.fromRaw(rawData);
            //RxOnly
            rxOnly.fromRaw(rawData);
            //Lone
            loneWorker.fromRaw(rawData);
            //VOX
            vox.fromRaw(rawData);
            //ATA
            allowTalkAroung.fromRaw(rawData);
            //Enc			
            encCTCSS = CTCSS.fromRaw(rawData, CTCSS.OFFSET_ENC);				
            //Dec
            decCTCSS = CTCSS.fromRaw(rawData, CTCSS.OFFSET_DEC);
            //QtRev
            qtReverse = QTReverse.fromRaw(rawData);
            //RxSig
            rxSignalingSystem = SignalingSystem.fromRaw(rawData, SignalingSystem.OFFSET_RX);
            //TxSig
            txSignalingSystem = SignalingSystem.fromRaw(rawData, SignalingSystem.OFFSET_TX);
            //RBurst
            reverseBurst.fromRaw(rawData);
            //PTTID
            displayPTTId.fromRaw(rawData);
            //Dec1
            decode1.fromRaw(rawData);
            //Dec2	
            decode2.fromRaw(rawData);
            //Dec3	
            decode3.fromRaw(rawData);
            //Dec4
            decode4.fromRaw(rawData);
            //Dec5
            decode5.fromRaw(rawData);
            //Dec6
            decode6.fromRaw(rawData);
            //Dec7
            decode7.fromRaw(rawData);
            //Dec8
            decode8.fromRaw(rawData);
            //PCC	
            privateCallConfirmed.fromRaw(rawData);
            //EAA
            emergencyCallAck.fromRaw(rawData);
            //DCC
            dataCallConfirmed.fromRaw(rawData);
            //UDP	
            compressedUPDHeader.fromRaw(rawData);
            //ESyst	
            emergencySystemId = rawData[10];
            //Contact
            contactId = ContactId.fromRaw(rawData);
            //GrpLst
            groupListId = rawData[12];
            //Color
            colorCode = ColorCode.fromRaw(rawData);
            //Priv
            privacy = Privacy.fromRaw(rawData);
            //PrivNo
            privacyNo = PrivacyNo.fromRaw(rawData);
            //Slot
            repeaterSlot = RepeaterSlot.fromRaw(rawData);
        }

        public void SetDataFromCSV(String csvData, Contacts allContacts, RXGroups allRXGroups, ScanLists allScanLists, Zones allZones)
        {
            String[] allFields = csvData.Split(';');
            guid = allFields[_GUID];
            mode.fromString(allFields[_MODE]);
            name.Name = allFields[_NAME];
            rxFreq.FromString(allFields[_RXFREQ]);
            txFreq.FromString(allFields[_TXFREQ]);
            bandwidth.FromString(allFields[_BANDWIDTH]);
            scanListId = allScanLists.getIdByName(allFields[_SCANLISTID]);
            squelch.FromString(allFields[_SQUELCH]);
            rxRefFrequency.FromString(allFields[_RXREFFREQUENCY]);
            txRefFrequency.FromString(allFields[_TXREFFREQUENCY]);
            tot.FromString(allFields[_TOT]);
            rekeyDelay = Int32.Parse(allFields[_REKEYDELAY]);
            power.FromString(allFields[_POWER]);
            admitCriteria.FromString(allFields[_ADMITCRITERIA]);
            autoScan.FromString(allFields[_AUTOSCAN]);
            rxOnly.FromString(allFields[_RXONLY]);
            loneWorker.FromString(allFields[_LONEWORKER]);
            vox.FromString(allFields[_VOX]);
            allowTalkAroung.FromString(allFields[_ALLOWTALKAROUNG]);
            encCTCSS.FromString(allFields[_ENCCTCSS]);
            decCTCSS.FromString(allFields[_DECCTCSS]);
            qtReverse.FromString(allFields[_QTREVERSE]);
            rxSignalingSystem.FromString(allFields[_RXSIGNALINGSYSTEM]);
            txSignalingSystem.FromString(allFields[_TXSIGNALINGSYSTEM]);
            reverseBurst.FromString(allFields[_REVERSEBURST]);
            displayPTTId.FromString(allFields[_DISPLAYPTTID]);
            decode1.FromString(allFields[_DECODE1]);
            decode2.FromString(allFields[_DECODE2]);
            decode3.FromString(allFields[_DECODE3]);
            decode4.FromString(allFields[_DECODE4]);
            decode5.FromString(allFields[_DECODE5]);
            decode6.FromString(allFields[_DECODE6]);
            decode7.FromString(allFields[_DECODE7]);
            decode8.FromString(allFields[_DECODE8]);
            privateCallConfirmed.FromString(allFields[_PRIVATECALLCONFIRMED]);
            emergencyCallAck.FromString(allFields[_EMERGENCYCALLACK]);
            dataCallConfirmed.FromString(allFields[_DATACALLCONFIRMED]);
            compressedUPDHeader.FromString(allFields[_COMPRESSEDUPDHEADER]);
            emergencySystemId = "None".Equals(allFields[_EMERGENCYSYSTEMID])?0:Int32.Parse(allFields[_EMERGENCYSYSTEMID]);
            contactId.Value = allContacts.getIdByName(allFields[_CONTACTID]);
            groupListId = allRXGroups.getIdByName(allFields[_GROUPLISTID]);
            colorCode.FromString(allFields[_COLORCODE]);
            privacy.FromString(allFields[_PRIVACY]);
            privacyNo.FromString(allFields[_PRIVACYNO]);
            repeaterSlot.FromString(allFields[_REPEATERSLOT]);
        }
        public String ToString(Contacts allContacts, RXGroups allRXGroups, ScanLists allScanLists, Zones allZones)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append(guid);
            sb.Append(";");
            sb.Append(mode);
            sb.Append(";");
            sb.Append(name);
            sb.Append(";");
            sb.Append(rxFreq);
            sb.Append(";");
            sb.Append(txFreq);
            sb.Append(";");
            sb.Append(bandwidth);
            sb.Append(";");
            //sb.Append(scanListId);
            sb.Append(scanListId>0?allScanLists.getObjectById(scanListId).ScanListName:"None");
            sb.Append(";");
            sb.Append(squelch);
            sb.Append(";");
            sb.Append(rxRefFrequency);
            sb.Append(";");
            sb.Append(txRefFrequency);
            sb.Append(";");
            sb.Append(tot);
            sb.Append(";");
            sb.Append(rekeyDelay);
            sb.Append(";");
            sb.Append(power);
            sb.Append(";");
            sb.Append(admitCriteria);
            sb.Append(";");
            sb.Append(autoScan);
            sb.Append(";");
            sb.Append(rxOnly);
            sb.Append(";");
            sb.Append(loneWorker);
            sb.Append(";");
            sb.Append(vox);
            sb.Append(";");
            sb.Append(allowTalkAroung);
            sb.Append(";");
            sb.Append(encCTCSS);
            sb.Append(";");
            sb.Append(decCTCSS);
            sb.Append(";");
            sb.Append(qtReverse);
            sb.Append(";");
            sb.Append(rxSignalingSystem);
            sb.Append(";");
            sb.Append(txSignalingSystem);
            sb.Append(";");
            sb.Append(reverseBurst);
            sb.Append(";");
            sb.Append(displayPTTId);
            sb.Append(";");
            sb.Append(decode1);
            sb.Append(";");
            sb.Append(decode2);
            sb.Append(";");
            sb.Append(decode3);
            sb.Append(";");
            sb.Append(decode4);
            sb.Append(";");
            sb.Append(decode5);
            sb.Append(";");
            sb.Append(decode6);
            sb.Append(";");
            sb.Append(decode7);
            sb.Append(";");
            sb.Append(decode8);
            sb.Append(";");
            sb.Append(privateCallConfirmed);
            sb.Append(";");
            sb.Append(emergencyCallAck);
            sb.Append(";");
            sb.Append(dataCallConfirmed);
            sb.Append(";");
            sb.Append(compressedUPDHeader);
            sb.Append(";");
            sb.Append(emergencySystemId>0?"Unknwon":"None");
            sb.Append(";");
            //sb.Append(contactId);
            sb.Append(contactId.Value>0?allContacts.getObjectById(contactId.Value).ContactName:"None");
            sb.Append(";");
            //sb.Append(groupListId);
            sb.Append(groupListId>0?allRXGroups.getObjectById(groupListId).RXGroupName:"None");
            sb.Append(";");
            sb.Append(colorCode);
            sb.Append(";");
            sb.Append(privacy);
            sb.Append(";");
            sb.Append(privacyNo);
            sb.Append(";");
            sb.Append(repeaterSlot);

            return sb.ToString();
        }
        //Mode	ChannelName	RxFreq	TxFreq	BW	ScnLst	Sql	RxRef	TxRef	TOT	Rekey	Power	Admit	AScn	RxOnly	Lone	VOX	ATA	Enc	Dec	QtRev	RxSig	TxSig	RBurst	PTTID	Dec1	Dec2	Dec3	Dec4	Dec5	Dec6	Dec7	Dec8	PCC	EAA	DCC	UDP	ESyst	Contact	GrpLst	Color	Priv	PrivNo	Slot
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(guid);
            sb.Append(";");
            sb.Append(mode);
            sb.Append(";");
            sb.Append(name);
            sb.Append(";");
            sb.Append(rxFreq);
            sb.Append(";");
            sb.Append(txFreq);
            sb.Append(";");
            sb.Append(bandwidth);
            sb.Append(";");
            sb.Append(scanListId);
            sb.Append(";");
            sb.Append(squelch);
            sb.Append(";");
            sb.Append(rxRefFrequency);
            sb.Append(";");
            sb.Append(txRefFrequency);
            sb.Append(";");
            sb.Append(tot);
            sb.Append(";");
            sb.Append(rekeyDelay);
            sb.Append(";");
            sb.Append(power);
            sb.Append(";");
            sb.Append(admitCriteria);
            sb.Append(";");
            sb.Append(autoScan);
            sb.Append(";");
            sb.Append(rxOnly);
            sb.Append(";");
            sb.Append(loneWorker);
            sb.Append(";");
            sb.Append(vox);
            sb.Append(";");
            sb.Append(allowTalkAroung);
            sb.Append(";");
            sb.Append(encCTCSS);
            sb.Append(";");
            sb.Append(decCTCSS);
            sb.Append(";");
            sb.Append(qtReverse);
            sb.Append(";");
            sb.Append(rxSignalingSystem);
            sb.Append(";");
            sb.Append(txSignalingSystem);
            sb.Append(";");
            sb.Append(reverseBurst);
            sb.Append(";");
            sb.Append(displayPTTId);
            sb.Append(";");
            sb.Append(decode1);
            sb.Append(";");
            sb.Append(decode2);
            sb.Append(";");
            sb.Append(decode3);
            sb.Append(";");
            sb.Append(decode4);
            sb.Append(";");
            sb.Append(decode5);
            sb.Append(";");
            sb.Append(decode6);
            sb.Append(";");
            sb.Append(decode7);
            sb.Append(";");
            sb.Append(decode8);
            sb.Append(";");
            sb.Append(privateCallConfirmed);
            sb.Append(";");
            sb.Append(emergencyCallAck);
            sb.Append(";");
            sb.Append(dataCallConfirmed);
            sb.Append(";");
            sb.Append(compressedUPDHeader);
            sb.Append(";");
            sb.Append(emergencySystemId);
            sb.Append(";");
            sb.Append(contactId);
            sb.Append(";");
            sb.Append(groupListId);
            sb.Append(";");
            sb.Append(colorCode);
            sb.Append(";");
            sb.Append(privacy);
            sb.Append(";");
            sb.Append(privacyNo);
            sb.Append(";");
            sb.Append(repeaterSlot);
            
            return sb.ToString();
        }
    }
}
