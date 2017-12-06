using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class ResFightPostionBroadcastMessage:Bean
    {
        private LongC _fightId;

        private LongC _personId;

        private int _fightDirection;

        private int _fightType;

        private int _mapModelId;

        private int _line;

        private int _x;

        private int _y;

        override public void reading()
        {
            this._fightId = readLong();
            this._personId = readLong();
            this._fightDirection = readInt();
            this._fightType = readInt();
            this._mapModelId = readInt();
            this._line = readInt();
            this._x = readShort();
            this._y = readShort();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_fightId={0};_personId={1};"
                +"_fightDirection={2};_fightType={3};_mapModelId={4};_line={5};_x={6};_y={7};", 
                _fightId.toString(), _personId.toString(), _fightDirection, _fightType, _mapModelId, _line, _x, _y);

            return outstr;
        }
    }
}
