using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class ResListAttackResultMessage : Bean
    {
      private LongC _sourceId;
      private int _skillId;
      private List<AttackResultInfos> _list;

      override  public void reading()
      {
         this._sourceId = readLong();
         this._skillId = readInt();
         _list = readObjList<AttackResultInfos, AttackResultInfos>();
         /*
          * var _loc1_:int = readShort();
         var _loc2_:int = 0;
         while(_loc2_ < _loc1_)
         {
            this._list[_loc2_] = readBean(AttackResultInfos) as AttackResultInfos;
            _loc2_++;
         }*/
      }

      public override string getPrintStr()
      {
          string outstr = string.Format("_sourceId={0};_skillId={1};_list.cnt={2}", 
              _sourceId.toString(), _skillId, _list.Count);
          return outstr;
          //return base.getPrintStr();
      }
    }

    public class AttackResultInfos : Bean
    {
      private LongC _entityId;
      private int _fightResult;
      private LongC _damage;
      private LongC _entityIdhp;
      private int _fightSpecialRes;

      override public void reading()
      {
         this._entityId = readLong();
         this._fightResult = readByte();
         this._damage = readLong();
         this._entityIdhp = readLong();
         this._fightSpecialRes = readShort();
      }

    override public string getPrintStr()
      {
          string outstr = string.Format("_entityId={0};_fightResult={1};damage={2};_entityIdhp={3};_fightSpecialRes={4}",
              _entityId.toString(), _fightResult, _damage.toString(), _entityIdhp.toString(), _fightSpecialRes);
          return outstr;
      }
    }
}
