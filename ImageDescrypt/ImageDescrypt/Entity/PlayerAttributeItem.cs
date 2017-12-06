using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class PlayerAttributeItem
    {
        public int type { get; set; }
        public LongC value { get; set; }
    }

    public class Position : Bean
    {
        public int _x { get; set; }
        public int _y { get; set; }
        public override void reading()
        {
            this._x = readShort();
            this._y = readShort();
        }

        public override string getPrintStr()
        {
            return string.Format("{0},{1}", _x, _y);
            // return base.getPrintStr();
        }
    }
}
