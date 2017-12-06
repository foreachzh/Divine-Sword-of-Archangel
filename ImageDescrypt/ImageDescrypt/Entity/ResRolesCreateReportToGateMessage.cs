using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDescrypt.Entity
{
    public class ResRolesCreateReportToGateMessage:Bean
    {
        private int _serverId;

        private int _createServerId;

        private String _userId;

        private LongC _playerId;

        private int _mapId;

        private String _playername;
        public override string getPrintStr()
        {
            string outstr = string.Format("_serverId={0};_createServerId={1};_userId={2};_playerId={3};_mapId={4};_playername={5};"
            , _serverId, _createServerId, _userId, _playerId.toString(), _mapId, _playername);

            return outstr;
        }

        public override void reading()
        {
            this._serverId = readInt();
            this._createServerId = readInt();
            this._userId = readString();
            this._playerId = readLong();
            this._mapId = readInt();
            this._playername = readString();
            // base.reading();
        }
    }
}
