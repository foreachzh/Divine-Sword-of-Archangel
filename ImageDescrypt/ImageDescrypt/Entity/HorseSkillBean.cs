using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class HorseSkillBean:Bean
    {
        private int _horseSkillId;

        private int _level;

        private int _islock;
        override public void reading()
        {
            this._horseSkillId = readInt();
            this._level = readByte();
            this._islock = readByte();
        }
    }
}
