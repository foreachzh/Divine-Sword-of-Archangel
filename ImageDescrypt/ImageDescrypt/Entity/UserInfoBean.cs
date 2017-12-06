using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class UseInfoBean : Bean
    {
        public int itemModelId;

        public int hasUsed;

        public int hasGetValue;

        override public void reading()
        {
            this.itemModelId = readInt();
            this.hasUsed = readInt();
            this.hasGetValue = readInt();
        }
    }
}
