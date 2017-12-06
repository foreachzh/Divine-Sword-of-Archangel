using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    class CSHorseInfo:Bean
    {
        private int _layer;

        private int _curlayer;

        private int _status;

        private List<CSHorseSkillInfo> _skillinfolist;

        private List<EquipInfo> _horseequipinfo;

        private int _dayblessvalue;

        private int _hisblessvalue;

        private int _dayupnum;

        private int _hisupnum;

        private int _boxnum;

        private int _boxcdtime;

        private int _cdtimeyuanbao;

        private int _potential;

        private int _mixingbone;

        private int _horseexp;

        private int _huanhualayer;

        private List<HorseSpecSkin> _skinlist;
        public override string getPrintStr()
        {
            string outstr = string.Format("_layer={0};_curlayer={1};_status={2};_skillinfolist.cnt={3};_horseequipinfo.cnt={4};_dayblessvalue={5};_hisblessvalue={6};_dayupnum={7};_hisupnum={8};_boxnum={9};_boxcdtime={10};_cdtimeyuanbao={11};_potential={12};_mixingbone={13};_horseexp={14};_huanhualayer={15};"
            , _layer, _curlayer, _status, _skillinfolist.Count, _horseequipinfo.Count, _dayblessvalue, _hisblessvalue, _dayupnum, _hisupnum, _boxnum, _boxcdtime, _cdtimeyuanbao, _potential, _mixingbone, _horseexp, _huanhualayer);

            return outstr;
        }
        override public void reading()
        {
         this._layer = readShort();
         this._curlayer = readShort();
         this._status = readByte();
_skillinfolist = readObjList<CSHorseSkillInfo,CSHorseSkillInfo>();
_horseequipinfo = readObjList<EquipInfo,EquipInfo>();
         this._dayblessvalue = readInt();
         this._hisblessvalue = readInt();
         this._dayupnum = readShort();
         this._hisupnum = readShort();
         this._boxnum = readByte();
         this._boxcdtime = readInt();
         this._cdtimeyuanbao = readInt();
         this._potential = readInt();
         this._mixingbone = readShort();
         this._horseexp = readInt();
         this._huanhualayer = readInt();
        _skinlist = readObjList<HorseSpecSkin,HorseSpecSkin>();
        }
    }

    public class EquipInfo : Bean
    {
        private LongC _itemId;

        private int _itemModelId;

        private int _itemLevel;

        private int _addAttributLevel;

        private List<EquipAttribute> _itemAttributes;

        private List<EquipAttribute> _sealAttributes;

        private List<EquipAttribute> _gemAttributes;

        private List<EquipAttribute> _fumoAttributes;

        private List<EquipAttribute> _wingRefineAttributes;

        private List<EquipAttribute> _rebirthAttributes;

        private String _shenyin;

        private String _rebirthAttributesAdvancedGroup;

        private int _itemBind;

        private int _lostTime;

        private int _fightNumber;

        private int _attributeCount;

        public int suitId;

        public int reborn_level;

        public int transformSkillId;

        public int transform;

        private int _canTrade;

        private int _castSoulLevel;

        private int _castSoulExp;

        private List<string> _polishLevel;

        private int _beacomeState;

        private int _beacomeStateLostTime;

        private int _polishTate1;

        private int _polishTate2;

        private int _polishTate3;

        override public void reading()
        {
            int _loc2_ = 0;
            this._itemId = readLong();
            this._itemModelId = readInt();
            this._itemLevel = readInt();
            this._addAttributLevel = readByte();
            _itemAttributes = readObjList<EquipAttribute, EquipAttribute>();
            _sealAttributes = readObjList<EquipAttribute, EquipAttribute>();
            _gemAttributes = readObjList<EquipAttribute, EquipAttribute>();
            _fumoAttributes = readObjList<EquipAttribute, EquipAttribute>();
            _wingRefineAttributes = readObjList<EquipAttribute, EquipAttribute>();
            this._itemBind = readByte();
            this._lostTime = readInt();
            this._fightNumber = readInt();
            this._attributeCount = readInt();
            this.suitId = readInt();
            this.reborn_level = readByte();
            this.transform = readByte();
            this.transformSkillId = readInt();
            this._canTrade = readByte();
            this._castSoulLevel = readInt();
            this._castSoulExp = readInt();
            String _loc7_ = readString();
            this._polishLevel = _loc7_.Split('_').ToList();
            this._polishTate1 = readInt();
            this._polishTate2 = readInt();
            this._polishTate3 = readInt();
            this._beacomeState = readInt();
            this._beacomeStateLostTime = readInt();
            _rebirthAttributes = readObjList<EquipAttribute, EquipAttribute>();
            this._rebirthAttributesAdvancedGroup = readString();
            this._shenyin = readString();
        }
    }

    public class EquipAttribute : Bean
    {
        private int _attributeType;
        private int _attributeValue;
        override public void reading()
        {
            this._attributeType = readShort();
            this._attributeValue = readInt();
        }
    }

    public class HorseSpecSkin : Bean
    {
        private int _skinid;
        private int _losttime;
        override public void reading()
        {
            this._skinid = readInt();
            this._losttime = readInt();
        }
    }

    public class CSHorseSkillInfo : Bean
    {
        private int _skilllevel;

        private int _skillmodelid;

        private int _skillexp;
        override public void reading()
      {
         this._skilllevel = readShort();
         this._skillmodelid = readInt();
         this._skillexp = readInt();
      }
    }
}
