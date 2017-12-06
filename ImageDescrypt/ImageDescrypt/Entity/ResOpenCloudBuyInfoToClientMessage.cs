using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDescrypt.Entity
{
    public class ResOpenCloudBuyInfoToClientMessage:Bean
    {
        private int _cloudBuyID;

        private LongC _start;

        private LongC _end;

        private int _count;

        private int _mycount;

        private List<CloudBuyEventInfo> _cloudBuyEventInfoList;

        private List<ItemInfo> _itemInfoList;

        private int _isReward;

        private String _name;

        private int _lastCloudBuyID = 1;

        public int isHefu;

        public int activitenum;

        public String nameToral;

        public override string getPrintStr()
        {
            string outstr = string.Format("_cloudBuyID={0};_start={1};_end={2};_count={3};_mycount={4};_cloudBuyEventInfoList.cnt={5};_itemInfoList.cnt={6};_isReward={7};_name={8};_lastCloudBuyID = 1={9};isHefu={10};activitenum={11};nameToral={12};"
            , _cloudBuyID, _start.toString(), _end.toString(), _count, _mycount, _cloudBuyEventInfoList.Count, _itemInfoList.Count, _isReward, _name, _lastCloudBuyID = 1, isHefu, activitenum, nameToral);

            return outstr;
        }

        public override void reading()
        {
            this._cloudBuyID = readInt();
            this._start = readLong();
            this._end = readLong();
            this._count = readInt();
            this._mycount = readInt();
            _cloudBuyEventInfoList = readObjList<CloudBuyEventInfo, CloudBuyEventInfo>();
            _itemInfoList = readObjList<ItemInfo, ItemInfo>();
            this._isReward = readByte();
            this._name = readString();
            this._lastCloudBuyID = readInt();
            this.isHefu = readByte();
            this.activitenum = readInt();
            this.nameToral = readString();
            // base.reading();
        }
    }

    public class CloudBuyEventInfo : Bean
    {
        private LongC _eventId;

        private int _messageTime;

        private String _message;

        override public void reading()
        {
            this._eventId = readLong();
            this._messageTime = readInt();
            this._message = readString();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_eventId={0};_messageTime={1};_message={2};_messageTime={3};_message={4};"
            , _eventId.toString(), _messageTime, _message, _messageTime, _message);

            return outstr;
        }

    }
}
