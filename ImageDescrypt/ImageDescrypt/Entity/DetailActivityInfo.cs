using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    class DetailActivityInfo:Bean
    {
      private int _activityId;
      
      private int _beginTime;
      
      private int _endTime;
      
      private String _condDesc;
      
      private List<ActivityItemInfo> _items;
      
      private String _otherInfo;
      override public void reading()
      {
          this._activityId = readInt();
          this._beginTime = readInt();
          this._endTime = readInt();
          this._condDesc = readString();
          this._items = readObjList<ActivityItemInfo, ActivityItemInfo>();// readBean() as ActivityItemInfo;

          this._otherInfo = readString();
      }

      public override string getPrintStr()
      {
          string outstr = string.Format("_activityId={0};_beginTime={1};_endTime={2};_condDesc={3};_items.cnt={4};"
          , _activityId, _beginTime, _endTime, _condDesc, _items.Count);

          return outstr;
      }
    }


    public class ActivityItemInfo : Bean
    {
        private String _condiction;

        private String _awardList;

        private int _canGet;
        override public void reading()
        {
            this._condiction = readString();
            this._awardList = readString();
            this._canGet = readByte();
        }
    }
}
