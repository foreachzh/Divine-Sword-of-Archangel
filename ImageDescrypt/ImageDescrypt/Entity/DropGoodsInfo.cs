using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class DropGoodsInfo:Bean
    {
        private LongC _dropGoodsId;
      private int _itemModelId;
      private int _num;
      private List<LongC> _ownerId;
      private LongC _dropTime;
      private int _intensify;
      private int _attributs;
      private int _isFullAppend;
      private int _isFullStrength;
      private int _x;
      private int _y;
      private int _addition;
      private int _isNanOwner;

      override public void reading()
      {
         //var _loc1_:int = 0;
         this._dropGoodsId = readLong();
         this._itemModelId = readInt();
         this._num = readInt();
         _ownerId = readObjList<LongC, LongC>();
         /*
          var _loc2_:int = readShort();
         _loc1_ = 0;
         while(_loc1_ < _loc2_)
         {
            this._ownerId[_loc1_] = readLong();
            _loc1_++;
         }*/
         this._dropTime = readLong();
         this._intensify = readInt();
         this._attributs = readByte();
         this._isFullAppend = readByte();
         this._isFullStrength = readByte();
         this._x = readShort();
         this._y = readShort();
         this._addition = readByte();
         this._isNanOwner = readByte();
      }

       public string getShowInfo()
      {
          string oustr = string.Format("_dropGoodsId={0},{1};_itemModelId={2};_num={3};_ownerId.cnt={4};_ownerId.cnt={5};_dropTime={6};"
              +"_intensify={7};_attributs={8};_isFullAppend={9};_isFullStrength={10};pos({11},{12});_addition={13};_isNanOwner={14}",
              Convert.ToString(_dropGoodsId.high, 16),Convert.ToString(_dropGoodsId.low, 16), 
              _itemModelId, _num, _ownerId.Count,_ownerId.Count,Convert.ToString(_dropTime.high, 16), _intensify,
              _attributs, _isFullAppend,_isFullStrength, _x, _y, _addition, _isNanOwner);
          return oustr;
      }
    }
}
