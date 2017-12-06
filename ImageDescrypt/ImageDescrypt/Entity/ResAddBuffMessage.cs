using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDescrypt.Entity
{
    class ResAddBuffMessage:Bean
    {
        private LongC _personId;

        private LongC _sourceId;

        private int _fightState;

        private CSBuffInfo _buff;
        public override void reading()
        {
            this._personId = readLong();
            this._sourceId = readLong();
            this._fightState = readInt();
            this._buff = readBean<CSBuffInfo>();// as CSBuffInfo;
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_personId={0};_sourceId={1};_fightState={2};_buff={3};"
            , _personId.toString(), _sourceId.toString(), _fightState, _buff);

            return outstr;
        }
    }
}
