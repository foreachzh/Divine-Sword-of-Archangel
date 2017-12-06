using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    class ShortCutInfo:Bean
    {
      private LongC _shortcutId;
      
      private int _shortcutType;
      
      private LongC _shortcutSource;
      
      private int _shortcutSourceModel;
      
      private int _shortcutGrid;
              override public void reading()
      {
         this._shortcutId = readLong();
         this._shortcutType = readInt();
         this._shortcutSource = readLong();
         this._shortcutSourceModel = readInt();
         this._shortcutGrid = readInt();
      }

    public override string getPrintStr()
    {
        string outstr = string.Format("_shortcutId={0};_shortcutType={1};_shortcutSource={2};_shortcutSourceModel={3};_shortcutGrid={4};"
        , _shortcutId.toString(), _shortcutType, _shortcutSource.toString(), _shortcutSourceModel, _shortcutGrid);

        return outstr;
    }
    }
}
