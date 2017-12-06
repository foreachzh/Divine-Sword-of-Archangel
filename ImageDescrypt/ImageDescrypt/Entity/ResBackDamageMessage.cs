using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    class ResBackDamageMessage : ResAttackResultMessage
    {
        private int _back;
       override public void reading() 
      {
         base.reading();
         this._back = readInt();
      }

       public override string getPrintStr()
       {
           return base.getPrintStr();
       }
    }

    public class ResAttackResultMessage :Bean
   {
      private AttackResultInfo _state;
              
        override public void reading()
      {
          this._state = readBean<AttackResultInfo>();// as AttackResultInfo;
      }

        public override string getPrintStr()
        {
            return _state.getPrintStr();//base.getPrintStr();
        }
    }

    public class AttackResultInfo : Bean
    {
        private LongC _entityId;

        private LongC _sourceId;

        private int _skillId;

        private int _fightResult;

        private LongC _damage;

        private LongC _currentHP;

        private int _fightSpecialRes;
        override public void reading()
        {
            this._entityId = readLong();
            this._sourceId = readLong();
            this._skillId = readInt();
            this._fightResult = readByte();
            this._damage = readLong();
            this._currentHP = readLong();
            this._fightSpecialRes = readShort();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_entityId={0};_sourceId={1};_skillId={2};_fightResult={3};_damage={4};_currentHP={5};_fightSpecialRes={6};"
, _entityId.toString(), _sourceId.toString(), _skillId, _fightResult, _damage.toString(), _currentHP.toString(), _fightSpecialRes);

            return outstr;
        }
    }
}
