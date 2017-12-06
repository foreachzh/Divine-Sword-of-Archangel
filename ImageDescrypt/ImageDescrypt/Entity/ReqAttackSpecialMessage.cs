using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDescrypt.Entity
{
    class ReqAttackSpecialMessage:Bean
    {
        private List<long> _fightTargets= new List<long>();

        private List<int> _fightTypes=new List<int>();

        private int _fightType;

        private int _fightDirection;

        private int _mapModelId;

        private int _line;

        private int _x;

        private int _y;
        public override void reading()
        {
            this._fightType = readInt();
            this._fightDirection = readInt();
            this._mapModelId = readInt();
            this._line = readInt();
            this._x = readShort();
            this._y = readShort();
            //base.reading();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_fightTargets.cnt={0};_fightTypes.cnt={1};_fightType={2};_fightDirection={3};_mapModelId={4};_line={5};_x={6};_y={7};"
            , _fightTargets.Count, _fightTypes.Count, _fightType, _fightDirection, _mapModelId, _line, _x, _y);

            return outstr;
        }

    }
}
