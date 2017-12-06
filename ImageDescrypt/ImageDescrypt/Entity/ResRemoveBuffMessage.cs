using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class ResRemoveBuffMessage:Bean
    {
        private LongC _personId;

        private int _fightState;

        private LongC _buffId;

        public int buffTarget;

        override public void reading()
        {
            this._personId = readLong();
            this._fightState = readInt();
            this._buffId = readLong();
            this.buffTarget = readInt();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_personId={0};_fightState={1};_buffId={2};buffTarget={3}",
                _personId.toString(), _fightState, _buffId.toString(), buffTarget);
            return outstr;
        }
    }
}
