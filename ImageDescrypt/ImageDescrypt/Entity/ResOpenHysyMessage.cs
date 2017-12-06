using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class ResOpenHysyMessage:Bean
    {
        private int _jifen;

        private int _allCount;

        private int _winCount;

        private int _dayCount;

        private int _nobilityLevel;

        private int _buyCount;

        private int _type;

        private int _newRank;
        override public void reading()
        {
            this._jifen = readInt();
            this._allCount = readInt();
            this._winCount = readInt();
            this._dayCount = readInt();
            this._nobilityLevel = readInt();
            this._buyCount = readInt();
            this._type = readInt();
            this._newRank = readInt();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_jifen={0};_allCount={1};_winCount={2};_dayCount={3};_nobilityLevel={4};_buyCount={5};_type={6};_newRank={7};"
            , _jifen, _allCount, _winCount, _dayCount, _nobilityLevel, _buyCount, _type, _newRank);

            return outstr;
        }

    }
}
