using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDescrypt.Entity
{
    class ResGuildInfoMessage:Bean
    {
        private List<int> _numList;

        private int _guildGird;

        private int _guildQuality;

        private int _group;

        private int _blessPoint;

        private int _allBlessPoint;

        public int _curBeishu;
        public override void reading()
        {
            _numList = readObjList<int, int>();
            this._guildGird = readInt();
            this._guildQuality = readInt();
            this._group = readInt();
            this._blessPoint = readInt();
            this._allBlessPoint = readInt();
            this._curBeishu = readInt();
            //base.reading();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_numList.cnt={0};_guildGird={1};_guildQuality={2};_group={3};_blessPoint={4};_allBlessPoint={5};_curBeishu={6};"
            , _numList.Count, _guildGird, _guildQuality, _group, _blessPoint, _allBlessPoint, _curBeishu);

            return outstr;
        }
    }
}
