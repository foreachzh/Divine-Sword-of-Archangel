using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class ZoneTeamInfo:Bean
    {
        private int _zoneid;

        private int _clearancestatus;

        private int _enternum;

        private int _isopen;

        private LongC _last_time;

        private LongC _wait_time;

        private int _enterMaxnum;

        private int zoneType;

        private int _finishLevel;

        override public void reading()
        {
            this._zoneid = readInt();
            this._clearancestatus = readByte();
            this._enternum = readInt();
            this._isopen = readByte();
            this._last_time = readLong();
            this._wait_time = readLong();
            this._enterMaxnum = readInt();
            this._finishLevel = readByte();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_zoneid={0};_clearancestatus={1};_enternum={2};_isopen={3};_last_time={4};_wait_time={5};_enterMaxnum={6};zoneType={7};_finishLevel={8};"
            , _zoneid, _clearancestatus, _enternum, _isopen, _last_time.toString(), _wait_time.toString(), _enterMaxnum, zoneType, _finishLevel);

            return outstr;
        }

    }
}
