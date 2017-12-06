using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class PersonalNoticeMessage:Bean
    {
      private String _type;
      private String _content;
      private int _subtype;
      private List<String> _values;
      private List<GoodsInfoRes> _goodsinfos;

      override public void reading() 
      {
         this._type = readString();
         this._content = readString();
         this._subtype = readInt();
        _values = readObjList<string,string>();
        _goodsinfos = readObjList<GoodsInfoRes, GoodsInfoRes>();
      }

      public override string getPrintStr()
      {
          string valuestr="";
          for (int i = 0; i < _values.Count; i++)
              valuestr += _values[i]+",";
          string goodstr="";
          for(int i = 0; i < _goodsinfos.Count; i++)
              goodstr += _goodsinfos[i]+",";

          string outstr = string.Format("_type={0};_content={1};_values.str={2};_goodsinfos.cnt={3}", _type, _content, valuestr, goodstr);
          return outstr;
      }
    }

    public class GoodsInfoRes : Bean
    {
      private int _queryType;
      private int _index;
      private ItemInfo _ItemInfo;
      private List<GemInfo> _geminfo;

      override public void reading()
      {
         this._queryType = readInt();
         this._index = readInt();
         this._ItemInfo = readBean<ItemInfo>();// as ItemInfo;
         _geminfo = readObjList<GemInfo, GemInfo>();
                  /*var _loc1_:int = readShort();
         var _loc2_:int = 0;
         while(_loc2_ < _loc1_)
         {
            this._geminfo[_loc2_] = readBean(GemInfo) as GemInfo;
            _loc2_++;
         }*/
      }
    }

    public class ItemInfo :Bean
    {
      private LongC _itemId;
      private int _itemModelId;
      private LongC _num;
      private int _gridId;
      private int _isbind;
      private int _intensify;
      private int _addAttributLevel;
      private int _attributs;
      private int _isFullAppend;
      private int _lostTime;
      private List<GoodsAttribute> _goodAttributes;
      private List<GoodsAttribute> _sealAttributes;
      private List<GoodsAttribute> _gemAttributes;
      private List<GoodsAttribute> _fumoAttributes;
      private List<GoodsAttribute> _rebirthAttributes;
      private String _rebirthAttributesAdvancedGroup;
      private List<GoodsAttribute> _wingRefineAttributes;
      private String _params;
      private int _fightNumber;
      private int _attributeCount;
      public int suitId;
      public int reborn_level;
      private int _canTrade;
      private int _elementType;
      public int level;
      public LongC exp;
      public int attack;
      public int attackSpeed;
      public int furypecent;
      public int transform;
      private int _matureTime;
      private int _beacomeState;
      private int _beacomeStateLostTime;
      private int _sevenwingvalue;
      private int _castSoulLevel;
      private int _castSoulExp;
      private List<String> _polishLevel;
      private int _polishTate1;
      private int _polishTate2;
      private int _polishTate3;
      public int transformSkillId;
      private List<Slot> _slots;
      private int _emblemlev;
      private LongC _emblemExp;
      private String _shenyin;

              override public void reading() 
      {
         int _loc2_ = 0;
         this._itemId = readLong();
         this._itemModelId = readInt();
         this._num = readLong();
         this._gridId = readInt();
         this._isbind = readByte();
         this._intensify = readInt();
         this._addAttributLevel = readByte();
         int _loc1_ = readShort();
         _loc2_ = 0;
        _goodAttributes = readObjList<GoodsAttribute,GoodsAttribute>();
         //while(_loc2_ < _loc1_)
         //{
         //   this._goodAttributes[_loc2_] = readBean(com.game.backpack.bean.GoodsAttribute) as com.game.backpack.bean.GoodsAttribute;
         //   _loc2_++;
         //}
         this._attributs = readByte();
        _sealAttributes=readObjList<GoodsAttribute,GoodsAttribute>();
         //int _loc3_ = readShort();
         //_loc2_ = 0;
         //while(_loc2_ < _loc3_)
         //{
         //   this._sealAttributes[_loc2_] = readBean(com.game.backpack.bean.GoodsAttribute) as com.game.backpack.bean.GoodsAttribute;
         //   _loc2_++;
         //}
         //int _loc4_ = readShort();
         //_loc2_ = 0;
         //while(_loc2_ < _loc4_)
         //{
         //   this._gemAttributes[_loc2_] = readBean(com.game.backpack.bean.GoodsAttribute) as com.game.backpack.bean.GoodsAttribute;
         //   _loc2_++;
         //}
        _gemAttributes=readObjList<GoodsAttribute,GoodsAttribute>();
        _fumoAttributes=readObjList<GoodsAttribute,GoodsAttribute>();
        _wingRefineAttributes = readObjList<GoodsAttribute,GoodsAttribute>();

         this._lostTime = readInt();
         this._params = readString();
         this._fightNumber = readInt();
         this._attributeCount = readInt();
         this.suitId = readInt();
         this.reborn_level = readByte();
         this._canTrade = readByte();
         this._elementType = readByte();
         int _loc7_ = readShort();
         _loc2_ = 0;
         _slots = readObjList<Slot,Slot>();//readBean(Slot) as Slot;

         this.level = readInt();
         this.exp = readLong();
         this.attack = readInt();
         this.attackSpeed = readInt();
         this.furypecent = readInt();
         this.transform = readByte();
         this.transformSkillId = readInt();
         this._matureTime = readInt();
         this._castSoulLevel = readInt();
         this._castSoulExp = readInt();
         String _loc8_ = readString();
         this._polishLevel = _loc8_.Split('_').ToList();
         this._polishTate1 = readInt();
         this._polishTate2 = readInt();
         this._polishTate3 = readInt();
         this._beacomeState = readInt();
         this._beacomeStateLostTime = readInt();
         this._sevenwingvalue = readInt();
            _rebirthAttributes=readObjList<GoodsAttribute,GoodsAttribute>();
         this._rebirthAttributesAdvancedGroup = readString();
         this._shenyin = readString();
         this._emblemlev = readInt();
         this._emblemExp = readLong();
      }
    }
    public class Slot :Bean
   {
      private int _elementType;
      private int _attType;
      private int _attValue;
      private int _startLevel;
      private int _startAdd;
      override public void reading() 
      {
         this._elementType = readByte();
         this._attType = readByte();
         this._attValue = readInt();
         this._startLevel = readInt();
      }
    }
    public class GoodsAttribute : Bean
   {
      private int _type;
      private int _value;
      override public void reading() 
      {
         this._type = readInt();
         this._value = readInt();
      }
      //override public void reading()
      //{
      //   this._type = readInt();
      //   this._value = readInt();
      //}
    }

    public class GemInfo:Bean
    {
      private LongC _id;
      private int _level;
      private int _type;
      private int _exp;
      private int _grid;
      private int _isact;
      public override void reading()
      {
          this._id = readLong();
          this._level = readByte();
          this._type = readByte();
          this._exp = readInt();
          this._grid = readByte();
          this._isact = readByte();
      }
    }
}
