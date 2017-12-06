using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDescrypt.Entity
{
    public class SoulfactInfo : Bean
    {
        private int _id;

        private List<EquipInfo> _equips;

        private int _level;

        private int _type;

        private int _grid;
        public override void reading()
        {
            this._id = readByte();
            _equips = readObjList<EquipInfo, EquipInfo>();
            this._level = readByte();
            this._type = readByte();
            this._grid = readByte();
            // base.reading();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_id={0};_equips.cnt={1};_level={2};_type={3};_grid={4};"
            , _id, _equips.Count, _level, _type, _grid);

            return outstr;
        }
    }
}
