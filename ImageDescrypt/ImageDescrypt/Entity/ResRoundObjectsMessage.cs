using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{

    class ResRoundObjectsMessage:Bean
    {
     private List<CSPlayerInfo> _player;
      private List<LongC> _playerIds;
      private List<CSMonsterInfo> _monster;
      private List<LongC> _monstersIds;
      private List<DropGoodsInfo> _goods;
      private List<LongC> _goodsIds;
      private List<PetInfo> _pets;
      private List<LongC> _petIds;
      private List<NpcInfo> _npcs;
      private List<LongC> _npcid;
      private List<EffectInfo> _Effect;
      private List<LongC> _effectid;
      private List<SummonPetInfo> _summonpets;
      private List<LongC> _summonpetIds;

      override public void reading()
      {
          _player = readObjList<CSPlayerInfo, CSPlayerInfo>();
          _playerIds = readObjList<LongC, LongC>();
          _monster = readObjList<CSMonsterInfo, CSMonsterInfo>();
          _monstersIds = readObjList<LongC, LongC>();
          _goods = readObjList<DropGoodsInfo, DropGoodsInfo>();
          _goodsIds = readObjList<LongC, LongC>();
          _pets = readObjList<PetInfo, PetInfo>();
          _petIds = readObjList<LongC, LongC>();
          _npcs = readObjList<NpcInfo, NpcInfo>();
          _npcid = readObjList<LongC, LongC>();
          _Effect = readObjList<EffectInfo, EffectInfo>();
          _effectid = readObjList<LongC, LongC>();
          _summonpets = readObjList<SummonPetInfo, SummonPetInfo>();
          _summonpetIds = readObjList<LongC, LongC>();
      }

      public override string getPrintStr()
      {
          string outstr = string.Format("_player.cnt={0};_playerIds.cnt={1};_monster.cnt={2};_monstersIds.cnt={3};_goods.cnt={4};_goodsIds.cnt={5};_pets.cnt={6};_petIds.cnt={7};_npcs.cnt={8};_npcid.cnt={9};_Effect.cnt={10};_effectid.cnt={11};_summonpets.cnt={12};_summonpetIds.cnt={13};"
          , _player.Count, _playerIds.Count, _monster.Count, _monstersIds.Count, _goods.Count, _goodsIds.Count, _pets.Count, _petIds.Count, _npcs.Count, _npcid.Count, _Effect.Count, _effectid.Count, _summonpets.Count, _summonpetIds.Count);

          return outstr;
      }
    }

    public class SummonPetInfo : Bean
    {
        private int _type;

        private int _weapon;

        private int _armor;

        private int _weaponStrength;

        private int _armorStrength;

        private LongC _petId;

        private int _petModelId;

        private LongC _ownerId;

        private String _ownerName;

        private int _level;

        private int _mapId;

        private int _x;

        private int _y;

        private int _hp;

        private int _maxHp;

        private int _mp;

        private int _maxMp;

        private int _sp;

        private int _maxSp;

        private int _speed;

        private int _dir;

        private List<int> _positions;

        private List<CSBuffInfo> _buffs;

        private int _sxstate;

        override public void reading()
        {
            this._petId = readLong();
            this._petModelId = readInt();
            this._ownerId = readLong();
            this._ownerName = readString();
            this._level = readInt();
            this._mapId = readInt();
            this._x = readShort();
            this._y = readShort();
            this._hp = readInt();
            this._maxHp = readInt();
            this._mp = readInt();
            this._maxMp = readInt();
            this._sp = readInt();
            this._maxSp = readInt();
            this._speed = readInt();
            this._dir = readByte();
            _buffs = readObjList<CSBuffInfo, CSBuffInfo>();
            this._sxstate = readByte();
            this._type = readInt();
            this._weapon = readInt();
            this._weaponStrength = readByte();
            this._armor = readInt();
            this._armorStrength = readByte();
        }
    }

    public class EffectInfo : Bean
    {
        private LongC _effectId;
        private int _effectModelId;
        private int _type;
        private int _x;
        private int _y;
        private int _play;
        private LongC _target;
        override public void reading()
        {
            this._effectId = readLong();
            this._effectModelId = readInt();
            this._type = readByte();
            this._x = readShort();
            this._y = readShort();
            this._play = readInt();
            this._target = readLong();
        }
    }

    public class PetInfo : Bean
    {
        private LongC _petId;

        private int _petModelId;

        private LongC _ownerId;

        private String _ownerName;

        private int _level;

        private int _mapId;

        private int _x;

        private int _y;

        private int _hp;

        private int _maxHp;

        private int _mp;

        private int _maxMp;

        private int _sp;

        private int _maxSp;

        private int _speed;

        private int _dir;

        private List<int> _positions;

        private List<CSBuffInfo> _buffs;

        private int _sxstate;

        override public void reading()
        {
            this._petId = readLong();
            this._petModelId = readInt();
            this._ownerId = readLong();
            this._ownerName = readString();
            this._level = readInt();
            this._mapId = readInt();
            this._x = readShort();
            this._y = readShort();
            this._hp = readInt();
            this._maxHp = readInt();
            this._mp = readInt();
            this._maxMp = readInt();
            this._sp = readInt();
            this._maxSp = readInt();
            this._speed = readInt();
            this._dir = readByte();
            _buffs = readObjList<CSBuffInfo, CSBuffInfo>();
            this._sxstate = readByte();
        }
    }

    public class CSPlayerInfo : Bean
   {
      private LongC _personId;
      private int _webvip;
      private String _name;
      private int _sex;
      private int _job;
      
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
      
      private int _state;
      
      private int _weapon;
      
      private int _weapon_other;
      
      private int _weaponStreng;
      
      private int _weaponStreng_other;
      
      private int _wing;
      
      private int _wingStreng;
      
      private int _armor;
      
      private int _avatar;
      
      private int _dir;
      
      private LongC _team;
      
      private LongC _guild;
      
      private String _guildName;
      
      private int _armyId;
      
      private int _armyPost;
      
      private String _armyName;
      
      private List<int> _positions;
      
      private List<CSBuffInfo> _buffs;
      
      private int _horseid;
      
      private int _horselevel;
      
      private int _horseweaponid;
      
      private int _dazuoState;
      
      private List<LongC> _sxpets;
      
      private LongC _sxroleid;
      
      private int _sxtargetx;
      
      private int _sxtargety;
      
      private int _ranklevel;
      
      private int _arrowid;
      
      private int _realmlevel;
      
      private int _hiddenweaponid;
      
      private int _horseduangu;
      
      private int _equipPetId;
      
      private int _attackspeed;
      
      private int _armorStreng;
      
      private int _allStrength;
      
      private int _csysKills;
      
      private int _pkValue;
      
      private LongC _sd;
      
      private LongC _maxSd;
      
      public int toptitleid;
      
      public int suitEffectCount;
      
      public List<int> suitEffectIds;
      
      public int magicBookLevel;
      
      public int magicBookStar;
      
      private int _isKingCity;
      
      private int _fashionweapon;
      
      private int _fashionarmor;
      
      private int _show;
      
      private int _beacomeState;
      
      private int _changeBirth;
      
      private int _angelEquips;
      
      private int _fashionfoot;
      
      private int _fashionshadow;
      
      private int _inDrink;
      
      private int _corpswarTeam;
      
      private int _magicCurseBombNum;
      
      private int _honorTitleLevel;
      
      private int _fashionEmblem;
      
      private int _isRebirthId;
      override public  void reading() 
      {
         int _loc2_ = 0;
         this._personId = readLong();
         this._webvip = readInt();
         this._name = readString();
         this._sex = readByte();
         this._job = readByte();
         this._level = readInt();
         this._mapId = readInt();
         this._x = readShort();
         this._y = readShort();
         this._hp = readLong();
         this._maxHp = readLong();
         this._mp = readInt();
         this._maxMp = readInt();
         this._sd = readLong();
         this._maxSd = readLong();
         this._sp = readInt();
         this._maxSp = readInt();
         this._speed = readInt();
         this._state = readInt();
         this._weapon = readInt();
         this._weaponStreng = readByte();
         this._weapon_other = readInt();
         this._weaponStreng_other = readByte();
         this._armor = readInt();
         this._armorStreng = readByte();
         this._wing = readInt();
         this._wingStreng = readByte();
         this._avatar = readInt();
         this._dir = readByte();
         this._team = readLong();
         this._guild = readLong();
         _positions= readObjList<Byte, int>();// readByte();
         _buffs = readObjList<CSBuffInfo, CSBuffInfo>();// readBean() as CSBuffInfo;

         this._horseid = readShort();
         this._horseweaponid = readShort();
         this._dazuoState = readByte();
         _sxpets = readObjList<LongC,LongC>(); //readLong();

         this._sxroleid = readLong();
         this._sxtargetx = readShort();
         this._sxtargety = readShort();
         this._ranklevel = readByte();
         this._arrowid = readInt();
         this._realmlevel = readInt();
         this._hiddenweaponid = readShort();
         this._horseduangu = readShort();
         this._equipPetId = readInt();
         this._attackspeed = readInt();
         this._guildName = readString();
         this._allStrength = readByte();
         this._csysKills = readInt();
         this._pkValue = readInt();
         this.toptitleid = readInt();
         this.suitEffectCount = readShort();
         
         this.suitEffectIds = readObjList<int,int>();

         this.magicBookStar = readInt();
         this.magicBookLevel = readInt();
         this._isKingCity = readByte();
         this._fashionweapon = readShort();
         this._fashionarmor = readShort();
         this._show = readByte();
         this._changeBirth = readByte();
         this._fashionfoot = readShort();
         this._fashionshadow = readShort();
         this._angelEquips = readByte();
         this._inDrink = readByte();
         this._armyPost = readByte();
         this._armyId = readInt();
         this._armyName = readString();
         this._beacomeState = readInt();
         this._corpswarTeam = readByte();
         this._horselevel = readInt();
         this._magicCurseBombNum = readByte();
         this._honorTitleLevel = readInt();
         this._isRebirthId = readByte();
         this._fashionEmblem = readShort();
      }

    }

    public class NpcInfo : Bean
    {
        private LongC _npcId;

        private int _npcModelId;

        private String _npcName;

        private String _npcRes;

        private String _npcIcon;

        private int _dir;

        private int _x;

        private int _y;

        private int _storehouseType;

        override public void reading()
        {
            this._npcId = readLong();
            this._npcModelId = readInt();
            this._npcName = readString();
            this._npcRes = readString();
            this._npcIcon = readString();
            this._dir = readByte();
            this._x = readShort();
            this._y = readShort();
            this._storehouseType = readInt();
        }
    }
}
