using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    class ResCharacterInfosMessage:Bean
    {
      private List<CharacterInfo> _characters;
      private int _typeMagicsword;
      private int _typeTutor;

      override public void reading()
      {
          this._characters = readObjList<CharacterInfo,CharacterInfo>() ;

          this._typeMagicsword = readByte();
          this._typeTutor = readByte();
      }

      public override string getPrintStr()
      {
          string outstr = string.Format("_characters={0};_characters.cnt={0};_typeMagicsword={1};_typeTutor={2};"
          , _characters.Count, _typeMagicsword, _typeTutor);

          return outstr;
      }
    }

    public class CharacterInfo : Bean
    {
        private LongC _playerId;

        private String _name;

        private int _level;

        private int _sex;

        private int _longintime;

        private int _jobKind;
        private int _changeBirth;
        override public void reading()
        {
            this._playerId = readLong();
            this._name = readString();
            this._level = readInt();
            this._sex = readByte();
            this._longintime = readInt();
            this._jobKind = readInt();
            this._changeBirth = readByte();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_playerId={0};_name={1};_level={2};_sex={3};_longintime={4};_jobKind={5};_changeBirth={6};"
            , _playerId.toString(), _name, _level, _sex, _longintime, _jobKind, _changeBirth);

            return outstr;
        }
    }
}
