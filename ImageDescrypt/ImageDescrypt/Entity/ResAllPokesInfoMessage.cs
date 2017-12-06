using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    class ResAllPokesInfoMessage:Bean
    {
      private List<PokemonInfo> _PokemonInfos;
      private int _pokemonsNum;
      private LongC _onFightId;

      override public void reading()
      {
          this._PokemonInfos = readObjList<PokemonInfo, PokemonInfo>();// readBean(PokemonInfo) as PokemonInfo;

          this._pokemonsNum = readInt();
          this._onFightId = readLong();
      }

      public override string getPrintStr()
      {
          string str="";
          for (int i = 0; i < _PokemonInfos.Count; i++)
              str += _PokemonInfos[i].getPrintStr()+"\n";

          string outstr = string.Format("_PokemonInfos.cnt={0};_pokemonsNum={1};_onFightId={2};_PokemonInfosList:{3}"
          , _PokemonInfos.Count, _pokemonsNum, _onFightId.toString(), str);

          return outstr;
      }
    }

       public class PokemonInfo : Bean
   {
           private LongC _id;
      private int _modelId;
      
      private int _breed;
      
      private int _quality;
      
      private int _level;
      
      private LongC _exp;
      
      private List<GoodsAttribute> _attributes;
      
      private List<GoodsAttribute> _basicGrowth;
      
      private List<GoodsAttribute> _lianhuaGrowth;
      
      private List<ItemInfo> _equips;
      
      private int _isChange;
      
      private int _skillNum;
      
      private String _hhId;
      
      private List<CSSkillInfo> _skills;
      
      private int _changeLevel;
      
      private int _changeper;

      override public void reading()
      {
          this._id = readLong();
          this._modelId = readInt();
          this._breed = readInt();
          this._quality = readInt();
          this._level = readInt();
          this._exp = readLong();

          this._attributes = readObjList<GoodsAttribute, GoodsAttribute>(); ;// readBean(GoodsAttribute) as GoodsAttribute;
          this._basicGrowth= readObjList<GoodsAttribute, GoodsAttribute>();// readBean(GoodsAttribute) as GoodsAttribute;
          this._lianhuaGrowth = readObjList < GoodsAttribute ,GoodsAttribute>();//> readBean() as GoodsAttribute;

          this._isChange = readByte();
          this._changeper = readInt();
          this._skillNum = readInt();
          this._skills = readObjList<CSSkillInfo, CSSkillInfo>();// readBean() as CSSkillInfo;

          this._changeLevel = readInt();
          this._equips = readObjList<ItemInfo, ItemInfo>();// readBean(ItemInfo) as ;

          this._hhId = readString();
      }

      public override string getPrintStr()
      {
          string outstr = string.Format("_id={0};_modelId={1};_breed={2};_quality={3};_level={4};_exp={5};_attributes.cnt={6};_basicGrowth.cnt={7};_lianhuaGrowth.cnt={8};_equips.cnt={9};_isChange={10};_skillNum={11};_hhId={12};_skills.cnt={13};_changeLevel={14};_changeper={15};"
          , _id.toString(), _modelId, _breed, _quality, _level, _exp.toString(), _attributes.Count, _basicGrowth.Count, _lianhuaGrowth.Count, _equips.Count, _isChange, _skillNum, _hhId, _skills.Count, _changeLevel, _changeper);

          return outstr;
      }
       }

       public class CSSkillInfo : Bean
   {
      private LongC _skillId;
      
      private int _skillModelId;
      
      private int _skillLevel;
      
      public int skillCDTime;
      
      private List<SkillLevelInfo> _skillAddLevels;

      override public void reading()
      {
          this._skillId = readLong();
          this._skillModelId = readInt();
          this._skillLevel = readInt();
          this.skillCDTime = readInt();
          _skillAddLevels =readObjList<SkillLevelInfo,SkillLevelInfo>(); //readBean() as SkillLevelInfo;
      }


       }

       public class SkillLevelInfo : Bean
       {
           private int _key;
           private int _level;

           override public void reading()
           {
               this._key = readInt();
               this._level = readInt();
           }
       }
}
