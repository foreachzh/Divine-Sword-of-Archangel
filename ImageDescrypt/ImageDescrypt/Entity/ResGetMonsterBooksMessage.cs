using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class ResGetMonsterBooksMessage : Bean
    {
        private List<int> _booksId;

        private int _level;

        private LongC _exp;

        private List<int> _equipIds;
        override public void reading()
        {
            _booksId = readObjList<int, int>();
            this._level = readInt();
            this._exp = readLong();
            _equipIds = readObjList<int, int>();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_booksId.cnt={0};_level={1};_exp={2};_equipIds.cnt={3};"
            , _booksId.Count, _level, _exp.toString(), _equipIds.Count);

            return outstr;
        }

    }
}
