using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageDescrypt.Entity;
using XRFAppPlat.Logger;

namespace ImageDescrypt
{
    public class Bean
    {
        public int _pos = 0;
        public byte[] _barr = null;

        public T readBean<T>() where T : new()
        {
            T tt;
            if (typeof(T) == typeof(LongC))
            {
                LongC _itemId = readLong();
                tt = (T)Convert.ChangeType(_itemId, typeof(T));
            }
            else if (typeof(T) == typeof(string))
            {
                string _itemId = readString();
                tt = (T)Convert.ChangeType(_itemId, typeof(T));
            }
            else if (typeof(T) == typeof(byte))
            {
                int val = readByte();
                tt = (T)Convert.ChangeType(val, typeof(T));
            }
            else if (typeof(T) == typeof(BuffPara))
            {
                BuffPara bb = new BuffPara();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));

            }
            else if (typeof(T) == typeof(MailSummaryInfo))
            {
                MailSummaryInfo bb = new MailSummaryInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));            }
            else if (typeof(T) == typeof(AttackResultInfos))
            {
                AttackResultInfos bb = new AttackResultInfos();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(GoodsAttribute))
            {
                GoodsAttribute bb = new GoodsAttribute();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(Slot))
            {
                Slot bb = new Slot();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(GemInfo))
            {
                GemInfo bb = new GemInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(GoodsInfoRes))
            {
                GoodsInfoRes bb = new GoodsInfoRes();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(BossEventInfo))
            {
                BossEventInfo bb = new BossEventInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(PandoraEventInfo))
            {
                PandoraEventInfo bb = new PandoraEventInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(ZoneTeamInfo))
            {
                ZoneTeamInfo bb = new ZoneTeamInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(CharacterInfo))
            {
                CharacterInfo bb = new CharacterInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(SkillLevelInfo))
            {
                SkillLevelInfo bb = new SkillLevelInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(CSSkillInfo))
            {
                CSSkillInfo bb = new CSSkillInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(PokemonInfo))
            {
                PokemonInfo bb = new PokemonInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(ActivityItemInfo))
            {
                ActivityItemInfo bb = new ActivityItemInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(CSMonsterInfo))
            {
                CSMonsterInfo bb = new CSMonsterInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(DropGoodsInfo))
            {
                DropGoodsInfo bb = new DropGoodsInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(HorseSkillBean))
            {
                HorseSkillBean bb = new HorseSkillBean();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(CSPlayerInfo))
            {
                CSPlayerInfo bb = new CSPlayerInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(PetInfo))
            {
                PetInfo bb = new PetInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(NpcInfo))
            {
                NpcInfo bb = new NpcInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(EffectInfo))
            {
                EffectInfo bb = new EffectInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(SummonPetInfo))
            {
                SummonPetInfo bb = new SummonPetInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(CSBuffInfo))
            {
                CSBuffInfo bb = new CSBuffInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(CSHorseSkillInfo))
            {
                CSHorseSkillInfo bb = new CSHorseSkillInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(EquipInfo))
            {
                EquipInfo bb = new EquipInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(EquipAttribute))
            {
                EquipAttribute bb = new EquipAttribute();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(CSHorseInfo))
            {
                CSHorseInfo bb = new CSHorseInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(UseInfoBean))
            {
                UseInfoBean bb = new UseInfoBean();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(CosmicGateBean))
            {
                CosmicGateBean bb = new CosmicGateBean();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(ItemInfo))
            {
                ItemInfo bb = new ItemInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));
            }
            else if (typeof(T) == typeof(Position))
            {
                Position bb = new Position();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));//
            }
            else if (typeof(T) == typeof(SoulfactInfo))
            {
                SoulfactInfo bb = new SoulfactInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));//DetailActivityInfo
            }
            else if (typeof(T) == typeof(DetailActivityInfo))
            {
                DetailActivityInfo bb = new DetailActivityInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));//MainTaskInfo
            }
            else if (typeof(T) == typeof(ImageDescrypt.Entity.MainTaskInfo))
            {
                ImageDescrypt.Entity.MainTaskInfo bb = new ImageDescrypt.Entity.MainTaskInfo();
                bb._barr = this._barr;
                bb._pos = this._pos;
                bb.reading();
                this._pos = bb._pos;
                tt = (T)Convert.ChangeType(bb, typeof(T));//
            }
            else
            {
                tt = default(T);
                ConsoleLog.Instance.writeInformationLog("Class can't be read="+typeof(T).ToString());
            }
            /*
          Type type = Type.GetType(className);
          T ib = type.Assembly.CreateInstance(className) as T;
            */
            //T tt = new T();
            //Bean _loc2_ = (Bean)Convert.ChangeType(tt, typeof(Bean));
            //_loc2_._barr = this._barr;
            //_loc2_._pos = this._pos;
            //_loc2_.reading();
            //this._pos = _loc2_._pos;
            return (T)Convert.ChangeType(tt, typeof(T));
        }
        /*
         readUTF():String
        writeUTF(value:String):void
        这个格式分两部分: head + body
        head:一个16为的整数表示之后字符串的字节数.
        body:字符串的字节流. (这里的汉字用3个字节表示).
         */
        public string readString()
        {
            try
            {
                if (_pos == 0)
                    _pos = 8;

                if (_barr == null)
                    return "";

                int nLen = (int)(_barr[_pos] << 8) + (int)_barr[_pos + 1];
                if (nLen > _barr.Length - _pos)
                {
                    string s = Encoding.GetEncoding("UTF-8").GetString(_barr.Skip(_pos).ToArray());
                    return "";
                }
                byte[] arr = new byte[nLen];
                Array.Copy(_barr, _pos + 2, arr, 0, nLen);
                string str = System.Text.Encoding.UTF8.GetString(arr);
                _pos += nLen + 2;
                return str;
            }
            catch (Exception ex)
            {
                ConsoleLog.Instance.writeInformationLog("ErrMsg="+ex.Message+";ST="+ex.StackTrace);
                return "Err";
            }
        }

        public virtual void reading()
         {

         }

        public virtual string getPrintStr()
        {
            return "";
        }

        public int readByte()
        {
            int val = ReadByte(_barr, _pos);
            _pos++;
            return val;
        }

        public LongC readLong()
        {
            LongC val = readRawVarint64(_barr, _pos, ref _pos);
            return val;
        }

        public List<T2> readObjList<T1, T2>()
        {
            if (_pos == 0)
                _pos = 8;

            int _loc2_ = readShort();//ReadShort(_barr, _pos);
            int _loc1_ = 0;
            //int endpos = _pos + 2;
            List<T2> thelst = new List<T2>();
            while (_loc1_ < _loc2_ && this._pos < this._barr.Length)
            {
                #region xxx
                if (typeof(T1) == typeof(LongC))
                {
                    LongC _itemId = readLong();
                    T2 tt = (T2)Convert.ChangeType(_itemId, typeof(T2));
                    thelst.Add(tt);
                }
                else if (typeof(T1) == typeof(Int32) || typeof(T1) == typeof(int))
                {
                    int _itemId = readInt();
                    T2 tt = (T2)Convert.ChangeType(_itemId, typeof(T2));
                    thelst.Add(tt);
                }
                else if (typeof(T1) == typeof(string))
                {
                    string _itemId = readString();
                    T2 tt = (T2)Convert.ChangeType(_itemId, typeof(T2));
                    thelst.Add(tt);
                }
                else if (typeof(T1) == typeof(byte) || typeof(T1) == typeof(Byte))
                {
                    int val = readByte();
                    T2 tt = (T2)Convert.ChangeType(val, typeof(T2));
                    thelst.Add(tt);//
                }
                else if (typeof(T1) == typeof(SoulfactInfo))
                {
                    SoulfactInfo bb = new SoulfactInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);
                }
                else if (typeof(T1) == typeof(BuffPara))
                {
                    BuffPara bb = new BuffPara();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt=(T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);
                }
                else if (typeof(T1) == typeof(Position))
                {
                    Position bb = new Position();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);
                }
                else if (typeof(T1) == typeof(MailSummaryInfo))
                {
                    MailSummaryInfo bb = new MailSummaryInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);
                }
                else if (typeof(T1) == typeof(AttackResultInfos))
                {
                    AttackResultInfos bb = new AttackResultInfos();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);
                }
                else if (typeof(T1) == typeof(GoodsAttribute))
                {
                    GoodsAttribute bb = new GoodsAttribute();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);
                }
                else if (typeof(T1) == typeof(Slot))
                {
                    Slot bb = new Slot();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//GemInfo
                }
                else if (typeof(T1) == typeof(GemInfo))
                {
                    GemInfo bb = new GemInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//GoodsInfoRes
                }
                else if (typeof(T1) == typeof(GoodsInfoRes))
                {
                    GoodsInfoRes bb = new GoodsInfoRes();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//BossEventInfo
                }
                else if (typeof(T1) == typeof(BossEventInfo))
                {
                    BossEventInfo bb = new BossEventInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//BossEventInfo
                }
                else if (typeof(T1) == typeof(PandoraEventInfo))
                {
                    PandoraEventInfo bb = new PandoraEventInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//ZoneTeamInfo
                }
                else if (typeof(T1) == typeof(ZoneTeamInfo))
                {
                    ZoneTeamInfo bb = new ZoneTeamInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//CharacterInfo
                }
                else if (typeof(T1) == typeof(CharacterInfo))
                {
                    CharacterInfo bb = new CharacterInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//SkillLevelInfo
                }
                else if (typeof(T1) == typeof(SkillLevelInfo))
                {
                    SkillLevelInfo bb = new SkillLevelInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//CSSkillInfo
                }
                else if (typeof(T1) == typeof(CSSkillInfo))
                {
                    CSSkillInfo bb = new CSSkillInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//PokemonInfo
                }
                else if (typeof(T1) == typeof(PokemonInfo))
                {
                    PokemonInfo bb = new PokemonInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//ActivityItemInfo
                }
                else if (typeof(T1) == typeof(ActivityItemInfo))
                {
                    ActivityItemInfo bb = new ActivityItemInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//CSMonsterInfo
                }
                else if (typeof(T1) == typeof(CSMonsterInfo))
                {
                    CSMonsterInfo bb = new CSMonsterInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//DropGoodsInfo
                }
                else if (typeof(T1) == typeof(DropGoodsInfo))
                {
                    DropGoodsInfo bb = new DropGoodsInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//HorseSkillBean
                }
                else if (typeof(T1) == typeof(HorseSkillBean))
                {
                    HorseSkillBean bb = new HorseSkillBean();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//CSPlayerInfo
                }
                else if (typeof(T1) == typeof(CSPlayerInfo))
                {
                    CSPlayerInfo bb = new CSPlayerInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//PetInfo
                }
                else if (typeof(T1) == typeof(PetInfo))
                {
                    PetInfo bb = new PetInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//NpcInfo
                }
                else if (typeof(T1) == typeof(NpcInfo))
                {
                    NpcInfo bb = new NpcInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//EffectInfo
                }
                else if (typeof(T1) == typeof(EffectInfo))
                {
                    EffectInfo bb = new EffectInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//SummonPetInfo
                }
                else if (typeof(T1) == typeof(SummonPetInfo))
                {
                    SummonPetInfo bb = new SummonPetInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//CSBuffInfo
                }
                else if (typeof(T1) == typeof(CSBuffInfo))
                {
                    CSBuffInfo bb = new CSBuffInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//CSHorseSkillInfo
                }
                else if (typeof(T1) == typeof(CSHorseSkillInfo))
                {
                    CSHorseSkillInfo bb = new CSHorseSkillInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//EquipInfo
                }
                else if (typeof(T1) == typeof(EquipInfo))
                {
                    EquipInfo bb = new EquipInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//EquipAttribute
                }
                else if (typeof(T1) == typeof(EquipAttribute))
                {
                    EquipAttribute bb = new EquipAttribute();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//CSHorseInfo
                }
                else if (typeof(T1) == typeof(CSHorseInfo))
                {
                    CSHorseInfo bb = new CSHorseInfo();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//UseInfoBean
                }
                else if (typeof(T1) == typeof(UseInfoBean))
                {
                    UseInfoBean bb = new UseInfoBean();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//CosmicGateBean
                }
                else if (typeof(T1) == typeof(CosmicGateBean))
                {
                    CosmicGateBean bb = new CosmicGateBean();
                    bb._barr = this._barr;
                    bb._pos = this._pos;
                    bb.reading();
                    this._pos = bb._pos;
                    T2 tt = (T2)Convert.ChangeType(bb, typeof(T2));
                    thelst.Add(tt);//
                }
                else
                {
                    ConsoleLog.Instance.writeInformationLog("readobjlist Class can't be read=" + typeof(T1).ToString());
                }
#endregion
                _loc1_++;
            }
            //_pos = endpos;

            return thelst;
        }

        //        public static function readLong(param1:ByteArray) : long
        //{
        //   LongC _loc2_ = null;
        //   if(compress)
        //   {
        //      return decodeZigZag64(readRawVarint64(param1));
        //   }
        //   _loc2_ = new long();
        //   _loc2_.high = param1.readUnsignedInt();
        //   _loc2_.low = param1.readUnsignedInt();
        //   return _loc2_;
        //}


        public int readInt()
        {
            int val = readRawVarint32(_barr, _pos, ref _pos);
            return val;
        }

        public int readShort()
        {
            int val = ReadShort(_barr, _pos);
            _pos += 2;
            return val;
        }

        public static LongC readRawVarint64(byte[] param1, int curpos, ref int endpos)
        {
            int _loc4_ = 0;
            LongC _loc5_ = null;
            int _loc2_ = 0;
            LongC _loc3_ = new LongC();
            while (_loc2_ < 64)
            {
                _loc4_ = param1[curpos++];
                _loc5_ = new LongC((uint)(_loc4_ & 127), 0);
                _loc5_ = _loc5_.shiftLeft((uint)_loc2_);
                _loc3_ = _loc3_.or(_loc5_);
                if ((_loc4_ & 128) == 0)
                {
                    endpos = curpos;
                    return _loc3_;
                }
                endpos = curpos;
                _loc2_ = _loc2_ + 7;
            }
            return _loc3_;
        }

        public static string readString(byte[] barr, int curpos, ref int endpos)
        {
            string str = "";
            int nLen = (int)(barr[curpos] << 8) + (int)barr[curpos + 1];
            if (nLen != barr.Length - curpos - 2)
                return str;

            byte[] tempbarr = new byte[nLen];
            Array.Copy(barr, curpos + 2, tempbarr, 0, nLen);
            str = System.Text.Encoding.UTF8.GetString(tempbarr);
            endpos = curpos + 2 + nLen;
            return str;
        }

        public static int ReadByte(byte[] barr, int curpos)
        {
            return (int)barr[curpos];
        }

        public static int ReadShort(byte[] barr, int curpos)
        {
            int value = (int)barr[curpos] + (int)barr[curpos + 1];
            return value;
        }

        public static int readRawVarint32(byte[] param1, int curpos, ref int endpos)
        {
            #region 读取整形
            endpos = curpos;
            int _loc4_ = 0;
            sbyte sb = (sbyte)param1[curpos];
            // int _loc2_ = Convert.ToInt32(sb);
            if (sb >= 0)
            {
                endpos = curpos + 1;
                return sb;
            }
            int _loc3_ = sb & 127;
            if ((sb = (sbyte)param1[curpos + 1]) >= 0)
            {
                _loc3_ = _loc3_ | sb << 7;
                endpos = curpos + 2;
            }
            else
            {
                _loc3_ = _loc3_ | (sb & 127) << 7;
                if ((sb = (sbyte)param1[curpos + 2]) >= 0)
                {
                    _loc3_ = _loc3_ | sb << 14;
                    endpos = curpos + 3;
                }
                else
                {
                    _loc3_ = _loc3_ | (sb & 127) << 14;
                    if ((sb = (sbyte)param1[curpos + 3]) >= 0)
                    {
                        _loc3_ = _loc3_ | sb << 21;
                        endpos = curpos + 4;
                    }
                    else
                    {
                        _loc3_ = _loc3_ | (sb & 127) << 21;
                        _loc3_ = _loc3_ | (sb = (sbyte)param1[curpos + 4]) << 28;
                        if (sb < 0)
                        {
                            _loc4_ = 0;
                            while (_loc4_ < 5)
                            {
                                if ((sbyte)param1[curpos + 5] >= 0)
                                {
                                    endpos = curpos + 5;
                                    return _loc3_;
                                }
                                _loc4_++;
                            }
                        }
                    }
                }
            }
            return _loc3_;
            #endregion
        }
    }
}
