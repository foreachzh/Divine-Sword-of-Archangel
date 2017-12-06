using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDescrypt.Entity
{
    public class ResMatchTopInfosMessage : Bean
    {
        private int _season;

        private int _type;

        private List<PlayTopInfosBean> _list;

        private int _page;

        private int _allpage;

        private int _mytop;

        private int _mytopRank;

        public override void reading()
        {
            this._season = readInt();
            this._type = readInt();
            _list = readObjList<PlayTopInfosBean, PlayTopInfosBean>();
            this._page = readInt();
            this._allpage = readInt();
            this._mytop = readInt();
            this._mytopRank = readInt();
            // base.reading();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_season={0};_type={1};_list.cnt={2};_page={3};_allpage={4};_mytop={5};_mytopRank={6};"
            , _season, _type, _list.Count, _page, _allpage, _mytop, _mytopRank);

            return outstr;
        }

    }

    public class PlayTopInfosBean : Bean
    {
        private LongC _roleid;

        private String _rolename;

        private int _serverid;

        private LongC _fightpower;

        private int _job;

        private int _level;

        private String _web;

        private int _point;

        private List<EquipInfo> _equipInfolist;

        private int _winCount;

        private int _matchCount;

        private int _changeBirth;

        private int _escapeAliveNum;

        private int Victory1 = 0;

        private int Victory2 = 0;

        private int Victory3 = 0;

        private int Victory4 = 0;

        private int rank = 0;

        private String victory = "";

        private String round1 = "";

        private String round2 = "";

        private String round3 = "";

        private String round4 = "";

        private String rolename2 = "";

        private int job2;

        private String web2 = "";

        private List<EquipInfo> equipInfolist2;

        private String result = "";

        private int type = 0;

        private int _isRebirth;

        public override void reading()
        {
            this._roleid = readLong();
            this._rolename = readString();
            this._serverid = readInt();
            this._fightpower = readLong();
            this._job = readInt();
            this._level = readInt();
            this._web = readString();
            this._point = readInt();
            _equipInfolist = readObjList<EquipInfo, EquipInfo>();
            this._winCount = readInt();
            this._matchCount = readInt();
            this._changeBirth = readByte();
            this._escapeAliveNum = readInt();
            // base.reading();
        }

        public override string getPrintStr()
        {
            string outstr = string.Format("_roleid={0};_rolename={1};_serverid={2};_fightpower={3};_job={4};_level={5};_web={6};_point={7};_equipInfolist.cnt={8};_winCount={9};_matchCount={10};_changeBirth={11};_escapeAliveNum={12};Victory1 ={13};Victory2 ={14};Victory3 ={15};Victory4 ={16};rank ={17};victory =={18};round1 ={19};round2 ={20};round3 ={21};round4 ={22};rolename2 ={23};job2={24};web2 ={25};equipInfolist2.cnt={26};result ={27};type ={28};_isRebirth={29};"
            , _roleid.toString(), _rolename, _serverid, _fightpower.toString(), _job, _level, _web, _point, _equipInfolist.Count, _winCount, _matchCount, _changeBirth, _escapeAliveNum, Victory1, Victory2, Victory3, Victory4, rank, victory, round1, round2, round3, round4, rolename2, job2, web2, equipInfolist2.Count, result, type, _isRebirth);

            return outstr;
        }

    }
}
