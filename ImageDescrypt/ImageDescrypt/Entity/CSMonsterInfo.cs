using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class CSMonsterInfo:Bean
    {
      private LongC _monsterId;
      private int _monsterModelId;
      private String _monsterName;
      private String _monsterRes;
      private String _monsterIcon;
      private int _friend;
      private String _friendPara;
      private int _level;
      private int _mapId;
      private int _x;
      private int _y;
      private LongC _hp;
      private LongC _maxHp;
      private int _mp;
      private int _maxMp;
      private int _sp;
      private int _maxSp;
      private int _speed;
      private int _morph;
      private int _dir;
      private List<int> _positions=new List<int>();
      private List<CSBuffInfo> _buffs;

      override public void  reading()
      {
         //var _loc2_:int = 0;
         this._monsterId = readLong();
         this._monsterModelId = readInt();
         this._monsterName = readString();
         this._monsterRes = readString();
         this._monsterIcon = readString();
         this._friend = readByte();
         this._friendPara = readString();
         this._level = readInt();
         this._mapId = readInt();
         this._x = readShort();
         this._y = readShort();
         this._hp = readLong();
         this._maxHp = readLong();
         this._mp = readInt();
         this._maxMp = readInt();
         this._sp = readInt();
         this._maxSp = readInt();
         this._speed = readInt();
         this._morph = readInt();
         this._dir = readByte();
         _positions=readObjList<Byte, int>();
         _buffs = readObjList<CSBuffInfo, CSBuffInfo>();
      }

      public override string getPrintStr()
      {
          string outstr = string.Format("_monsterId={0};_monsterModelId={1};_monsterName={2};_monsterRes={3};_monsterIcon={4};_friend={5};_friendPara={6};_level={7};_mapId={8};_x={9};_y={10};_hp={11};_maxHp={12};_mp={13};_maxMp={14};_sp={15};_maxSp={16};_speed={17};_morph={18};_dir={19};_positions.cnt={20};_buffs.cnt={21};"
          , _monsterId.toString(), _monsterModelId, _monsterName, _monsterRes, _monsterIcon, _friend, _friendPara, _level, _mapId, _x, _y, _hp.toString(), _maxHp.toString(), _mp, _maxMp, _sp, _maxSp, _speed, _morph, _dir, _positions.Count, _buffs.Count);

          return outstr;
      }
    }

    public class CSBuffInfo : Bean
    {
      private LongC _buffId;
      private int _modelId;
      private int _total;
      private int _remain;
      private int _overlay;
      private int _value;
      private int _percent;

      private List<BuffPara> _buffparas;
        override public void reading()
      {
         this._buffId = readLong();
         this._modelId = readInt();
         this._total = readInt();
         this._remain = readInt();
         this._overlay = readInt();
         this._value = readInt();
         this._percent = readInt();
         _buffparas = readObjList<BuffPara, BuffPara>();
            /*
            var _loc1_:int = readShort();
         var _loc2_:int = 0;
         while(_loc2_ < _loc1_)
         {
            this._buffparas[_loc2_] = readBean(com.game.buff.bean.BuffPara) as com.game.buff.bean.BuffPara;
            _loc2_++;
         }
            */
      }
    }

    public class BuffPara : Bean
    {
      private int _type;
      private int _value;
      //        override public void writing()
      //        {
      //   writeByte(this._type);
      //   writeInt(this._value);
      //   return true;
      //}
      
      override public void reading()
      {
          int endpos = 0;
          this._type = ReadByte(_barr, _pos++);//readByte();
          this._value = readRawVarint32(_barr, _pos, ref endpos);//readInt();
          _pos = endpos;
      }
    }
}
