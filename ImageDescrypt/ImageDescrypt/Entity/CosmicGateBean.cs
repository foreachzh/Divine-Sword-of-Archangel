using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    class CosmicGateBean:Bean
    {
        private int _mapId;

        private int _times;
        override public void reading()
        {
            this._mapId = readInt();
            this._times = readInt();
        }
    }
}
