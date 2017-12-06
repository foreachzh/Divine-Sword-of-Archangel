using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDescrypt.Entity
{
    class ResPokeFTInfoMessage:Bean
    {
        private LongC _pokeid;

        private int _hastrainnums;

        private LongC _trainstarttime;

        private int _trainlevel;

        private int _hasfightnums;
        public override string getPrintStr()
        {
            string outstr = string.Format("_pokeid={0};_hastrainnums={1};_trainstarttime={2};_trainlevel={3};_hasfightnums={4};"
            , _pokeid.toString(), _hastrainnums, _trainstarttime.toString(), _trainlevel, _hasfightnums);

            return outstr;
        }

        public override void reading()
        {
            this._pokeid = readLong();
            this._hastrainnums = readInt();
            this._trainstarttime = readLong();
            this._trainlevel = readInt();
            this._hasfightnums = readInt();
            // base.reading();
        }
    }
}
