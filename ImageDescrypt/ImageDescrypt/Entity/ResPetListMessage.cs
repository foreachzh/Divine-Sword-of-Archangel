using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    class ResPetListMessage:Bean
    {
        private List<PetDetailInfo> _pets;
        public override void reading()
        {
            _pets = readObjList<PetDetailInfo, PetDetailInfo>();
            //base.reading();
        }
        public override string getPrintStr()
        {
            return "";
            // return base.getPrintStr();
        }
    }

    public class PetDetailInfo : Bean
    {
        private LongC _petId;

        private int _petModelId;

        private int _level;

        private int _hp;

        private int _maxHp;

        private int _mp;

        private int _maxMp;

        private int _sp;

        private int _maxSp;

        private int _speed;

        private int _showState;

        private int _dieTime;

        private int _htCount;

        private int _dayCount;

        private int _htCoolDownTime;

        private List<CSSkillInfo> _skillInfos;

        private List<PlayerAttributeItem> _htAddition;
        override public void reading()
        {
            this._petId = readLong();
            this._petModelId = readInt();
            this._level = readInt();
            this._hp = readInt();
            this._maxHp = readInt();
            this._mp = readInt();
            this._maxMp = readInt();
            this._sp = readInt();
            this._maxSp = readInt();
            this._speed = readInt();
            this._showState = readByte();
            this._dieTime = readInt();
            this._htCount = readInt();
            this._dayCount = readInt();
            this._htCoolDownTime = readInt();
            _skillInfos = readObjList<CSSkillInfo, CSSkillInfo>();
            _htAddition = readObjList<PlayerAttributeItem, PlayerAttributeItem>();
        }
    }
}
