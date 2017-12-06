using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDescrypt.Entity
{
    public class ResFashionInfoMessage:Bean
    {
        private int _level;

        private LongC _weaponid;

        private LongC _armorid;

        private LongC _exp;

        private List<ItemInfo> _body;

        private List<FashionGrid> _cloth;

        private List<FashionGrid> _foot;

        private List<FashionGrid> _shadow;

        private LongC _shadowid;

        private LongC _footid;

        private List<FashionGrid> _emblem;

        private LongC _emblemid;

        private List<FashionGrid> _weapon;
        public override string getPrintStr()
        {
            string outstr = string.Format("_level={0};_weaponid={1};_armorid={2};_exp={3};_body.cnt={4};_cloth.cnt={5};_foot.cnt={6};_shadow.cnt={7};_shadowid={8};_footid={9};_emblem.cnt={10};_emblemid={11};_weapon.cnt={12};"
            , _level, _weaponid.toString(), _armorid.toString(), _exp.toString(), _body.Count, _cloth.Count, _foot.Count, _shadow.Count, _shadowid.toString(), _footid.toString(), _emblem.Count, _emblemid.toString(), _weapon.Count);

            return outstr;
        }

        public override void reading()
        {
            int _loc2_ = 0;
            this._level = readShort();
            this._exp = readLong();
            _cloth = readObjList<FashionGrid, FashionGrid>();
            _weapon = readObjList<FashionGrid, FashionGrid>();
            this._weaponid = readLong();
            this._armorid = readLong();
            this._footid = readLong();
            _foot = readObjList<FashionGrid, FashionGrid>();
            this._shadowid = readLong();
            _shadow = readObjList<FashionGrid, FashionGrid>();
            _emblem = readObjList<FashionGrid, FashionGrid>();
            this._emblemid = readLong();
            // base.reading();
        }
    }

    public class FashionGrid : Bean
    {
        private List<ItemInfo> _fashions;

        override public void reading()
        {
            _fashions = readObjList<ItemInfo, ItemInfo>();
        }
    }
}
