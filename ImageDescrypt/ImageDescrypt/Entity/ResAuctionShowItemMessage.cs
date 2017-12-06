using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class ResAuctionShowItemMessage:Bean
    {
        private int _viplv;

        private int _viptype;

        private AuctionInfoBean _auctionInfo;

        private int _isKingCity;

        private int _honorTitleLevel;

        override public void reading()
        {
            this._viplv = readInt();
            this._viptype = readInt();
            this._auctionInfo = readBean < AuctionInfoBean>();
            this._isKingCity = readByte();
            this._honorTitleLevel = readInt();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_viplv={0};_viptype={1};_auctionInfo={2};_isKingCity={3};_honorTitleLevel={4}",
                _viplv, _viptype,_auctionInfo.ToString(),_isKingCity, _honorTitleLevel);
            return outstr;
            //return base.getPrintStr();
        }
    }

    public class AuctionInfoBean : Bean
    {
        private LongC _itemId;
        private LongC _roleId;
        private String _playerName;
        private String _itemName;
        private int _unitprice;
        private int _price;
        private ItemInfo _itemdata;
        private LongC _deleteTime;

        override public void reading()
        {
            this._itemId = readLong();
            this._roleId = readLong();
            this._playerName = readString();
            this._itemName = readString();
            this._unitprice = readInt();
            this._price = readInt();
            this._itemdata = readBean<ItemInfo>();
            this._deleteTime = readLong();
        }
    }
}
