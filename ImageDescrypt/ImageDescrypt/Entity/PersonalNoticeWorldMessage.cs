using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class PersonalNoticeWorldMessage:Bean
    {
      private String _type;
      private String _content;
      private List<String> _values;
      private int _isAllShow;
      override public void reading()
      {
          this._type = readString();
          this._content = readString();
            _values = readObjList<string, string>();// readString();
          this._isAllShow = readByte();
      }

      public override string getPrintStr()
      {
          string outstr = string.Format("_type={0};_content={1};values.cnt={2}", _type, _content, _values.Count);
          return outstr;
      }
    }
}
