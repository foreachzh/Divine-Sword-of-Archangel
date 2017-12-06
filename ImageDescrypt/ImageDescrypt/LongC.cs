using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ImageDescrypt
{
    public class LongC:Binary64
    {
          
      public static  LongC ZERO = new LongC();
      
      public static  LongC ONE= new LongC(1,0);

      public static  LongC SIGN = new LongC(0xffffffff, 0xffffffff);
      
      public static  LongC MARK = new LongC(4294967168,4294967295);
       
      public LongC(uint param1= 0,uint param2= 0):base(param1,param2)
      {
         // super(param1,param2);
      }
      
      public static LongC fromNumber(float param1)
      {
         return new LongC((uint)param1, (uint)Math.Floor(param1 / 4294967296));
      }
      
      public static Boolean isZero(LongC param1) 
      {
         if(param1 == null)
         {
            return true;
         }
         if (param1.equal(LongC.fromNumber(0)))
         {
            return true;
         }
         return false;
      }
      
      public static int compare(LongC param1, LongC param2)// : int
      {
         if(param1.high > param2.high)
         {
            return 1;
         }
         if(param1.high < param2.high)
         {
            return -1;
         }
         if(param1.low > param2.low)
         {
            return 1;
         }
         if(param1.low < param2.low)
         {
            return -1;
         }
         return 0;
      }
      
      public static LongC parselong(String param1,uint param2 = 0)
      {
         uint _loc5_ = 0;
         if(param1.Substring(0,1) == "-")
         {
            return fromNumber(float.Parse(param1));
         }
         uint _loc3_ = 0;
         if(param2 == 0)
         {
            //这里是正则 if(param1.search(/^0x/) == 0)
             if(true)
            {
               param2 = 16;
               _loc3_ = 2;
            }
            else
            {
               param2 = 10;
            }
         }
         if(param2 < 2 || param2 > 36)
         {
            throw new ArgumentException();
         }
         param1 = param1.ToLower();
         LongC _loc4_ = new LongC();
         while(_loc3_ < param1.Length)
         {
             string str =param1.Substring((int)_loc3_, 1);
             _loc5_ = uint.Parse(str);
            if(_loc5_ >= CHAR_CODE_0 && _loc5_ <= CHAR_CODE_9)
            {
               _loc5_ = _loc5_ - CHAR_CODE_0;
            }
            else if(_loc5_ >= CHAR_CODE_A && _loc5_ <= CHAR_CODE_Z)
            {
               _loc5_ = _loc5_ - CHAR_CODE_A;
               _loc5_ = _loc5_ + 10;
            }
            else
            {
               throw new ArgumentException();
            }
            if(_loc5_ >= param2)
            {
               throw new ArgumentException();
            }
            _loc4_.mul(param2);
            _loc4_.add( _loc5_);
            _loc3_++;
         }
         return _loc4_;
      }

      public void add(uint param1)
      {
          low += param1;
      }
      
      public static LongC add(LongC param1, LongC param2)
      {
         uint _loc3_ = 0;
         uint _loc4_ = uint.MaxValue - param1.low + 1;
         int _loc5_ = 0;
         if(param1.low == 0 || param2.low == 0 || _loc4_ > param2.low)
         {
            _loc3_ = param1.low + param2.low;
         }
         else
         {
            _loc3_ = param2.low - _loc4_;
            _loc5_ = 1;
         }
         uint _loc6_ = param1.high + param2.high +(uint) _loc5_;
         return new LongC(_loc3_,_loc6_);
      }
      
      public static LongC sub(LongC param1,LongC param2)
      {
         uint _loc3_ = 0;
         uint  _loc4_= 0;
         if(compare(param1,param2) == -1)
         {
            return new LongC(0,0);
         }
         if(param1.low < param2.low)
         {
            if(param1.high > 0)
            {
                _loc3_ = uint.MaxValue - param2.low + 1 + param1.low;
               _loc4_ = 1;
            }
            else
            {
               _loc3_ = param1.low - param2.low;
            }
         }
         else
         {
            _loc3_ = param1.low - param2.low;
         }
         uint _loc5_ = param1.high - param2.high - _loc4_;
         return new LongC(_loc3_,_loc5_);
      }
      
      //public final function set high(param1:uint) : void
      //{
      //   internalHigh = param1;
      //}
      
      //public final function get high() : uint
      //{
      //   return internalHigh;
      //}
      
      public Boolean equal(LongC param1)      {
         if(param1 != null)
         {
            return param1.high == this.high && param1.low == low;
         }
         return false;
      }
      
      public float toNumber()
      {
         return (float)(this.high * 4294967296) + low;
      }
      /*
      public String toString(uint param1= 10)
      {
         uint _loc4_ = 0;
         if(param1 < 2 || param1 > 36)
         {
            throw new ArgumentException();
         }
         if(this.high == 0)
         {
             return Convert.ToString(low, (int)param1);// low.ToString(param1);
         }
         List<uint> _loc2_ = new List<uint>();
         LongC _loc3_ = new LongC(low,this.high);
         do
         {
            _loc4_ = _loc3_.div(param1);
            if(_loc4_ < 10)
            {
               _loc2_.Add(_loc4_ + CHAR_CODE_0);
            }
            else
            {
               _loc2_.Add(_loc4_ - 10 + CHAR_CODE_A);
            }
         }
         while(_loc3_.high != 0);
         
         return Convert.ToString(_loc3_.low, (int)param1) + String.fromCharCode.apply(String,_loc2_.Reverse());
      }
      */
      
      public LongC and(LongC param1)
      {
         uint _loc2_ = internalHigh & param1.internalHigh;
         uint  _loc3_= low & param1.low;
         return new LongC(_loc3_,_loc2_);
      }
      
      public LongC or(LongC param1) 
      {
         uint _loc2_ = internalHigh | param1.internalHigh;
         uint  _loc3_= low | param1.low;
         return new LongC(_loc3_,_loc2_);
      }
      
      public LongC xor(LongC param1 ) 
      {
         uint _loc2_ = internalHigh ^ param1.internalHigh;
         uint _loc3_= low ^ param1.low;
         return new LongC(_loc3_,_loc2_);
      }
      
      public uint byteValue() 
      {
         return low & 255;
      }
      
      public LongC shiftRight(uint param1) 
      {
         uint _loc5_ = 0;
         int _loc6_= 0;
         if(param1 == 0)
         {
            return this;
         }
         if(param1 > 63)
         {
            return this;
         }
         uint _loc2_ = internalHigh;
         uint _loc3_ = low;
         int _loc4_ = (int)(param1 / 32);
         if(_loc4_ > 0)
         {
            _loc3_ = _loc2_;
            _loc2_ = _loc2_ >= 0?(uint)0:(uint)0xffffffff;
         }
         param1 = param1 % 32;
         uint _loc7_ = 0;
         _loc6_ = 0;
         while(_loc6_ < param1)
         {
            _loc7_ = (uint)(_loc7_ | 1 << _loc6_);
            _loc6_++;
         }
         _loc5_ = _loc3_ & _loc7_;
         _loc3_ = _loc3_ >> (int)param1;// >>>
         _loc5_ = _loc2_ & _loc7_;
         _loc3_ = _loc3_ | _loc5_ << (int)(32 - param1);
         _loc2_ = _loc2_ >> (int)param1;
         return new LongC(_loc3_,_loc2_);
      }
      
      public LongC shiftRightNo(uint param1)
      {
         uint _loc5_ = 0;
         int _loc6_= 0;
         if(param1 == 0)
         {
            return this;
         }
         if(param1 > 63)
         {
            return this;
         }
         uint _loc2_ = internalHigh;
         uint _loc3_ = low;
         int  _loc4_= (int)(param1 / 32);
         if(_loc4_ > 0)
         {
            _loc3_ = _loc2_;
            _loc2_ = 0;
         }
         param1 = param1 % 32;
         uint _loc7_ = 0;
         _loc6_ = 0;
         while(_loc6_ < param1)
         {
            _loc7_ = _loc7_ | (uint)(1 << _loc6_);
            _loc6_++;
         }
         _loc5_ = _loc3_ & _loc7_;
         _loc3_ = _loc3_ >> (int)param1;///>>>
         _loc5_ = _loc2_ & _loc7_;
         _loc3_ = _loc3_ | _loc5_ <<(int)( 32 - param1);
         _loc2_ = _loc2_ >> (int)param1;//>>>
         return new LongC(_loc3_,_loc2_);
      }
      
      public LongC shiftLeft(uint param1) 
      {
         uint _loc5_ = 0;
         int  _loc6_= 0;
         if(param1 == 0)
         {
            return this;
         }
         if(param1 > 63)
         {
            return new LongC(0,0);
         }
         if(param1 == 32)
         {
            return new LongC(0,low);
         }
         uint _loc2_ = internalHigh;
         uint _loc3_ = low;
         int _loc4_ = (int)(param1 / 32);
         if(_loc4_ > 0)
         {
            _loc2_ = _loc3_;
            _loc3_ = 0;
         }
         param1 = param1 % 32;
         uint _loc7_ = 0;
         _loc6_ = 1;
         while(_loc6_ <= param1)
         {
            _loc7_ = _loc7_ | (uint)(1 << (int)(32 - _loc6_));
            _loc6_++;
         }
         _loc5_ = _loc2_ & _loc7_;
         _loc2_ = _loc2_ << (int)param1;
         _loc5_ = _loc3_ & _loc7_;
         _loc2_ = _loc2_ | _loc5_ >> (int)(32 - param1);// >>>
         _loc3_ = _loc3_ << (int)param1;
         return new LongC(_loc3_,_loc2_);
      }

        public string toString()
      {
          return Convert.ToString(high, 16) + "." + Convert.ToString(low, 16);
      }
    }
}
