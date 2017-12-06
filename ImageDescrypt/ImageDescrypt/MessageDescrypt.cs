using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XRFAppPlat.Logger;
using ImageDescrypt.Entity;

namespace ImageDescrypt
{
    public class MessageDescrypt
    {
        public static List<String> DecodeRecv(byte[] barr)
        {
            int ncurpos = 0;
            List<string> lst = new List<string>();
            while (ncurpos < barr.Length)
            {
                string retstr = DecodeMsg2(barr, ref ncurpos);
                lst.Add(retstr);
            }
            string str = "";
            for (int i = 0; i < lst.Count; i++)
            {
                str += lst[i] + "\r\n";
            }
            ConsoleLog.Instance.writeInformationLog(str);

                return lst;
        }

        public static byte[] GetPreCompleteMsg(List<byte[]> arrlist, int nLen, int nCurIndex)
        {
            // 拼接 解析报文
            // 向前搜索1
            // 搜索到之后 准备缓冲区;
            // 逐条字节流拷贝
            int nTempLen = 0;
            for (int j = nCurIndex; j >= 0; j--)
            {
                byte[] barr2 = arrlist[j];
                if ((int)(barr2[0] |barr2[1] << 8) == 1)
                {
                    byte[] barr3 = new byte[nLen];// 开辟缓冲区
                    for (int k = j; k <= nCurIndex; k++)
                    {
                        byte[] btemparr = arrlist[k];
                        Array.Copy(btemparr, 0, barr3, nTempLen, btemparr.Length);
                        nTempLen += btemparr.Length;
                    }
                    return barr3;
                }
            }
            return null;
        }

        public static List<string> DecodeLongMsg(List<byte[]> arrlist)
        {
            List<string> strlst = new List<string>();
            int nLen = 0;
            List<byte[]> temparr = new List<byte[]>();
            for (int i = 0; i < arrlist.Count; i++)
            {
                byte[] barr = arrlist[i];
                
                if ((barr[0] | barr[1] << 8) == 1)
                {
                   byte[] cmpMsg =  GetPreCompleteMsg(arrlist, nLen, i - 1);
                    if(cmpMsg != null)
                       temparr.Add(cmpMsg);
                    nLen = barr.Length;
                }
                else
                    nLen += barr.Length;
            }
            //
            byte[] cmpMsg1 = GetPreCompleteMsg(arrlist, nLen, arrlist.Count-1);
            if (cmpMsg1 != null)
                temparr.Add(cmpMsg1);

            
            byte[] arrTotal = new byte[nLen];
            nLen = 0;
            for (int i = 0; i < temparr.Count; i++)
            {
                byte[] barr = temparr[i];
                List<string> lst = DecodeRecv(barr);
                strlst.AddRange(lst);
                //nLen += barr.Length;
                //Array.Copy(barr, 0, arrTotal, nLen, barr.Length);
            }
            //strlst = DecodeRecv(arrTotal);
            // int nCurPos = 0;
            // DecodeMsg2(arrTotal, ref nCurPos);

            return strlst;
        }

        public static List<String> DecodeRecv2(byte[] barr)
        {
            int ncurpos = 0;
            List<byte[]> blist = new List<byte[]>();
            List<string> lst = new List<string>();

            while (ncurpos < barr.Length)
            {
                // 代表是否有后续报文 (int)(barr[ncurpos + 1] << 16) + (int)(barr[ncurpos + 0] << 24)
                int nbarrLen = (int)barr[ncurpos + 3] + (int)(barr[ncurpos + 2] << 8) ;
                if (nbarrLen > barr.Length)
                {
                    lst.Add("报文太长,超出本身范围");
                    break;
                }
                byte[] barr2 = new byte[nbarrLen+4] ;
                Array.Copy(barr, ncurpos, barr2, 0, nbarrLen + 4);
                blist.Add(barr2);
                //// 切割字节流数组 再解析
                ncurpos +=4 + nbarrLen;
            }
            string str = "";
            for (int i = 0; i < blist.Count; i++)
            {
                ncurpos = 0;
                string retstr = DecodeMsg2(blist[i],ref ncurpos);
                lst.Add(retstr);
                str += retstr + "\r\n";
            }
            ConsoleLog.Instance.writeInformationLog(str);

            return lst;
        }
        private static string DecodeMsg2(byte[] barr, ref int curpos)
        {
            try{
                if (barr.Length < 4)
                {
                    curpos = barr.Length;
                    return "Len too short";
                }
            int nbarrLen = (int)barr[curpos + 3] + (int)(barr[curpos + 2] << 8) + (int)(barr[curpos + 1] << 16) + (int)(barr[curpos + 0] << 24);
            if (nbarrLen > barr.Length - curpos - 4 || nbarrLen < 0)
            {
                byte[] temparr = new byte[barr.Length-curpos];
                Array.Copy(barr, curpos, temparr, 0, temparr.Length);
                string str = Int2Hexstring(temparr);
                curpos = barr.Length;
                return "Len error;"+str;
            }

            int nCmd = (int)barr[curpos + 7] + (int)(barr[curpos + 6] << 8) + (int)(barr[curpos + 5] << 16) + (int)(barr[curpos + 4] << 24);
            if (nCmd == 0)
            {
                curpos = barr.Length;
                return "Errror Cmd";
            }

            int endpos = 0;
            string outstr = "";
            Cmd xcmd = m_list.Find(x => x.cmd == nCmd);
            string cmdstr = "cmd:" + nCmd + ";";
            if (xcmd != null)
                cmdstr = string.Format("cmd={0};{1};", xcmd.cmd, xcmd.cmdStr);

            Bean item = new Bean() { _barr = barr, _pos = curpos + 8 };
            #region switchbegin
            switch (nCmd)
            {// 问题:前面自动练级的逻辑在哪里？

                case 100314:
                    {
                        ResRolesCreateReportToGateMessage tt = new ResRolesCreateReportToGateMessage() { _barr = barr, _pos = item._pos };
                        tt.reading();
                        item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 504000://,ResMapBossInfoMessage
                    {
                        List<int> _bossIds = item.readObjList<int, int>();
                        List<int> _bossReviveTime = item.readObjList<int, int>();
                        string printstr="bossIds:";
                        for (int i = 0; i < _bossIds.Count; i++)
                            printstr += _bossIds[i] + " ";
                        printstr += "\r\n";
                        for (int i = 0; i < _bossReviveTime.Count; i++)
                            printstr += _bossReviveTime[i] + " ";
                        outstr = printstr;
                    }break;
                case 101120:// cmdStr = "ResEnterMapMessage
                    {
                        int _line = item.readInt();
                        Position _pos = item.readBean<Position>();// as ;
                        outstr = string.Format("{0}线;Pos:({1})",_line, _pos.getPrintStr());
                    }break;
                case 540059://,ResGuildInfoMessage
                    {
                        ResGuildInfoMessage tt = new ResGuildInfoMessage() { _barr = barr, _pos = item._pos };
                        tt.reading();
                        item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 104109:
                    {
                        int _cellId = item.readInt();
                        int _timeRemaining = item.readInt();
                        outstr = string.Format("_cellId={0};_timeRemaining={1}", _cellId, _timeRemaining);
                    }
                    break;
                case 525065:// cmdStr = "ResCosmicGateLoginMssage
                    {
                        List<CosmicGateBean> lst = item.readObjList<CosmicGateBean, CosmicGateBean>();
                        outstr = string.Format("lst.len={0}", lst.Count);
                    }break;
                case 127201:// cmdStr = "ResFightPowerToClientMessage
                    {
                        LongC _fightPower = item.readLong();
                        outstr = string.Format("_fightPower={0}", _fightPower.toString());
                    }
                    break;
                case 525009:// cmdStr = "
                    {
                        ResGetMonsterBooksMessage tt = new ResGetMonsterBooksMessage() { _barr = barr, _pos = item._pos };
                        tt.reading();
                        item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 527035:// cmdStr = "ResNewAttributeItemUseInfo
                    {
                        List<UseInfoBean> useFuritInfo = item.readObjList<UseInfoBean, UseInfoBean>();
                        outstr = string.Format("useFuritInfo.cnt="+useFuritInfo.Count);
                    }break;
                case 104212:// cmdStr = "ResTakeUpSuccessMessage
                    {
                        LongC _goodsId = item.readLong();
                        int _goodModelId = item.readInt();
                        int _effectType = item.readInt();
                        int _effectValue = item.readInt();
                        int _num = item.readInt();
                        outstr = string.Format("_goodsId={0};_goodModelId={1};_effectType={2};_effectValue={3};_num={4};"
                            , _goodsId.toString(), _goodModelId, _effectType, _effectValue, _num);

                    }break;
                case 525003:// cmdStr = "ResBackDamageMessage
                    {
                        ResBackDamageMessage tt = new ResBackDamageMessage() { _barr = barr, _pos = item._pos }; ;
                        tt.reading();
                        item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 108102:// cmdStr = "ShortCutAddMessage
                    {
                        ShortCutInfo _shortcut = item.readBean<ShortCutInfo>();
                        outstr = _shortcut.getPrintStr();
                    }break;
                case 150203:// cmdStr = "ResRetreatInfoM"
                    {
                        int _notifyType = item.readInt();
                        int _curTime = item.readInt();
                        LongC curExp = item.readLong();
                        int _curZhenqi = item.readInt();
                        outstr = string.Format("_notifyType={0};_curTime={1};_curExp={2};_curZhenqi={3};"
                        , _notifyType, _curTime, curExp.toString(), _curZhenqi);
                    }
                    break;
                case 101124:// cmdStr = "ResSendLinesMessage" });
                    {
                        List<int> _lines = item.readObjList<int, int>();
                        int _loc3_ = item.readShort();// ???
                        List<int> _numbers = item.readObjList<int, int>();
                        outstr = string.Format("lines.cnt={0};num.cnt={1}", _lines.Count, _numbers.Count);
                    }break;
                case 104107:// cmdStr = "ResUseItemSuccessMessage
                    {
                        int _itemId = item.readInt();
                        outstr = string.Format("_itemId={0}", _itemId);
                    }break;
                case 525066:// cmdStr = "ResBuyFastestMessage
                    {
                        int _mapid = item.readInt();
                        int _buyTimes = item.readInt();
                        outstr = string.Format("_mapid={0};_buyTimes={1}", _mapid, _buyTimes);
                    }break;
                case 529114:// cmdStr = "ResUpdateCloudBuyToClientMessage
                    {
                        int _status = item.readByte();
                        int isHefu = item.readByte();
                        outstr = string.Format("_status={0};isHefu={2}", _status, isHefu);
                    }break;
                case 110101:// cmdStr = "ResPetListMessage"
                    {
                        List<PetDetailInfo> _pets = item.readObjList<PetDetailInfo, PetDetailInfo>();
                        outstr = string.Format("_pets.cnt={0}", _pets.Count);
                    }break;
                case 126101:// cmdStr = "ResHorseInfoMessage
                    {
                        LongC _playerid = item.readLong();
                        CSHorseInfo _horseinfo = item.readBean<CSHorseInfo>();
                        outstr = string.Format("_playerid={0};_horseinfo={1}", _playerid, _horseinfo.getPrintStr());
                    }break;
                case 128110:// cmdStr = "ResZoneLifeTimeMessage"
                    {
                        int _surplustime = item.readInt();
                        int _zoneid = item.readInt();
                        int _phase = item.readInt();
                        int _playercount = item.readInt();
                        int _type = item.readInt();
                        int _enterMode = item.readInt();
                        outstr = string.Format("_surplustime={0};_zoneid={1};_phase={2};_playercount={3};_type={4};_enterMode={5};", 
                            _surplustime, _zoneid, _phase, _playercount, _type, _enterMode);
                    }break;
                case 560001:// cmdStr = "ResGetHorseSkillMessage" });
                    {
                        LongC _playerId = item.readLong();
                        List<HorseSkillBean> list = item.readObjList<HorseSkillBean, HorseSkillBean>();
                        outstr = string.Format("_playerId={0};lst.HorseSkillBean.cnt={1}", _playerId, list.Count);//            item._pos = tt._pos;
                    }break;
                case 103130:// cmdStr = "ResScriptCommonPlayerToClientMessage"
                    {
                        int _scriptid = item.readInt();
                        int _type = item.readInt();
                        string _messageData = item.readString();
                        outstr = string.Format("_scriptid={0};_type={1};_messageData={2};", _scriptid, _type, _messageData);
                    }break;
                case 103110:// cmdStr = "ResPlayerMaxMpChangeMessage
                    {
                        LongC _personId = item.readLong();
                        int _currentMp = item.readInt();
                        int _maxMp = item.readInt();
                        outstr = string.Format("_personId={0};_currentMp={1};_maxMp={2};", _personId.toString(), _currentMp, _maxMp);
                    }break;
                case 103891:// cmdStr = "ResChangeOneAttributeMessage
                    {
                        int _endValue = item.readInt();
                        int _strength = item.readInt();
                        int _vitality = item.readInt();
                        int _agile = item.readInt();
                        int _intelligence = item.readInt();
                        int _restPlusPoint = item.readInt();
                        outstr = string.Format("_endValue={0};_strength={1};_agile={2};"
                            +"_vitality={3};_intelligence={4};_restPlusPoint={5};"
                        , _endValue, _strength, _agile, _vitality, _intelligence, _restPlusPoint);
                    }break;
                case 104104:// cmdStr = "ResItemRemoveMessage
                    {
                        LongC _itemId = item.readLong();
                        outstr = string.Format("_itemId={0}", _itemId);
                    }break;
                case 104102:// cmdStr = "ResItemAddMessage"
                    {
                        ItemInfo _item = item.readBean<ItemInfo>();
                        int _reason = item.readByte();
                        outstr = string.Format("_item={0};_reason={1};", _item.ToString(), _reason);
                    }break;
                case 102105:// cmdStr = "ResFightFailedBroadcastMessage
                    {
                        LongC _fightId = item.readLong();
                        LongC _personId = item.readLong();
                        int _fightDirection = item.readInt();
                        int _fightType = item.readInt();
                        LongC _fightTarget = item.readLong();
                        outstr = string.Format("_fightId={0};_personId={1};_fightDirection={2};_fightType={3};_fightTarget={4};"
                            , _fightId.toString(), _personId.toString(), _fightDirection, _fightType, _fightTarget.toString());
                    }break;
                case 101116:// cmdStr = "ResPlayerStopMessage" });
                    {
                        LongC _personId = item.readLong();
                        Position _position = item.readBean<Position>();// as Position;
                        int _mapModelId = item.readInt();
                        outstr = string.Format("_personId={0};_position={1};_mapModelId={2};"
                            , _personId.toString(), _position, _mapModelId);
                    }break;
                case 141101://, cmdStr = "ResMonsterBatterToClientMessage
                    {
                        int _type = item.readByte();
                        int _countdowntime = item.readInt();
                        int _lev = item.readInt();
                        int _num = item.readInt();
                        outstr = string.Format("_type={0};_countdowntime={1};_lev={2};_num={3};"
                            , _type, _countdowntime, _lev, _num);
                    }break;
                case 104105://, cmdStr = "ResMoneyChangeMessage
                    {
                        int _money = item.readInt();
                        outstr = string.Format("_money={0};", _money);
                    }break;
                case 526017://, cmdStr = "ResOpenHysyMessage
                    {
                        ResOpenHysyMessage tt = new ResOpenHysyMessage() { _barr = barr, _pos = item._pos }; ;
                        tt.reading();
                        item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 511009://, cmdStr = "ResRemoveActivityMessage
                    {
                        int _activityId = item.readInt();
                        outstr = string.Format("_activityId={0}", _activityId);
                    }break;
                case 120102://, cmdStr = "ResTaskFinshMessage
                    {
                        int _type = item.readByte();
                        int _modelId = item.readInt();
                        LongC _conquerTadkId = item.readLong();
                        int _finshType = item.readInt();
                        outstr = string.Format("_type:int={0};_modelId:int={1};_conquerTadkId:long={2};_finshType:int={3};"
                            ,_type,_modelId,_conquerTadkId.toString(),_finshType);
                    }break;
                case 101123://, cmdStr = "ResPlayerRunEndMessage" });
                    {
                        LongC _personId = item.readLong();
                        Position _position = item.readBean<Position>();// as Position;
                        outstr = string.Format("_personId={0};_position={1}", _personId, _position.getPrintStr());
                    }
                    break;
                case 101125://, cmdStr = "ResRoundObjectsMessage
                    {
                        ResRoundObjectsMessage tt = new ResRoundObjectsMessage() { _barr = barr, _pos = item._pos };
                        tt.reading();
                        item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }
                    break;
                case 101110:// cmdStr = "ResRunPositionsMessage"
                    {
                         LongC _personId = item.readLong();
                         Position _position = item.readBean<Position>();
                         List<int> _positions = item.readObjList<Byte,int>();
                         outstr = string.Format("_personId={0};_position={1};_positions.cnt={2}", _personId.toString(), _position.getPrintStr(), _positions.Count);
                    }break;
                case 126103://, cmdStr = "ResRidingStateMessage
                    {
                        LongC _playerid = item.readLong();
                        int _curlayer = item.readShort();
                        int _status = item.readByte();
                        int _huanhualayer = item.readInt();
                        outstr = string.Format("_playerid={0};_curlayer={1};_status={2};_huanhualayer={3}",
                            _playerid.toString(), _curlayer, _status, _huanhualayer);
                    }break;
                case 114113://, cmdStr = "ResRefreshBOSSSurplusTimeMessage
                    {
                        int _time = item.readInt();
                        outstr = string.Format("_time={0};", _time);
                    }
                    break;
                case 511002://, cmdStr = "ResGetNewActivityInfo
                    {
                        DetailActivityInfo _detailInfo = item.readBean<DetailActivityInfo>();// as DetailActivityInfo;
                        int _updateAllInfo = item.readByte();
                        outstr = string.Format("_updateAllInfo={0};_detailInfo={1}", _detailInfo, _detailInfo.getPrintStr());
                    }break;
                case 538048://, cmdStr = "ResMaintenanceInsuranceMessage
                    {
                        LongC _buySaftTime = item.readLong();
                        int _saftReceiveNum = item.readInt();
                        LongC _lastMaintenanceTime = item.readLong();
                        outstr = string.Format("_buySaftTime:long={0};_saftReceiveNum:int={1};_lastMaintenanceTime:long={2};"
                            ,_buySaftTime.toString(),_saftReceiveNum,_lastMaintenanceTime.toString());
                    }break;
                case 103103://, cmdStr = "ResPlayerExpChangeMessage
                    {
                        LongC _currentExp = item.readLong();
                        outstr = string.Format("_currentExp={0}", _currentExp.toString());
                    }break;
                case 600044://, cmdStr = "ResElementValueMessage
                    {
                        int _value = item.readInt();
                        outstr = string.Format("_value={0}", _value);
                    }break;
                case 537205:// cmdStr = "ResAllPokesInfoMessage
                    {
                        ResAllPokesInfoMessage tt = new ResAllPokesInfoMessage() { _barr = barr, _pos = item._pos };
                        tt.reading();
                        item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 103121://, cmdStr = "ResPlayerNonageStateMessage"
                    {
                        int _nonage = item.readByte();
                        outstr = string.Format("_nonage={0}", _nonage);
                    }break;
                case 100102://, cmdStr = "ResLoginSuccessMessage
                    {
                        int _mapId = item.readInt();
                        outstr = string.Format("_mapId={0}", _mapId);
                    }
                    break;
                case 100101://, cmdStr = "ResCharacterInfosMessage
                    {
                        ResCharacterInfosMessage tt = new ResCharacterInfosMessage() { _barr = barr, _pos = item._pos };
                        tt.reading();
                        item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }
                    break;
                case 200101:// cmdStr = "GmLevelMessage"
                    {
                        int _level = item.readInt();
                        outstr = string.Format("_level={0}", _level);
                    }break;
                case 502101://, cmdStr = "ResFightPostionBroadcastMessage"
                    {
                        ResFightPostionBroadcastMessage tt = new ResFightPostionBroadcastMessage() { _barr = barr, _pos = item._pos };
                        tt.reading();
                        item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 128116:// cmdStr = "ResZoneTeamShowToClientMessage" 
                    {
                        List<ZoneTeamInfo> lst = item.readObjList<ZoneTeamInfo, ZoneTeamInfo>();
                        int _type = item.readInt();
                        string outstr1 = "";
                        for (int i = 0; i < lst.Count; i++)
                        {
                            outstr1 +=i+" "+ lst[i].getPrintStr() + ";";
                        }
                        outstr = string.Format("ZoneTeamInfo.lst={0};type={1}", outstr1, _type);
                    }break;
                case 540024://, cmdStr = "ResNeutralIsOpenMessage"
                    {
                        int _isopen = item.readByte();
                        outstr = string.Format("_isopen ={0}", _isopen);
                    }break;
                case 109106://, cmdStr = "PersonalNoticeWorldMessage"
                    {
                        PersonalNoticeWorldMessage tt = new PersonalNoticeWorldMessage() { _barr = barr, _pos = item._pos };
                        tt.reading();
                        item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 101115:// cmdStr = "ResMonsterStopMessage"
                    {
                        LongC _monsterId = item.readLong();
                        Position _position = item.readBean<Position>();
                        outstr = string.Format("_monsterId={0};_position=({1},{2})", _monsterId.toString(), _position._x, _position._y);
                    }
                    break;
                case 512009://, cmdStr = "ResAuctionShowItemMessage"
                    {
                        ResAuctionShowItemMessage tt = new ResAuctionShowItemMessage { _barr = barr, _pos = item._pos };
                        tt.reading(); item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }
                    break;
                case 104103://, cmdStr = "ResItemChangeMessage"
                    {
                        ItemInfo _item = item.readBean<ItemInfo>() ;
                        outstr = item.getPrintStr();
                    }break;
                case 113103:// cmdStr = "ResRemoveBuffMessage
                    {
                        ResRemoveBuffMessage bb = new ResRemoveBuffMessage() { _barr = barr, _pos = item._pos };
                        bb.reading(); item._pos = bb._pos;
                        outstr = bb.getPrintStr();
                    }
                    break;
                case 510020:// cmdStr = "ResBossEventMessage"
                    {
                        ResBossEventMessage tt = new ResBossEventMessage() { _barr = item._barr, _pos = item._pos };
                        tt.reading(); item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                        item._pos = tt._pos;
                    }break;
                case 109102://, cmdStr = "PersonalNoticeMessage"
                    {
                        PersonalNoticeMessage pp = new PersonalNoticeMessage() { _barr = barr, _pos = item._pos };
                        pp.reading(); item._pos = pp._pos;
                        outstr = pp.getPrintStr();
                        item._pos = pp._pos;
                    }
                    break;
                case 527025://, cmdStr = "ResListAttackResultMessage"
                    {
                        ResListAttackResultMessage tt = new ResListAttackResultMessage() { _barr = barr, _pos = item._pos };
                        tt.reading(); item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 101103:// cmdStr = "ResRoundGoodsMessage"
                    {
                        DropGoodsInfo tt = new DropGoodsInfo() {  _barr = barr, _pos=item._pos};
                        tt.reading(); item._pos = tt._pos;
                        outstr = tt.getShowInfo();
                    }break;
                case 100108:// cmdStr = "ResHeartMessage"
                    {
                        int _time = item.readInt();
                        int _time2 = item.readInt();
                        ConsoleLog.Instance.writeInformationLog("ResHeartMessage.arr="+Int2Hexstring(barr));
                        outstr = string.Format("time1={0};time2={1}", _time, _time2);
                    }
                    break;
                case 101102:// cmdStr = "ResRoundMonsterMessage"
                    {
                        CSMonsterInfo monsterInfo = new CSMonsterInfo() { _barr = barr, _pos = item._pos };
                        monsterInfo.reading(); item._pos = monsterInfo._pos;
                        outstr = monsterInfo.getPrintStr();
                    }
                    break;
                case 124101:// cmdStr = "ResMailQueryListToClientMessage"
                    {
                         int _btErrorCode = item.readByte();
                        List<MailSummaryInfo> list = item.readObjList<MailSummaryInfo, MailSummaryInfo>();
                        outstr = "邮件列表：";
                        for (int i = 0; i < list.Count; i++)
                            outstr += list[i].getShowInfo() + "\r\n";
                    }
                    break;
                case 124110://, cmdStr = "ResMailGetNewMailToClientMessage"
                    {
                        int _nCount = item.readInt();
                        outstr = string.Format("mailcnt={0}", _nCount);
                    }break;
                case 103101:// cmdStr = "ResPlayerHpChangeMessage"
                    {
                        LongC _personId = item.readLong();
                        LongC _currentHp = item.readLong();
                        outstr = string.Format("_personId={0};_currentHp={1}", _personId.toString(), _currentHp.toString());
                    }
                    break;
                case 101106://ResRoundMonsterDisappearMessage
                    {
                        List<LongC> lst = item.readObjList<LongC, LongC>();
                        outstr = string.Format("lst.cnt={0}", lst.Count);
                    }break;
                case 114109://ResMonsterReviveMessage
                    {
                        CSMonsterInfo monsterInfo = new CSMonsterInfo() { _barr = barr, _pos = item._pos };
                        monsterInfo.reading(); item._pos = monsterInfo._pos;
                        outstr = monsterInfo.getPrintStr();
                    }
                    break;
                case 600009:
                    {
                        int _type = item.readShort();
                        int _count = item.readShort();
                        outstr = string.Format("_type={0};_count={1}", _type, _count);
                    }
                    break;
                case 101111:
                    {
                         LongC _monsterId = item.readLong();
                         Position _position = item.readBean<Position>();
                         List<int> poslist = item.readObjList<Byte,int>();
                         outstr = string.Format("_monsterId={0};_position:({1},{2});poslist.cnt={3}", 
                             _monsterId.toString(),_position._x,_position._y, poslist.Count);
                    }
                    break;
                case 102102:
                    {
                        LongC _entityId = item.readLong();
                        LongC _sourceId = item.readLong();
                        int _skillId = item.readInt();
                        int _fightResult = item.readByte();
                        LongC _damage = item.readLong();
                        LongC _currentHP = item.readLong();
                        int _fightSpecialRes = item.readShort();
                        outstr = string.Format("_entityId={0};_sourceId={1};_skillId={2};_fightResult={3};_damage={4};_currentHP={5};_fightSpecialRes={6};", 
                            _entityId.toString(), _sourceId.toString(), _skillId, _fightResult, _damage.toString(), _currentHP.toString(), _fightSpecialRes);
                    }
                    break;
                case 102101:
                    {
                        LongC _personId = item.readLong();
                        int _fightDirection = item.readByte();
                        int _fightType = item.readInt();
                        LongC _fightTarget = item.readLong();
                        outstr = string.Format("_personId={0},{1};_fightDirection={2};_fightType={3};", 
                            Convert.ToString(_personId.high, 16), Convert.ToString(_personId.low, 16),
                            _fightDirection, _fightType,Convert.ToString(_fightTarget.high, 16),
                            Convert.ToString(_fightTarget.high, 16) );
                    }
                    break;
                //case 600009:
                //    {
                //        int _type = item.readShort();
                //        int _count = item.readShort();
                //        outstr = string.Format("_type={0};_count={1}", _type, _count);
                //    }
                //    break;
                case 101107:
                    {
                         List<LongC> goodlst = item.readObjList<LongC,LongC>();
                         outstr = string.Format("goodlist.length={0}", goodlst.Count);
                    }
                    break;
                case 103105:
                    {
                        LongC _personId = item.readLong();
                        int _currentMp = item.readInt();
                        outstr = string.Format("_personId={0};_currentMp={1}", _personId.toString(), _currentMp);
                    }
                    break;
                case 103119:
                    {
                         int i = 0;
                         int _attributeChangeReason = item.readInt();
                         int _modelId = item.readInt();
                         int nIarrLen = item.readShort();
                         i = 0;
                         List<PlayerAttributeItem> lst = new List<PlayerAttributeItem>();
                         while(i < nIarrLen)
                         {
                             int type1 = item.readInt();
                             LongC value1 = item.readLong();
                             lst.Add(new PlayerAttributeItem() { type = type1, value = value1 });
                             //this._attributeChangeList[_loc1_] = readBean(PlayerAttributeItem) as PlayerAttributeItem;
                            i++;
                         }
                         outstr = string.Format("_attributeChangeReason={0};_modelId={1};nIarrLen={2}", _attributeChangeReason, _modelId, nIarrLen);
                         //return true;
                    }
                    break;
                case 560201:
                    {
                        LongC _playerId = item.readLong();
                        outstr = string.Format("_playerId={0}", _playerId);
                    }break;
                case 113102://, cmdStr = "ResAddBuffMessage
                    {
                        ResAddBuffMessage tt = new ResAddBuffMessage() { _barr = barr, _pos = item._pos };
                        tt.reading(); item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 583001://, cmdStr = "ResSoulfactMessage
                    {
                        List<SoulfactInfo> _list = item.readObjList<SoulfactInfo, SoulfactInfo>();
                        outstr = string.Format("_list.cnt={0};", _list.Count);
                    }break;
                case 600022:// cmdStr = "ResProtectStateMessage
                    {
                        int type = item.readByte();
                        outstr = string.Format("type={0}", type);
                    }break;
                case 120104:
                    {
                        ImageDescrypt.Entity.MainTaskInfo _task = item.readBean<ImageDescrypt.Entity.MainTaskInfo>();
                        outstr = _task.getPrintStr();
                    }
                    break;
                case 103112:
                    {
                        LongC _personId = item.readLong();
                        int _speed = item.readInt();
                        outstr = string.Format("_personId={0};_speed={1}", _personId.toString(), _speed);
                    }break;
                case 527091://, cmdStr = "ResMatchTopInfosMessage
                    {
                        ResMatchTopInfosMessage tt = new ResMatchTopInfosMessage() { _barr = barr, _pos = item._pos };
                        tt.reading(); item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 537071://ResPokeFTInfoMessage
                    {
                        ResPokeFTInfoMessage tt = new ResPokeFTInfoMessage() { _barr = barr, _pos = item._pos };
                        tt.reading(); item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 525063://,ResFashionInfoMessage,
                    {
                        ResFashionInfoMessage tt = new ResFashionInfoMessage() { _barr = barr, _pos = item._pos };
                        tt.reading(); item._pos = tt._pos;
                        outstr = tt.getPrintStr();
                    }break;
                case 525002://,ResElementPieceMessage,
                    {
                        int _elementPiece = item.readInt();
                        int framentNumChuanqi = item.readInt();
                        outstr = string.Format("_elementPiece={0};framentNumChuanqi={1}", _elementPiece, framentNumChuanqi);
                    }break;
                case 511020://ResFirstPayGroupCountMessage,
                    {
                        String  groupCount = item.readString();
                        outstr = string.Format("groupCount={0}", groupCount);
                    }break;
                case 536253: break;
                case 535034:break;//,ResOpenDrinkMessage
                default:
                    // 打印字符串
                    outstr = string.Format("cmd={0};hexstring={1}", nCmd, Int2Hexstring(barr));
                    return outstr;
            }
            curpos = item._pos;
            #endregion
            // ConsoleLog.Instance.writeInformationLog(cmdstr + outstr);
            return cmdstr + outstr;
            }
            catch (Exception ex)
            {
                curpos = barr.Length;
                ConsoleLog.Instance.writeErrorLog("recv hexstr=" + Int2Hexstring (barr)+ ";ErrMsg=" + ex.Message + "ST=" + ex.StackTrace);
                return "Exception occured";
            }
        }



        static MessageDescrypt()
        {
            //  ://,://,511020,ResFirstPayGroupCountMessage,
            m_list.Add(new Cmd() { cmd = 511020, cmdStr = "ResFirstPayGroupCountMessage" });
            m_list.Add(new Cmd() { cmd = 525002, cmdStr = "ResElementPieceMessage" });
            m_list.Add(new Cmd() { cmd = 525063, cmdStr = "ResFashionInfoMessage" });
            m_list.Add(new Cmd() { cmd = 525063, cmdStr = "ResFashionInfoMessage" });
            m_list.Add(new Cmd() { cmd = 537071, cmdStr = "ResPokeFTInfoMessage" });
            m_list.Add(new Cmd() { cmd = 529111, cmdStr = "ResOpenCloudBuyInfoToClientMessage" });
            m_list.Add(new Cmd() { cmd = 100314, cmdStr = "ResRolesCreateReportToGateMessage" });
            m_list.Add(new Cmd() { cmd = 504000, cmdStr = "ResMapBossInfoMessage" });
            m_list.Add(new Cmd() { cmd = 101120, cmdStr = "ResEnterMapMessage" });
            m_list.Add(new Cmd() { cmd = 600022, cmdStr = "ResProtectStateMessage" });
            m_list.Add(new Cmd() { cmd = 583001, cmdStr = "ResSoulfactMessage" });
            m_list.Add(new Cmd() { cmd = 113102, cmdStr = "ResAddBufMessage" });
            m_list.Add(new Cmd() { cmd = 103119, cmdStr = "ResPlayerAttributeChangeMessage" });
            m_list.Add(new Cmd() { cmd = 103105, cmdStr = "ResPlayerMpChangeMessage" });
            m_list.Add(new Cmd() { cmd = 101107, cmdStr = "ResRoundGoodsDisappearMessage" });
            m_list.Add(new Cmd() { cmd = 600009, cmdStr = "ResEventChanageToClientMessage" });
            m_list.Add(new Cmd() { cmd = 102101, cmdStr = "ResFightBroadcastMessage" });
            m_list.Add(new Cmd() { cmd = 102102, cmdStr = "ResAttackResultMessage" });
            m_list.Add(new Cmd() { cmd = 101111, cmdStr = "ResMonsterRunPositionsMessage" });
            m_list.Add(new Cmd() { cmd = 114109, cmdStr = "ResMonsterReviveMessage" });
            m_list.Add(new Cmd() { cmd = 101106, cmdStr = "ResRoundMonsterDisappearMessage," });
            m_list.Add(new Cmd() { cmd = 103101, cmdStr = "ResPlayerHpChangeMessage" });
            m_list.Add(new Cmd() { cmd = 124110, cmdStr = "ResMailGetNewMailToClientMessage" });
            m_list.Add(new Cmd() { cmd = 124101, cmdStr = "ResMailQueryListToClientMessage" });
            m_list.Add(new Cmd() { cmd = 101102, cmdStr = "ResRoundMonsterMessage" });
            m_list.Add(new Cmd() { cmd = 100108, cmdStr = "ResHeartMessage" });
            m_list.Add(new Cmd() { cmd = 101103, cmdStr = "ResRoundGoodsMessage" });
            m_list.Add(new Cmd() { cmd = 527025, cmdStr = "ResListAttackResultMessage" });
            m_list.Add(new Cmd() { cmd = 109102, cmdStr = "PersonalNoticeMessage" });
            m_list.Add(new Cmd() { cmd = 510020, cmdStr = "ResBossEventMessage" });
            m_list.Add(new Cmd() { cmd = 113103, cmdStr = "ResRemoveBuffMessage" });
            m_list.Add(new Cmd() { cmd = 104103, cmdStr = "ResItemChangeMessage" });
            m_list.Add(new Cmd() { cmd = 512009, cmdStr = "ResAuctionShowItemMessage" });
            m_list.Add(new Cmd() { cmd = 101115, cmdStr = "ResMonsterStopMessage" });
            m_list.Add(new Cmd() { cmd = 109106, cmdStr = "PersonalNoticeWorldMessage" });
            m_list.Add(new Cmd() { cmd = 540024, cmdStr = "ResNeutralIsOpenMessage" });
            m_list.Add(new Cmd() { cmd = 128116, cmdStr = "ResZoneTeamShowToClientMessage" });
            m_list.Add(new Cmd() { cmd = 502101, cmdStr = "ResFightPostionBroadcastMessage" });
            m_list.Add(new Cmd() { cmd = 200101, cmdStr = "GmLevelMessage" });
            m_list.Add(new Cmd() { cmd = 100101, cmdStr = "ResCharacterInfosMessage," });
            m_list.Add(new Cmd() { cmd = 100102, cmdStr = "ResLoginSuccessMessage" });
            m_list.Add(new Cmd() { cmd = 103121, cmdStr = "ResPlayerNonageStateMessage" });
            m_list.Add(new Cmd() { cmd = 537205, cmdStr = "ResAllPokesInfoMessage" });

            m_list.Add(new Cmd() { cmd = 600044, cmdStr = "ResElementValueMessage" });
            m_list.Add(new Cmd() { cmd = 103103, cmdStr = "ResPlayerExpChangeMessage" });
            m_list.Add(new Cmd() { cmd = 538048, cmdStr = "ResMaintenanceInsuranceMessage" });
            m_list.Add(new Cmd() { cmd = 511002, cmdStr = "ResGetNewActivityInfo" });
            m_list.Add(new Cmd() { cmd = 114113, cmdStr = "ResRefreshBOSSSurplusTimeMessage" });
            m_list.Add(new Cmd() { cmd = 126103, cmdStr = "ResRidingStateMessage" });
            m_list.Add(new Cmd() { cmd = 101110, cmdStr = "ResRunPositionsMessage" });
            m_list.Add(new Cmd() { cmd = 101125, cmdStr = "ResRoundObjectsMessage" });
            m_list.Add(new Cmd() { cmd = 101123, cmdStr = "ResPlayerRunEndMessage" });//
            m_list.Add(new Cmd() { cmd = 120102, cmdStr = "ResTaskFinshMessage" });

            m_list.Add(new Cmd() { cmd = 511009, cmdStr = "ResRemoveActivityMessage" });
            m_list.Add(new Cmd() { cmd = 526017, cmdStr = "ResOpenHysyMessage" });
            m_list.Add(new Cmd() { cmd = 104105, cmdStr = "ResMoneyChangeMessage" });

            m_list.Add(new Cmd() { cmd = 141101, cmdStr = "ResMonsterBatterToClientMessage" });
            m_list.Add(new Cmd() { cmd = 101116, cmdStr = "ResPlayerStopMessage" });
            m_list.Add(new Cmd() { cmd = 102105, cmdStr = "ResFightFailedBroadcastMessage" });

            m_list.Add(new Cmd() { cmd = 104102, cmdStr = "ResItemAddMessage" });
            m_list.Add(new Cmd() { cmd = 104104, cmdStr = "ResItemRemoveMessage" });
            m_list.Add(new Cmd() { cmd = 103891, cmdStr = "ResChangeOneAttributeMessage" });
            m_list.Add(new Cmd() { cmd = 103110, cmdStr = "ResPlayerMaxMpChangeMessage" });
            m_list.Add(new Cmd() { cmd = 103130, cmdStr = "ResScriptCommonPlayerToClientMessage" });
            m_list.Add(new Cmd() { cmd = 560001, cmdStr = "ResGetHorseSkillMessage" });
            m_list.Add(new Cmd() { cmd = 128110, cmdStr = "ResZoneLifeTimeMessage" });
            m_list.Add(new Cmd() { cmd = 126101, cmdStr = "ResHorseInfoMessage" });
            m_list.Add(new Cmd() { cmd = 110101, cmdStr = "ResPetListMessage" });

            m_list.Add(new Cmd() { cmd = 529114, cmdStr = "ResUpdateCloudBuyToClientMessage" });
            m_list.Add(new Cmd() { cmd = 525066, cmdStr = "ResBuyFastestMessage" });
            m_list.Add(new Cmd() { cmd = 104107, cmdStr = "ResUseItemSuccessMessage" });

            m_list.Add(new Cmd() { cmd = 101124, cmdStr = "ResSendLinesMessage" });

            m_list.Add(new Cmd() { cmd = 150203, cmdStr = "ResRetreatInfoM" });
            m_list.Add(new Cmd() { cmd = 108102, cmdStr = "ShortCutAddMessage" });
            m_list.Add(new Cmd() { cmd = 525003, cmdStr = "ResBackDamageMessage" });
            m_list.Add(new Cmd() { cmd = 104212, cmdStr = "ResTakeUpSuccessMessage" });

            m_list.Add(new Cmd() { cmd = 527035, cmdStr = "ResNewAttributeItemUseInfo" });
            m_list.Add(new Cmd() { cmd = 525009, cmdStr = "ResGetMonsterBooksMessage" });

            m_list.Add(new Cmd() { cmd = 127201, cmdStr = "ResFightPowerToClientMessage" });
            m_list.Add(new Cmd() { cmd = 525065, cmdStr = "ResCosmicGateLoginMssage" });
            m_list.Add(new Cmd() { cmd = 536253, cmdStr = "ResInvadeAddSpiceMessage" });// ,
            m_list.Add(new Cmd() { cmd = 535034, cmdStr = "ResOpenDrinkMessage" });//,,:break;//,
            m_list.Add(new Cmd() { cmd = 120104, cmdStr = "ResMainTaskChangeMessage" });
            m_list.Add(new Cmd() { cmd = 103107, cmdStr = "ResMyPlayerInfoMessage" });//://,
            m_list.Add(new Cmd() { cmd = 103112, cmdStr = "ResPlayerSpeedChangeMessage" });//;,,
            m_list.Add(new Cmd() { cmd = 527091, cmdStr = "ResMatchTopInfosMessage" });//
            // m_list.Add(new Cmd() { cmd = , cmdStr = "" });
            // m_list.Add(new Cmd() { cmd = , cmdStr = "" });
            // m_list.Add(new Cmd() { cmd = , cmdStr = "" });
            // m_list.Add(new Cmd() { cmd = , cmdStr = "" });
            // 527091,,
            ////////////////////////////////////////////////////////////recv
            m_list.Add(new Cmd() { cmd = 540290, cmdStr = "com.game.upPower.message.reqWuBeiInfoMessage" });
            m_list.Add(new Cmd() { cmd = 128207, cmdStr = "com.game.zones.message.ReqZoneReceiveawardsMessage" });
            m_list.Add(new Cmd() { cmd = 525265, cmdStr = "com.game.warpGate.message.ReqGetFastestMessage" });
            m_list.Add(new Cmd() { cmd = 528316, cmdStr = "com.game.zones.message. ReqAddBuffMessage" });
            m_list.Add(new Cmd() { cmd = 600205, cmdStr = "com.game.lostskills.message.ReqLostSkillInfosMessage" });
            m_list.Add(new Cmd() { cmd = 511203, cmdStr = "com.game.newactivity.message.ReqGetNewActivityAward " });
            m_list.Add(new Cmd() { cmd = 100202, cmdStr = "com.game.login.message.ReqSelectCharacterMessage" });
            m_list.Add(new Cmd() { cmd = 100206, cmdStr = "com.game.login.message.ReqHeartMessage" });
            m_list.Add(new Cmd() { cmd = 100204, cmdStr = "com.game.login.message.ReqLoadFinishMessage" });
            m_list.Add(new Cmd() { cmd = 510202, cmdStr = "com.game.bank.message.ReqQueryBankMessage;ResQueryBankLogMessage" });
            m_list.Add(new Cmd() { cmd = 540224, cmdStr = "com.game.angelTerritory.message.ReqNeutralIsOpenMessage" });
            m_list.Add(new Cmd() { cmd = 600217, cmdStr = "com.game.masterequip.message.ReqContainerMessage" });
            m_list.Add(new Cmd() { cmd = 128213, cmdStr = "com.game.zones.message.ReqZoneTeamOpenToGameMessage " });
            m_list.Add(new Cmd() { cmd = 539219, cmdStr = "com.game.angelEquip.message.ReqUpgradeAngleMessage" });
            m_list.Add(new Cmd() { cmd = 538248, cmdStr = "com.game.newactivity.message.ReqMaintenanceInsuranceMessage " });
            m_list.Add(new Cmd() { cmd = 144202, cmdStr = "com.game.challenge.message.ReqSelectChallengeToGameMessage" });
            m_list.Add(new Cmd() { cmd = 535204, cmdStr = "com.game.hellDoor.message.ReqHellGateInfoMessage" });
            m_list.Add(new Cmd() { cmd = 31208, cmdStr = "com.game.assistant.message.ReqGetAssistantMessage" });
            m_list.Add(new Cmd() { cmd = 101211, cmdStr = "com.game.map.message.ReqGetLinesMessage" });
            m_list.Add(new Cmd() { cmd = 538297, cmdStr = "com.game.honortitle.ReqGetHonorLevelMessage" });
            m_list.Add(new Cmd() { cmd = 511201, cmdStr = "com.game.newactivity.message.ReqGetNewActivityInfo" });
            m_list.Add(new Cmd() { cmd = 120217, cmdStr = "com.game.task.message.ReqSaveGuidesMessage" });
            m_list.Add(new Cmd() { cmd = 528330, cmdStr = "com.game.pray.message.ReqPrayInfoMessage" });
            m_list.Add(new Cmd() { cmd = 540261, cmdStr = "com.game.guild.message.ReqGuildInfoMessage" });
            m_list.Add(new Cmd() { cmd = 526217, cmdStr = "com.game.hysy.message.ReqOpenHysyMessage" });
            m_list.Add(new Cmd() { cmd = 101201, cmdStr = "com.game.map.message.ReqRunningMessage" });
            m_list.Add(new Cmd() { cmd = 527295, cmdStr = "com.game.newrecoverclone.message.ReqNewRecoverMessage" });
            m_list.Add(new Cmd() { cmd = 101205, cmdStr = "com.game.map.message.ReqPlayerStopMessage" });
            m_list.Add(new Cmd() { cmd = 102201, cmdStr = "com.game.fight.message.ReqAttackMonsterMessage" });
            m_list.Add(new Cmd() { cmd = 104211, cmdStr = "com.game.backpack.message.ReqTakeUpMessage" });
            m_list.Add(new Cmd() { cmd = 538222, cmdStr = "com.game.arsenal.message.ReqOpenArsenalPanelMessage " });
            m_list.Add(new Cmd() { cmd = 104208, cmdStr = "com.game.backpack.message.ReqCellTimeQueryMessage" });
            m_list.Add(new Cmd() { cmd = 525242, cmdStr = "com.game.player.message.ReqChangeIsSendMessage" });
            m_list.Add(new Cmd() { cmd = 583201, cmdStr = "com.game.soulfact.message.ReqSoulfactMessage" });
            m_list.Add(new Cmd() { cmd = 106201, cmdStr = "com.game.equip.message.WearEquipMessage" });
            m_list.Add(new Cmd() { cmd = 103890, cmdStr = "com.game.player.message.ReqAddPointMessage", note = "加点 " });
            m_list.Add(new Cmd() { cmd = 126202, cmdStr = "com.game.horse.message.ReqChangeRidingStateMessage " });
            m_list.Add(new Cmd() { cmd = 101210, cmdStr = "com.game.map.message.ReqGoldMapTransMessage" });
            m_list.Add(new Cmd() { cmd = 101207, cmdStr = "com.game.map.message.ReqLoadFinishForChangeMapMessage" });
            m_list.Add(new Cmd() { cmd = 120202, cmdStr = "com.game.task.message.ReqTaskFinshMessage" });
            m_list.Add(new Cmd() { cmd = 104203, cmdStr = "com.game.backpack.message.ReqUseItemMessage" });
            m_list.Add(new Cmd() { cmd = 105207, cmdStr = "com.game.shop.message.ReqSellItemsMessage" });
            m_list.Add(new Cmd() { cmd = 131210, cmdStr = "com.game.assistant.message.ReqSaveAssistantMessage" });
            m_list.Add(new Cmd() { cmd = 104109, cmdStr = "ResCellTimeMessage" });
            m_list.Add(new Cmd() { cmd = 502203, cmdStr = "com.game.fight.message.ReqAttackSpecialMessage" });
            // 
            m_list.Add(new Cmd() { cmd = 108201, cmdStr = "com.game.shortcut.message.AddShortCutMessage" });
            m_list.Add(new Cmd() { cmd = 107203, cmdStr = "com.game.skill.message.SetDefaultSkillMessage" });
            m_list.Add(new Cmd() { cmd = 580202, cmdStr = "com.game.iphone.message.ReqOpenURLmessage" });
            m_list.Add(new Cmd() { cmd = 128211, cmdStr = "com.game.zones.message.ReqZoneTeamEnterToGameMessage" });
            m_list.Add(new Cmd() { cmd = 128204, cmdStr = "com.game.zones.message.ReqZoneOutMessage" });
            m_list.Add(new Cmd() { cmd = 101206, cmdStr = "com.game.map.message.ReqChangeMapByMoveMessage" });
            m_list.Add(new Cmd() { cmd = 150201, cmdStr = "com.game.offline.message.ReqRetreatInfoMessage" });
            m_list.Add(new Cmd() { cmd = 600207, cmdStr = "com.game.worldlevel.message.ReqWorldLevelInfoMessage" });
            m_list.Add(new Cmd() { cmd = 152201, cmdStr = "com.game.signwage.message.ReqSignToClientMessage" });
            m_list.Add(new Cmd() { cmd = 600106, cmdStr = "com.game.activitiesoverview.message.ReqGainStateToServerMessage " });
            m_list.Add(new Cmd() { cmd = 600102, cmdStr = "com.game.activitiesoverview.message.ReqLivenessEventsToServerMessage" });
            m_list.Add(new Cmd() { cmd = 525246, cmdStr = "com.game.signwage.message.ReqGetRecoverMessage" });
            m_list.Add(new Cmd() { cmd = 600100, cmdStr = "ReqLivenessToServerMessage" });////ReqMatchTopInfosMessage
            m_list.Add(new Cmd() { cmd = 527291, cmdStr = "com.game.toplist.structs.ReqMatchTopInfosMessage" });////ReqMatchTopInfosMessage
            m_list.Add(new Cmd() { cmd = 152206, cmdStr = "com.game.signwage.message.ReqClickSignToClientMessage " });
            m_list.Add(new Cmd() { cmd = 105207, cmdStr = "com.game.shop.message.ReqSellItemsMessage" });
            m_list.Add(new Cmd() { cmd = 527235, cmdStr = "com.game.player.message.ReqNewAttributeItemUseInfo" });
            m_list.Add(new Cmd() { cmd = 104205, cmdStr = "com.game.backpack.message.ReqClearUpGoodsMessage", note = "整理背包？" });
            m_list.Add(new Cmd() { cmd = 529220, cmdStr = "com.game.secretary.message.ReqSetSecretaryToServerMessage" });

            m_list.Add(new Cmd() { cmd = 121202, cmdStr = "com.game.guild.message.ReqGuildAutoArgeeAddGuildToServerMessage" });
            m_list.Add(new Cmd() { cmd = 540213, cmdStr = "com.game.newserverhigh.message.ReqOpenNewServerHighPanel" });
            m_list.Add(new Cmd() { cmd = 535298, cmdStr = "com.game.guoqing.message.ReqOpenSevenDayPainMessage" });
            m_list.Add(new Cmd() { cmd = 124151, cmdStr = "com.game.mail.message.ReqMailQueryListToServerMessage" });
            m_list.Add(new Cmd() { cmd = 131212, cmdStr = "com.game.task.message.ReqMainTaskTransMessage" });
            m_list.Add(new Cmd() { cmd = 126207, cmdStr = "com.game.horse.message.ReqhorseReceiveMessage" });
            m_list.Add(new Cmd() { cmd = 103201, cmdStr = "com.game.player.message.ReqReviveMessage" });
            m_list.Add(new Cmd() { cmd = 124152, cmdStr = "com.game.mail.message.ReqMailQueryDetailToServerMessage" });
            m_list.Add(new Cmd() { cmd = 124153, cmdStr = "com.game.mail.message.ReqMailGetItemToServerMessage" });
            m_list.Add(new Cmd() { cmd = 529207, cmdStr = "com.game.player.message.ReqGetTitleByUseItemToServerMessage" });
            m_list.Add(new Cmd() { cmd = 535219, cmdStr = "com.game.bless.message.ReqBlessCountMessage" });
            m_list.Add(new Cmd() { cmd = 126201, cmdStr = "com.game.horse.message.ReqGethorseInfoMessage" });
            m_list.Add(new Cmd() { cmd = 560201, cmdStr = "com.game.horseskill.message.ReqGetHorseSkillMessage" });
            m_list.Add(new Cmd() { cmd = 540296, cmdStr = "com.game.upPower.message.ReqZoneFinshMessage" });
            m_list.Add(new Cmd() { cmd = 104207, cmdStr = "com.game.backpack.message.ReqOpenCellMessage" });
            m_list.Add(new Cmd() { cmd = 131208, cmdStr = "com.game.assistant.message.ReqGetAssistantMessage" });
            m_list.Add(new Cmd() { cmd = 600100, cmdStr = "com.game.activitiesoverview.message.ReqLivenessToServerMessage" });
            m_list.Add(new Cmd() { cmd = 529210, cmdStr = "com.game.cloudbuy.message.ReqOpenCloudBuyInfoToServerMessage" });
            m_list.Add(new Cmd() { cmd = 104207, cmdStr = "com.game.backpack.message.ReqOpenCellMessage" });
        }
        public static string  DecodeMsg(byte[] barr)
        {
            try
            {
                if (barr.Length < 4)
                    return "Len too short";

                int nLen = (int)barr[3] + (int)(barr[2] << 8) + (int)(barr[1] << 16) + (int)(barr[0] << 24);
                if (nLen > barr.Length - 4)
                {
                    ConsoleLog.Instance.writeInformationLog("无法解析的报文:" + Int2Hexstring(barr));
                    return "Len err";
                }
                int nCmd = (int)barr[7] + (int)(barr[6] << 8) + (int)(barr[5] << 16) + (int)(barr[4] << 24);

                int endpos = 0;
                string outstr = "";
                Cmd xcmd = m_list.Find(x => x.cmd == nCmd);
                string cmdstr = "cmd:" + nCmd + ";";
                if (xcmd != null)
                    cmdstr = string.Format("cmd={0};{1};", xcmd.cmd, xcmd.cmdStr);

                Bean item = new Bean() { _barr = barr, _pos = 8 };
                #region switchbegin
                switch (nCmd)
                {
                    case 527291:
                        {
                            int _type = item.readInt();
                            int _page = item.readInt();
                            outstr = string.Format("_type={0};_page={1}", _type, _page);
                        }break;

                    case 103107://,ResMyPlayerInfoMessage, 
                        {
                            ResMyPlayerInfoMessage tt = new ResMyPlayerInfoMessage { _barr = barr, _pos = item._pos };
                            tt.reading();
                            outstr = tt.getPrintStr();
                        }break;
                    case 529111:// cmdStr = "ResOpenCloudBuyInfoToClientMessage
                        {
                            ResOpenCloudBuyInfoToClientMessage tt = new ResOpenCloudBuyInfoToClientMessage() { _barr = barr, _pos = item._pos };
                            tt.reading();
                            outstr = tt.getPrintStr();
                        }break;
                    case 529210:
                        {
                            int isHefu = item.readByte();
                            outstr = string.Format("isHefu={0}", isHefu);
                        }break;
                    case 104207:// cmdStr = "com.game.backpack.message.ReqOpenCellMessage
                        {
                            int _cellId = item.readInt();
                            outstr = string.Format("_cellId={0}", _cellId);
                        }break;
                    case 126201:
                        break;
                    case 540296:
                        {
                            int _type = item.readInt();
                            outstr = string.Format("_type={0}", _type);
                        }break;
                    case 502203:
                        {
                            ReqAttackSpecialMessage tt = new ReqAttackSpecialMessage() { _barr=barr, _pos=item._pos};
                            tt.reading();
                            outstr = tt.getPrintStr();
                        }break;
                    case 100202:
                        LongC _playId = Bean.readRawVarint64(barr, 8, ref endpos);
                        outstr = string.Format("_playId={0} {1}", Convert.ToString(_playId.low, 16), Convert.ToString(_playId.high, 16));
                        break;
                    case 100204:// 100204
                        {
                            int _type = (int)barr[8];
                            int _width = Bean.readRawVarint32(barr, 9, ref endpos);//readInt();
                            int _height = Bean.readRawVarint32(barr, endpos, ref endpos);
                            outstr = string.Format("width={0} height={1};type={2}", _width, _height, _type);
                        }
                        break;
                    case 100206:
                        {
                            int nMsec = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("登录时长={0}", nMsec / 1000);
                        }
                        break;
                    case 100208:
                        {
                            string _serverId = item.readString();
                            string _username = item.readString();
                            string _agent = item.readString();
                            string _ad = item.readString();
                            string _time = item.readString();
                            string _isadult = item.readString();
                            string _sign = item.readString();
                            string _localref = item.readString();
                            string _reserva1 = item.readString();
                            string _reserva2 = item.readString();
                            string _logintype = item.readString();
                            string _agentPlusdata = item.readString();
                            string _agentColdatas = item.readString();
                            string _adregtime = item.readString();
                            string _infoComp = item.readString();
                            string isapp = item.readString();
                            outstr = string.Format("_serverId={0};_username={1};_agent={2};_ad={3};_time={4};_isadult={5};_sign={6};_localref={7};_reserva1={8};_reserva2={9};_logintype={10};_agentPlusdata={11},_agentColdatas={12};_adregtime={13};_infoComp={14};isapp={15}",
                                _serverId, _username, _agent,
                                _ad, _time, _isadult, _sign, _localref, _reserva1, _reserva2, _logintype, _agentPlusdata,
                                _agentColdatas, _adregtime, _infoComp, isapp);
                        }
                        break;
                    case 101201:
                        Position pos = new Position() { _barr=barr,_pos = item._pos };
                        pos.reading();
                        item._pos = pos._pos;
                        List<int> positions = item.readObjList<byte, int>();

                        outstr = string.Format("Position({0});pos.cnt={1}", pos.getPrintStr(), positions.Count);
                        break;
                    case 101205:
                        // _position = readBean(Position) as Position;
                        {
                            int _x = Bean.ReadShort(barr, 8);
                            int _y = Bean.ReadShort(barr, 10);
                            outstr = string.Format("Position({0},{1})", _x, _y);
                        }
                        break;
                    case 101206:
                        {
                            int _line = Bean.readRawVarint32(barr, 8, ref endpos);
                            int _tranId = Bean.readRawVarint32(barr, endpos, ref endpos);
                            outstr = string.Format("_line={0};_tranId={1})", _line, _tranId);
                        }
                        break;
                    case 101207:
                        {
                            int _width = Bean.readRawVarint32(barr, 8, ref endpos);
                            int _height = Bean.readRawVarint32(barr, endpos, ref endpos);
                            outstr = string.Format("_width={0};_height={1})", _width, _height);
                        }
                        break;
                    case 101210:
                        {
                            int _mapId = Bean.readRawVarint32(barr, 8, ref endpos); ;
                            int _line = Bean.readRawVarint32(barr, endpos, ref endpos); ;
                            int _tag = Bean.ReadByte(barr, endpos);
                            outstr = string.Format("_mapId={0};_line={1};_tag={2}", _mapId, _line, _tag);
                        }
                        break;

                    case 102201:
                        {
                            int _fightType = Bean.readRawVarint32(barr, 8, ref endpos);
                            int _fightDirection = Bean.readRawVarint32(barr, endpos, ref endpos);
                            //int _fightTarget = 
                            LongC _fightTarget = Bean.readRawVarint64(barr, endpos, ref endpos);
                            outstr = string.Format("Type={0};Dir={1};Target.low={2},high={3}",
                                _fightType, _fightDirection, Convert.ToString(_fightTarget.low, 16), Convert.ToString(_fightTarget.high, 16));
                        }
                        break;
                    case 103890:
                        {
                            int _strength = item.readInt();
                            int _vitality = item.readInt();
                            int _agile = item.readInt();
                            int _intelligence = item.readInt();
                            int _restPlusPoint = item.readInt();
                            outstr = string.Format("_strength={0};_vitality={1};_agile={2};_intelligence={3};_restPlusPoint={4}",
                                _strength, _vitality, _agile, _intelligence, _restPlusPoint);
                        }
                        break;
                    case 104203:
                        {
                            LongC lc = Bean.readRawVarint64(barr, 8, ref endpos);
                            int _num = Bean.readRawVarint32(barr, endpos, ref endpos);
                            outstr = string.Format("item={0},{1};_num={2}",
                                Convert.ToString(lc.high, 16), Convert.ToString(lc.low, 16), _num);
                        }
                        break;
                    case 104208:
                        {
                            int cellId = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("cellId={0}", cellId);
                        }
                        break;
                    case 104211:
                        {
                            int _loc1_ = 0;
                            int _loc2_ = Bean.ReadShort(barr, 8);
                            _loc1_ = 0;
                            endpos = 10;
                            List<LongC> thelst = new List<LongC>();
                            string tempstr = "", tempstr2 = "";
                            while (_loc1_ < _loc2_)
                            {
                                LongC _itemId = Bean.readRawVarint64(barr, endpos, ref endpos);
                                thelst.Add(_itemId);
                                _loc1_++;
                                tempstr = string.Format("good{0},{1}{2};", _loc1_,
                                    Convert.ToString(_itemId.high, 16), Convert.ToString(_itemId.low, 16));
                                tempstr2 += tempstr;
                            }
                            outstr = string.Format("goodcnt={0};{1}", _loc2_, tempstr2);
                        }
                        break;
                    case 105207:
                        {
                            int _loc1_ = 0;
                            int _loc2_ = Bean.ReadShort(barr, 8);
                            _loc1_ = 0;
                            endpos = 10;
                            List<LongC> thelst = new List<LongC>();
                            string tempstr = "", tempstr2 = "";
                            while (_loc1_ < _loc2_)
                            {
                                LongC _itemId = Bean.readRawVarint64(barr, endpos, ref endpos);
                                thelst.Add(_itemId);
                                _loc1_++;
                                tempstr = string.Format("item{0},{1}{2};", _loc1_,
                                    Convert.ToString(_itemId.high, 16), Convert.ToString(_itemId.low, 16));
                                tempstr2 += tempstr;
                            }
                            outstr = string.Format("itemcnt={0};{1}", _loc2_, tempstr2);
                        }
                        break;
                    case 106201:
                        {
                            LongC _itemId = Bean.readRawVarint64(barr, 8, ref endpos);
                            int _pos = Bean.ReadByte(barr, endpos);
                            outstr = string.Format("itemcnt={0};{1}",
                                Convert.ToString(_itemId.high, 16), Convert.ToString(_itemId.low, 16), _pos);
                        } break;
                    case 107203:
                        {
                            int _defaultSkill = Bean.readRawVarint32(barr, 8, ref endpos); //readInt();
                            outstr = string.Format("_defaultSkill={0}", _defaultSkill);
                        }
                        break;
                    case 108201:
                        {
                            int _shortcutType = Bean.readRawVarint32(barr, 8, ref endpos); ;
                            LongC _shortcutSource = Bean.readRawVarint64(barr, endpos, ref endpos); ;
                            int _shortcutSourceModel = Bean.readRawVarint32(barr, endpos, ref endpos); ;
                            int _shortcutGrid = Bean.readRawVarint32(barr, endpos, ref endpos); ;
                            outstr = string.Format("_shortcutType={0};_shortcutSourceModel={1};_shortcutGrid={2}",
                                _shortcutType, _shortcutSourceModel, _shortcutGrid);
                        }
                        break;
                    case 120202:
                        {
                            int _type = Bean.ReadByte(barr, 8);
                            LongC _conquererTaskId = Bean.readRawVarint64(barr, 9, ref endpos);
                            int _taskId = Bean.readRawVarint32(barr, endpos, ref endpos);
                            bool _twice = Bean.ReadByte(barr, endpos) == 1;
                            outstr = string.Format("_type={0};_conquererTaskId={1},{2};_taskId={3};_twice={4}",
                                _type, Convert.ToString(_conquererTaskId.high, 16), Convert.ToString(_conquererTaskId.low, 16), _taskId, _twice);
                        }
                        break;
                    case 120217:
                        {
                            string tempstr = "", tempstr2 = "";
                            int _loc1_ = Bean.ReadShort(barr, 8);
                            int _loc2_ = 0;
                            endpos = 10;
                            while (_loc2_ < _loc1_)
                            {
                                int nGuild = Bean.readRawVarint32(barr, endpos, ref endpos); ;
                                _loc2_++;
                                tempstr = string.Format("guide{0}={1}", _loc2_, nGuild);
                                tempstr2 += tempstr;
                            }
                            outstr = string.Format("Len={0};{1}", _loc1_, tempstr2);
                        }
                        break;
                    case 121202:
                        int autoArgeeAddGuild = Bean.ReadByte(barr, 8);
                        outstr = string.Format("autoArgeeAddGuild={0}", autoArgeeAddGuild);
                        break;
                    case 126202:
                        {
                            int _curlayer = Bean.ReadShort(barr, 8);
                            int _status = barr[10];//();
                            outstr = string.Format("player={0};status={1}", _curlayer, _status);
                        }
                        break;
                    case 128213:
                        {
                            int zoneId = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("zoneId={0}", zoneId);
                        }
                        break;
                    case 131212:
                        {
                            int mapId = item.readInt();
                            int x = item.readInt();
                            int y = item.readInt();
                            int line = item.readInt();
                            int type = item.readByte();
                            int taskId = item.readInt();
                        }
                        break;
                    case 144202:
                        {
                            int type = barr[8];
                            outstr = string.Format("type={0}", type);
                        }
                        break;
                    case 128207:
                        {
                            int _type = Bean.ReadByte(barr, 8);
                            int _zid = Bean.readRawVarint32(barr, 9, ref endpos);
                            outstr = string.Format("type={0};_zid={1}", _type, _zid);
                        }
                        break;
                    case 128211:
                        {
                            int _entertype = Bean.ReadByte(barr, 8);
                            int _zoneid = Bean.readRawVarint32(barr, 9, ref endpos);
                            int _tag = Bean.ReadByte(barr, endpos);
                            outstr = string.Format("_entertype={0};_zoneid={1};_tag={2}", _entertype, _zoneid, _tag);
                        }
                        break;
                    case 131210:
                        {
                            // MessageDescrypt m = new MessageDescrypt() { _barr = barr, _pos = 8 };
                            string str = item.readString();
                            outstr = "Message=" + str;
                        }
                        break;
                    case 124152:
                        {
                            LongC mailid = item.readLong();
                            outstr = string.Format("mailid={0}", mailid.toString());
                        }
                        break;
                    case 124153:
                        {
                            LongC mailid = item.readLong();
                            LongC _itemid = item.readLong();
                            outstr = string.Format("mailid={0},{1};itemid={2},{3}",
                                Convert.ToString(mailid.high, 16),
                                Convert.ToString(mailid.low, 16),
                                Convert.ToString(_itemid.high, 16), Convert.ToString(mailid.low, 16));
                        } break;
                    case 101211:
                    case 103201:
                    case 104205:
                    case 124151:
                    case 126207:
                    case 128204:
                    case 131208:
                    case 150201:
                    case 152201:
                        break;
                    case 152206:
                        {
                            int tag = barr[8];
                            outstr = string.Format("tag={0}", tag);
                        }
                        break;
                    case 510202:
                        {
                            int type = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("type={0}", type);
                        }
                        break;
                    case 511203:
                        {
                            int _activityId = Bean.readRawVarint32(barr, 8, ref endpos);
                            int _condiction = Bean.readRawVarint32(barr, endpos, ref endpos);
                        }
                        break;
                    case 511201:
                        {
                            int _activityId = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("type={0}", _activityId);
                        } break;
                    case 525265:
                        {
                            int _mapId = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("_mapId={0}", _mapId);
                        };
                        //override protected function reading() : Boolean
                        //{
                        //   var _loc1_:int = readShort();
                        //   var _loc2_:int = 0;
                        //   while(_loc2_ < _loc1_)
                        //   {
                        //      this._modelList[_loc2_] = readBean(CosmicGateModelBean) as CosmicGateModelBean;
                        //      _loc2_++;
                        //   }
                        //   this._buytimes = readInt();
                        //   return true;
                        //}
                        break;
                    case 525246:
                    case 526217:
                    case 527295:
                    case 528330:
                        break;
                    case 525242:
                        {
                            int _isSendMonster = (int)barr[8];
                            int _isSendPlayer = (int)barr[9];
                            outstr = string.Format("_isSendMonster={0};_isSendPlayer={1}", _isSendMonster, _isSendPlayer);
                        }
                        break;
                    case 528316:
                        {
                            int _activityId = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("type={0}", _activityId);
                        } break;

                    case 529207:
                        {
                            LongC itemId = item.readLong();
                            outstr = string.Format("itemid={0},{1}", Convert.ToString(itemId.high, 16), Convert.ToString(itemId.low, 16));
                        }
                        break;
                    case 529220:
                        {
                            // MessageDescrypt m = new MessageDescrypt() { _pos = 8, _barr = barr };
                            string str = item.readString();
                            XscbInfo xs = (XscbInfo)JsonManager.JsonToObject(str, typeof(XscbInfo));
                            outstr = "JsonStr=" + str;
                        } break;
                    case 535204:
                        {
                            int zoneId = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("_activityId={0}", zoneId);
                        }
                        break;
                    case 535298:
                        {
                            int aid = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("aid={0}", aid);
                        }
                        break;
                    case 538222:
                        {
                            int type = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("type={0}", type);
                        }
                        break;
                    case 538248:
                        {
                            int type = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("type={0}", type);
                        }
                        break;
                    case 540290:
                        {
                            //BRead m = new MessageDescrypt() { _barr = barr, _pos = 8 };
                            List<LongC> booksList = item.readObjList<LongC, LongC>();
                            List<LongC> elementsFmList = item.readObjList<LongC, LongC>();
                            List<LongC> elementsList = item.readObjList<LongC, LongC>();
                            List<LongC> shieldsList = item.readObjList<LongC, LongC>();
                            List<LongC> fruitsList = item.readObjList<LongC, LongC>();
                            List<LongC> shenyinList = item.readObjList<LongC, LongC>();
                            outstr = string.Format("booksList.cnt={0};elementsFmList.cnt={1};elementsList.cnt={2};shieldsList.cnt={3};fruitsList.cnt={4};shenyinList.cnt={5}",
                                booksList.Count, elementsFmList.Count, elementsList.Count, shieldsList.Count, fruitsList.Count, shenyinList.Count);
                        } break;
                    case 527235:
                    case 535219:
                    case 538297:
                    case 539219:
                    case 539226:
                    case 540213:
                    case 540224:
                    case 540261:
                    case 580202:
                    case 583201:
                    case 600100:
                    case 600102:
                    case 600106:
                    case 600205:
                    case 600207:
                        break;
                    case 600217:
                        {
                            int type = Bean.readRawVarint32(barr, 8, ref endpos);
                            outstr = string.Format("type={0}", type);
                        }
                        break;

                    default:
                        // 打印字符串
                        outstr = string.Format("hexstring={1}", nCmd, Int2Hexstring(barr));
                        break;
                }
                #endregion
                ConsoleLog.Instance.writeInformationLog(cmdstr + outstr);
                return cmdstr + outstr;
            }
            catch (Exception ex)
            {
                ConsoleLog.Instance.writeErrorLog("send hexstr=" + Int2Hexstring(barr) + ";ErrMsg=" + ex.Message + "ST=" + ex.StackTrace);
                return "Exception occured";
            }
        }

        public static string Int2Hexstring(byte[] barr)
        {
            if (barr == null)
                return "";
            string retstr = "";
            for (int i = 0; i < barr.Length; i++)
            {
                retstr += "0x"+Convert.ToString(barr[i], 16)+",";
            }
            return retstr;
        }

        public static void test()
        {
            byte[] ping = Encoding.UTF8.GetBytes("你的密码是什么?");
        }
        public static List<Cmd> m_list = new List<Cmd>();

        public static int ReadInt(byte[] value, int npos)
        {
            int nval = (int)(value[npos]|value[npos + 1] << 8);
            return (int)nval;
        }
    }

    public class Cmd
    {
        public int cmd { get; set; }
        public string cmdStr { get; set; }
        public string note { get; set; }
    }
}

/*
 * data[4:4] contains 03:0d:a5
tcp.port==8050&&ip.src==183.131.77.103&&tcp.len>0&&!(data[4:4] contains 01:92:c1)&&!(data[4:4] contains 01:8e:d5)&&!(data[4:4] contains 01:8a:f7)&&!(data[4:4] contains 01:8e:d6)&&!(data[4:4] contains 01:92:cf)&&!(data[4:4] contains 01:bd:bd)&&!(data[4:4] contains 01:8a:f3)&&!(data[4:4] contains 01:8a:f2)&&!(data[4:4] contains 01:87:0c)&&!(data[4:4] contains 01:8a:ee)&&!(data[4:4] contains 01:8a:ef)&&!(data[4:4] contains 09:27:c9)&&!(data[4:4] contains 01:92:bd)&&!(data[4:4] contains 07:c8:44)&&!(data[4:4] contains 01:aa:2e)&&!(data[4:4] contains 08:0a:b1)&&!(data[4:4] contains 07:d0:09)&&!(data[4:4] contains 01:b9:cf)&&!(data[4:4] contains 01:96:a7)&&!(data[4:4] contains 01:8a:fb)&&!(data[4:4] contains 01:aa:32)&&!(data[4:4] contains 01:f4:74)&&!(data[4:4] contains 03:0d:a5)&&!(data[4:4] contains 01:87:05)&&!(data[4:4] contains 08:32:75)&&!(data[4:4] contains 09:27:ec)&&!(data[4:4] contains 08:3d:78)&&!(data[4:4] contains 07:a9:55)
tcp.port==8050&&ip.src==183.131.77.103&&tcp.len>0&&!(data[4:4] contains 01:92:c1)&&!(data[4:4] contains 01:8e:d5)&&!(data[4:4] contains 01:8a:f7)&&!(data[4:4] contains 01:8e:d6)&&!(data[4:4] contains 01:92:cf)&&!(data[4:4] contains 01:bd:bd)&&!(data[4:4] contains 01:8a:f3)&&!(data[4:4] contains 01:8a:f2)&&!(data[4:4] contains 01:87:0c)&&!(data[4:4] contains 01:8a:ee)&&!(data[4:4] contains 01:8a:ef)&&!(data[4:4] contains 09:27:c9)&&!(data[4:4] contains 01:92:bd)&&!(data[4:4] contains 07:c8:44)&&!(data[4:4] contains 01:aa:2e)&&!(data[4:4] contains 08:0a:b1)&&!(data[4:4] contains 07:d0:09)&&!(data[4:4] contains 01:b9:cf)&&!(data[4:4] contains 01:96:a7)&&!(data[4:4] contains 01:8a:fb)&&!(data[4:4] contains 01:aa:32)&&!(data[4:4] contains 01:f4:74)&&!(data[4:4] contains 03:0d:a5)&&!(data[4:4] contains 01:87:05)&&!(data[4:4] contains 08:32:75)&&!(data[4:4] contains 09:27:ec)&&!(data[4:4] contains 08:3d:78)&&!(data[4:4] contains 07:a9:55)&&!(data[4:4] contains 01:e4:ce)&&!(data[4:4] contains 01:e4:c5)&&!(data[4:4] contains 01:92:bf)
 tcp.port==8050&&ip.src==183.131.77.103&&tcp.len>0&&!(data[4:4] contains 01:92:c1)&&!(data[4:4] contains 01:8e:d5)&&!(data[4:4] contains 01:8a:f7)&&!(data[4:4] contains 01:8e:d6)&&!(data[4:4] contains 01:92:cf)&&!(data[4:4] contains 01:bd:bd)&&!(data[4:4] contains 01:8a:f3)&&!(data[4:4] contains 01:8a:f2)&&!(data[4:4] contains 01:87:0c)&&!(data[4:4] contains 01:8a:ee)&&!(data[4:4] contains 01:8a:ef)&&!(data[4:4] contains 09:27:c9)&&!(data[4:4] contains 01:92:bd)&&!(data[4:4] contains 07:c8:44)&&!(data[4:4] contains 01:aa:2e)&&!(data[4:4] contains 08:0a:b1)&&!(data[4:4] contains 07:d0:09)&&!(data[4:4] contains 01:b9:cf)&&!(data[4:4] contains 01:96:a7)&&!(data[4:4] contains 01:8a:fb)&&!(data[4:4] contains 01:aa:32)&&!(data[4:4] contains 01:f4:74)&&!(data[4:4] contains 03:0d:a5)&&!(data[4:4] contains 01:87:05)&&!(data[4:4] contains 08:32:75)&&!(data[4:4] contains 09:27:ec)&&!(data[4:4] contains 08:3d:78)&&!(data[4:4] contains 07:a9:55)&&!(data[4:4] contains 01:e4:ce)&&!(data[4:4] contains 01:e4:c5)&&!(data[4:4] contains 01:92:bf)&&!(data[4:4] contains 08:35:c0)&&!(data[4:4] contains 01:87:06)&&!(data[4:4] contains 07:cc:1a)&&!(data[4:4] contains 01:bd:c1)&&!(data[4:4] contains 01:ec:97)&&!(data[4:4] contains 01:8a:f6)&&!(data[4:4] contains 01:8b:05)&&!(data[4:4] contains 01:8b:03)&&!(data[4:4] contains 07:cc:21)&&!(data[4:4] contains 08:06:c1)&&!(data[4:4] contains 01:96:a9)&&!(data[4:4] contains 01:8a:fc)&&!(data[4:4] contains 02:27:2d)
 tcp.port==8050&&ip.src==183.131.77.103&&tcp.len>0&&!(data[4:4] contains 01:92:c1)&&!(data[4:4] contains 01:8e:d5)&&!(data[4:4] contains 01:8a:f7)&&!(data[4:4] contains 01:8e:d6)&&!(data[4:4] contains 01:92:cf)&&!(data[4:4] contains 01:bd:bd)&&!(data[4:4] contains 01:8a:f3)&&!(data[4:4] contains 01:8a:f2)&&!(data[4:4] contains 01:87:0c)&&!(data[4:4] contains 01:8a:ee)&&!(data[4:4] contains 01:8a:ef)&&!(data[4:4] contains 09:27:c9)&&!(data[4:4] contains 01:92:bd)&&!(data[4:4] contains 07:c8:44)&&!(data[4:4] contains 01:aa:2e)&&!(data[4:4] contains 08:0a:b1)&&!(data[4:4] contains 07:d0:09)&&!(data[4:4] contains 01:b9:cf)&&!(data[4:4] contains 01:96:a7)&&!(data[4:4] contains 01:8a:fb)&&!(data[4:4] contains 01:aa:32)&&!(data[4:4] contains 01:f4:74)&&!(data[4:4] contains 03:0d:a5)&&!(data[4:4] contains 01:87:05)&&!(data[4:4] contains 08:32:75)&&!(data[4:4] contains 09:27:ec)&&!(data[4:4] contains 08:3d:78)&&!(data[4:4] contains 07:a9:55)&&!(data[4:4] contains 01:e4:ce)&&!(data[4:4] contains 01:e4:c5)&&!(data[4:4] contains 01:92:bf)&&!(data[4:4] contains 08:35:c0)&&!(data[4:4] contains 01:87:06)&&!(data[4:4] contains 07:cc:1a)&&!(data[4:4] contains 01:bd:c1)&&!(data[4:4] contains 01:ec:97)&&!(data[4:4] contains 01:8a:f6)&&!(data[4:4] contains 01:8b:05)&&!(data[4:4] contains 01:8b:03)&&!(data[4:4] contains 07:cc:21)&&!(data[4:4] contains 08:06:c1)&&!(data[4:4] contains 01:96:a9)&&!(data[4:4] contains 01:8a:fc)&&!(data[4:4] contains 02:27:2d)&&!(data[4:4] contains 01:8e:d9)&&!(data[4:4] contains 01:96:a6)&&!(data[4:4] contains 01:96:a8)&&!(data[4:4] contains 01:95:d3)&&!(data[4:4] contains 01:92:c6)&&!(data[4:4] contains 01:92:da)&&!(data[4:4] contains 08:8b:81)&&!(data[4:4] contains 01:f4:6e)&&!(data[4:4] contains 01:ec:95)&&!(data[4:4] contains 08:0a:da)
 tcp.port==8050&&ip.src==183.131.77.103&&tcp.len>0&&!(data[4:4] contains 01:92:c1)&&!(data[4:4] contains 01:8e:d5)&&!(data[4:4] contains 01:8a:f7)&&!(data[4:4] contains 01:8e:d6)&&!(data[4:4] contains 01:92:cf)&&!(data[4:4] contains 01:bd:bd)&&!(data[4:4] contains 01:8a:f3)&&!(data[4:4] contains 01:8a:f2)&&!(data[4:4] contains 01:87:0c)&&!(data[4:4] contains 01:8a:ee)&&!(data[4:4] contains 01:8a:ef)&&!(data[4:4] contains 09:27:c9)&&!(data[4:4] contains 01:92:bd)&&!(data[4:4] contains 07:c8:44)&&!(data[4:4] contains 01:aa:2e)&&!(data[4:4] contains 08:0a:b1)&&!(data[4:4] contains 07:d0:09)&&!(data[4:4] contains 01:b9:cf)&&!(data[4:4] contains 01:96:a7)&&!(data[4:4] contains 01:8a:fb)&&!(data[4:4] contains 01:aa:32)&&!(data[4:4] contains 01:f4:74)&&!(data[4:4] contains 03:0d:a5)&&!(data[4:4] contains 01:87:05)&&!(data[4:4] contains 08:32:75)&&!(data[4:4] contains 09:27:ec)&&!(data[4:4] contains 08:3d:78)&&!(data[4:4] contains 07:a9:55)&&!(data[4:4] contains 01:e4:ce)&&!(data[4:4] contains 01:e4:c5)&&!(data[4:4] contains 01:92:bf)&&!(data[4:4] contains 08:35:c0)&&!(data[4:4] contains 01:87:06)&&!(data[4:4] contains 07:cc:1a)&&!(data[4:4] contains 01:bd:c1)&&!(data[4:4] contains 01:ec:97)&&!(data[4:4] contains 01:8a:f6)&&!(data[4:4] contains 01:8b:05)&&!(data[4:4] contains 01:8b:03)&&!(data[4:4] contains 07:cc:21)&&!(data[4:4] contains 08:06:c1)&&!(data[4:4] contains 01:96:a9)&&!(data[4:4] contains 01:8a:fc)&&!(data[4:4] contains 02:27:2d)&&!(data[4:4] contains 01:8e:d9)&&!(data[4:4] contains 01:96:a6)&&!(data[4:4] contains 01:96:a8)&&!(data[4:4] contains 01:95:d3)&&!(data[4:4] contains 01:92:c6)&&!(data[4:4] contains 01:92:da)&&!(data[4:4] contains 08:8b:81)&&!(data[4:4] contains 01:f4:6e)&&!(data[4:4] contains 01:ec:95)&&!(data[4:4] contains 08:0a:da)&&!(data[4:4] contains 01:ae:15)&&!(data[4:4] contains 08:12:da)&&!(data[4:4] contains 08:03:0a)&&!(data[4:4] contains 01:96:ab)&&!(data[4:4] contains 01:8b:04)
 * * * * * */

/*
 tcp.port==8050&&ip.dst==183.131.77.103&&tcp.len>0&&!(data[4:4] contains 01:8f:39)&&!(data[4:4] contains 01:8b:51)&&!(data[4:4] contains 01:87:6e)&&!(data[4:4] contains 01:8b:55)&&!(data[4:4] contains 08:03:ba)&&!(data[4:4] contains 07:c8:fa)&&!(data[4:4] contains 01:f4:d5)&&!(data[4:4] contains 08:36:88)&&!(data[4:4] contains 02:33:4a)&&!(data[4:4] contains 01:97:13)&&!(data[4:4] contains 01:8b:5b)&&!(data[4:4] contains 01:97:10)&&!(data[4:4] contains 01:d5:99)&&!(data[4:4] contains 01:87:6a)&&!(data[4:4] contains 02:87:6a)&&!(data[4:4] contains 01:9e:d9)&&!(data[4:4] contains 01:8b:5a)&&!(data[4:4] contains 01:8b:57)&&!(data[4:4] contains 01:97:0b)&&!(data[4:4] contains 01:d5:8a)&&!(data[4:4] contains 01:8b:56)&&!(data[4:4] contains 01:ec:fa)&&!(data[4:4] contains 02:00:88)&&!(data[4:4] contains 08:36:6e)&&!(data[4:4] contains 01:e4:f9)&&!(data[4:4] contains 01:9a:f7)&&!(data[4:4] contains 01:97:0d)&&!(data[4:4] contains 01:e4:f7)&&!(data[4:4] contains 08:13:37)&&!(data[4:4] contains 07:a9:bb)
  tcp.port==8050&&ip.dst==183.131.77.103&&tcp.len>0&&!(data[4:4] contains 01:8f:39)&&!(data[4:4] contains 01:8b:51)&&!(data[4:4] contains 01:87:6e)&&!(data[4:4] contains 01:8b:55)&&!(data[4:4] contains 08:03:ba)&&!(data[4:4] contains 07:c8:fa)&&!(data[4:4] contains 01:f4:d5)&&!(data[4:4] contains 08:36:88)&&!(data[4:4] contains 02:33:4a)&&!(data[4:4] contains 01:97:13)&&!(data[4:4] contains 01:8b:5b)&&!(data[4:4] contains 01:97:10)&&!(data[4:4] contains 01:d5:99)&&!(data[4:4] contains 01:87:6a)&&!(data[4:4] contains 02:87:6a)&&!(data[4:4] contains 01:9e:d9)&&!(data[4:4] contains 01:8b:5a)&&!(data[4:4] contains 01:8b:57)&&!(data[4:4] contains 01:97:0b)&&!(data[4:4] contains 01:d5:8a)&&!(data[4:4] contains 01:8b:56)&&!(data[4:4] contains 01:ec:fa)&&!(data[4:4] contains 02:00:88)&&!(data[4:4] contains 08:36:6e)&&!(data[4:4] contains 01:e4:f9)&&!(data[4:4] contains 01:9a:f7)&&!(data[4:4] contains 01:97:0d)&&!(data[4:4] contains 01:e4:f7)&&!(data[4:4] contains 08:13:37)&&!(data[4:4] contains 07:a9:bb)&&!(data[4:4] contains 01:ec:f9)&&!(data[4:4] contains 08:8c:49)&&!(data[4:4] contains 01:95:d2)&&!(data[4:4] contains 08:03:d1)&&!(data[4:4] contains 08:3e:88)&&!(data[4:4] contains 01:f4:d3)&&!(data[4:4] contains 01:a2:c3)&&!(data[4:4] contains 01:f4:cc)&&!(data[4:4] contains 08:13:44)






 */