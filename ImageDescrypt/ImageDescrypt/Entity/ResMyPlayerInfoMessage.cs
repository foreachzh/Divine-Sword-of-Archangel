using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDescrypt.Entity
{
    class ResMyPlayerInfoMessage:Bean
    {
        private LongC _personId;

        private String _name;

        private int _sex;

        private int _job;

        private int _level;

        private int _mapId;

        private int _x;

        private int _y;

        private int _skill;

        private int _skills;

        private int _state;

        private int _pkState;

        private LongC _exp;

        private LongC _peakednessExp;

        private LongC _eternalExp;

        private int _zhenqi;

        private int _prestige;

        private int _dir;

        private int _avatar;

        private List<PlayerAttributeItem> _attributes;

        private List<Position> _positions;

        private List<EquipInfo> _equips;

        private List<ItemInfo> _angelEquips;

        private int _cellnum;

        private int _storecellnum;

        private List<ItemInfo> _items;

        private int _cellTime;

        private int _gridId;

        private int _money;

        private int _gold;

        private int _bindgold;

        private int _nonage;

        private int _horseid;

        private int _horseweaponid;

        private int _hiddenweaponid;

        private List<PosGemInfo> _posallgeminfo;

        private int _maintaskId;

        private int _kingcitybuffid;

        private int _vipid;

        private int _LongCyuanlv;

        private int _LongCyuannum;

        private int _ranklevel;

        private ArrowInfo _arrowInfo;

        private int _webvip;

        private int _webvip2;

        private int _power;

        private int _agile;

        private int _horseduangu;

        private int _strength;

        private int _wit;

        private int _unallocatedTalent;

        private int _ice_attack;

        private int _ray_attack;

        private int _poison_attack;

        private int _ice_def;

        private int _ray_def;

        private int _poison_def;

        private int _gnore_attackPercent;

        private int _hit;

        private int _dodge;

        private int _hitPercent;

        private int _dodgePercent;

        private int _crit;

        private int _critPercent;

        private int _attackPercent;

        private int _physic_attackPercent;

        private int _magic_attackPercent;

        private int _Knowing_attackPercent;

        private int _fatal_blow;

        private int _physic_attackupper;

        private int _physic_attacklower;

        private int _magic_attackupper;

        private int _magic_attacklower;

        private int _ignore_attackPercent;

        private int _attack;

        private int _defense;

        private int _defensePercent;

        private LongC _teamId;

        private LongC _guild;

        private String _guildName;

        private int _armyId;

        private int _armyPost;

        private String _armyName;

        private int _beacomeState;

        private int _corpswarTeam;

        private int _gm;

        private LongC _createTime;

        private int _speed;

        private LongC _spirit;

        private int _pkValue;

        private List<LongC> _enemies;

        private int _firstWeiDuan;

        private int _config;

        private int topTitleId;

        private int suitEffectCount;

        private List<int> suitEffectIds;

        private int magicBookLevel;

        private int magicBookStar;

        private int jobLevel;

        private int _isKingCity;

        private int _fashionweapon;

        private int _fashionarmor;

        private int _fashionfoot;

        private int _fashionshadow;

        private int _openCorpsSkill;

        private int _hasUseMaster;

        public int vl360;

        private int vt360;

        private int _fashionEmblem;

        private int _show;

        private uint _changeBirth;

        public override string getPrintStr()
        {
            string outstr = string.Format("_maintaskId={0};_kingcitybuffid={1};_vipid={2};_LongCyuanlv={3};_LongCyuannum={4};_ranklevel={5};_arrowInfo={6};_webvip={7};_webvip2={8};_power={9};_agile={10};_horseduangu={11};_strength={12};_wit={13};_unallocatedTalent={14};_ice_attack={15};_ray_attack={16};_poison_attack={17};_ice_def={18};_ray_def={19};_poison_def={20};_gnore_attackPercent={21};_hit={22};_dodge={23};_hitPercent={24};_dodgePercent={25};_crit={26};_critPercent={27};_attackPercent={28};_physic_attackPercent={29};_magic_attackPercent={30};_Knowing_attackPercent={31};_fatal_blow={32};_physic_attackupper={33};_physic_attacklower={34};_magic_attackupper={35};_magic_attacklower={36};_ignore_attackPercent={37};_attack={38};_defense={39};_defensePercent={40};_teamId={41};_guild={42};_guildName={43};_armyId={44};_armyPost={45};_armyName={46};_beacomeState={47};_corpswarTeam={48};_gm={49};_createTime={50};_speed={51};_spirit={52};_pkValue={53};_enemies.cnt={54};_firstWeiDuan={55};_config={56};topTitleId={57};suitEffectCount={58};suitEffectIds.cnt={59};magicBookLevel={60};magicBookStar={61};jobLevel={62};_isKingCity={63};_fashionweapon={64};_fashionarmor={65};_fashionfoot={66};_fashionshadow={67};_openCorpsSkill={68};_hasUseMaster={69};vl360={70};vt360={71};_fashionEmblem={72};"
            , _maintaskId, _kingcitybuffid, _vipid, _LongCyuanlv, _LongCyuannum, _ranklevel, _arrowInfo, _webvip, _webvip2, _power, _agile, _horseduangu, _strength, _wit, _unallocatedTalent, _ice_attack, _ray_attack, _poison_attack, _ice_def, _ray_def, _poison_def, _gnore_attackPercent, _hit, _dodge, _hitPercent, _dodgePercent, _crit, _critPercent, _attackPercent, _physic_attackPercent, _magic_attackPercent, _Knowing_attackPercent, _fatal_blow, _physic_attackupper, _physic_attacklower, _magic_attackupper, _magic_attacklower, _ignore_attackPercent, _attack, _defense, _defensePercent, _teamId.toString(), _guild.toString(), _guildName, _armyId, _armyPost, _armyName, _beacomeState, _corpswarTeam, _gm, _createTime.toString(), _speed, _spirit.toString(), _pkValue, _enemies.Count, _firstWeiDuan, _config, topTitleId, suitEffectCount, suitEffectIds.Count, magicBookLevel, magicBookStar, jobLevel, _isKingCity, _fashionweapon, _fashionarmor, _fashionfoot, _fashionshadow, _openCorpsSkill, _hasUseMaster, vl360, vt360, _fashionEmblem);

            return outstr;
        }


        public override void reading()
        {
         int _loc11_ = 0;
         int _loc12_ = 0;
         int _loc13_ = 0;
         int _loc1_ = 0;
         this._personId = readLong();
         this._name = readString();
         this._sex = readInt();
         this._job = readInt();
         this._gm = readInt();
         this._createTime = readLong();
         this._level = readInt();
         this._mapId = readInt();
         this._x = readShort();
         this._y = readShort();
         this._skill = readByte();
         this._skills = readInt();
         this._state = readInt();
         this._pkState = readInt();
         this._exp = readLong();
         this._zhenqi = readInt();
         this._prestige = readInt();
         this._dir = readByte();
         this._avatar = readInt();
        _attributes = readObjList<PlayerAttributeItem,PlayerAttributeItem>();
        _positions = readObjList<Position,Position>();
        _equips = readObjList<EquipInfo,EquipInfo>();
         this._cellnum = readShort();
         this._storecellnum = readShort();
         _items = readObjList<ItemInfo,ItemInfo>();
         this._gridId = readShort();
         this._cellTime = readInt();
         this._money = readInt();
         this._gold = readInt();
         this._bindgold = readInt();
         this._spirit = readLong();
         this._nonage = readByte();
         this._horseid = readShort();
         this._horseweaponid = readShort();
         this._hiddenweaponid = readShort();
_posallgeminfo = readObjList<PosGemInfo,PosGemInfo>();
         this._maintaskId = readInt();
         this._kingcitybuffid = readInt();
         this._vipid = readInt();
         int _longyuanlv = readByte();
         int _longyuannum = readByte();
         this._ranklevel = readByte();
         this._arrowInfo = readBean<ArrowInfo>();// as ArrowInfo;
         this._webvip = readInt();
         this._webvip2 = readInt();
         this._horseduangu = readShort();
         this._power = readInt();
         this._strength = readInt();
         this._agile = readInt();
         this._wit = readInt();
         this._unallocatedTalent = readInt();
         this._teamId = readLong();
         this._guild = readLong();
         this._guildName = readString();
         this._pkValue = readInt();
          //  this._enemies.push(
            readLong();//);
         this._firstWeiDuan = readByte();
         this.topTitleId = readInt();
         //Array _loc9_ = [];
         //Array _loc10_ = [];
            _loc12_ = readInt();
            _loc13_ = readInt();
            //_loc9_.push(_loc12_);
            //_loc10_.push(_loc13_);
         //UserObj.getInstance().playerInfo.job = this._job;
         //MyTitleData.instance.initMyTitles(_loc9_,_loc10_);
         //MyTitleData.instance.topTitleId = this.topTitleId;
         // this.suitEffectIds = [];
            suitEffectIds = readObjList<int,int>();
         this._config = readInt();
         this.magicBookStar = readInt();
         this.magicBookLevel = readInt();
         int isInBlack = readByte();
         this.jobLevel = readByte();
         this._isKingCity = readByte();
         this._fashionweapon = readShort();
         this._fashionarmor = readShort();
         this._show = readByte();
         this._changeBirth = (uint)readByte();
         this._fashionfoot = readShort();
         this._fashionshadow = readShort();
         this.vl360 = readByte();
         this.vt360 = readByte();
        _angelEquips = readObjList<ItemInfo,ItemInfo>();
         this._peakednessExp = readLong();
         this._armyPost = readByte();
         this._armyId = readInt();
         this._armyName = readString();
         this._beacomeState = readInt();
         this._corpswarTeam = readByte();
         this._hasUseMaster = readByte();
         this._openCorpsSkill = readByte();
         this._fashionEmblem = readShort();
         this._eternalExp = readLong();
            // base.reading();
        }
    }

    public class PosGemInfo : Bean
    {
        private int _pos;

        private List<GemInfo> _geminfo;

        override public void reading()
        {
            this._pos = readByte();
            _geminfo = readObjList<GemInfo, GemInfo>();
            /*
            int _loc1_ = readShort();
            int _loc2_ = 0;
            while (_loc2_ < _loc1_)
            {
                this._geminfo[_loc2_] = readBean<GemInfo, GemInfo>();// as com.game.gem.bean.GemInfo;
                _loc2_++;
            }*/
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_pos={0};_geminfo.cnt={1};"
            , _pos, _geminfo.Count);

            return outstr;
        }

    }

    public class ArrowInfo : Bean
    {
        private int _arrowlv;
        private StarInfo _starinfo;
        private BowInfo _bowinfo;
        private List<FightSpiritInfo> _fightspiritList;
        override public void reading()
        {
            this._arrowlv = readInt();
            this._starinfo = readBean<StarInfo>();
            this._bowinfo = readBean<BowInfo>();
            _fightspiritList = readObjList<FightSpiritInfo, FightSpiritInfo>();
        }
    }


    public class StarInfo : Bean
    {
        private int _starmainlv;
        private int _starsublv;

        override public void reading()
        {
            this._starmainlv = readInt();
            this._starsublv = readInt();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_starmainlv={0};_starsublv={1};"
            , _starmainlv, _starsublv);

            return outstr;
        }
    }

    public class BowInfo : Bean
    {
        private int _bowmainlv;

        private int _bowsublv;

        override public void reading()
        {
            this._bowmainlv = readInt();
            this._bowsublv = readInt();
        }
    }

    public class FightSpiritInfo : Bean
    {
        private int _type;

        private int _num;
        override public void reading()
        {
            this._type = readInt();
            this._num = readInt();
        }
    }
}
