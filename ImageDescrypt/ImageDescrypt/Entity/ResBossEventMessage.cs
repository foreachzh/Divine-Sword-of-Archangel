using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class ResBossEventMessage:Bean
    {
      private int _type;
      private List<BossEventInfo> _events;
      private List<PandoraEventInfo> _pandoraEvents;
      override public void  reading()       {
         this._type = readByte();
         this._events = readObjList<BossEventInfo, BossEventInfo>();
         this._pandoraEvents=  readObjList<PandoraEventInfo,PandoraEventInfo>();
      }

        public  override string getPrintStr()
      {
          string outstr = string.Format("_type={0};_events.cnt={1};_pandoraEvents.cnt={2}", _type, _events.Count, _pandoraEvents.Count);
          return outstr;
      }
    }

    public class BossEventInfo : Bean
    {
      private LongC _eventId;
      private String _playerName;
      private LongC _playerId;
      private int _bossMapId;
      private int _bossId;
      private ItemInfo _itemInfo;
      private int _type;
      private LongC _time;

    override public void reading()
    {
         this._eventId = readLong();
         this._playerName = readString();
         this._playerId = readLong();
         this._bossMapId = readInt();
         this._bossId = readInt();
         this._itemInfo = readBean<ItemInfo>();
         this._type = readByte();
         this._time = readLong();
      }

    public override string getPrintStr()
    {
        string outstr = string.Format("_eventId={0};_playerName={1};_playerId={2};_bossMapId={3};_itemInfo={4};_type={5};_time={6}",
            _eventId.toString(), _playerName, _playerId.toString(), _bossMapId, _itemInfo.ToString(), _type, _time.toString());
        return outstr;
    }
    }

    public class PandoraEventInfo : Bean
    {
      private LongC _eventId;
      private String _playerName;
      private LongC _playerId;
      private ItemInfo _itemInfo;
      private ItemInfo _pandoraInfo;
      private int _type;
      private LongC _time;

      override public void reading()
      {
         this._eventId = readLong();
         this._playerName = readString();
         this._playerId = readLong();
         this._itemInfo = readBean<ItemInfo>();// as ItemInfo;
         this._pandoraInfo = readBean<ItemInfo>();// as ItemInfo;
         this._type = readByte();
         this._time = readLong();
      }
    }
}
