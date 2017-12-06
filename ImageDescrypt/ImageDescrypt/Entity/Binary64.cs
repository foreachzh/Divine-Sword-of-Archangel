using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt
{
   public class Binary64
   {
      
      public static uint CHAR_CODE_0 = 48;//'0'.;//= "0"();

      public static  uint CHAR_CODE_9 = 57;// = "9".charCodeAt();
      
      public static uint CHAR_CODE_A= 97;// "a".charCodeAt();

      public static uint CHAR_CODE_Z = 122;// "z".charCodeAt();
      
       
      public uint low;
      public uint high { get { return internalHigh; } set { internalHigh = value; } }
      protected uint internalHigh;
      
      public Binary64(uint param1 = 0,uint  param2= 0)
      {
         this.low = param1;
         this.internalHigh = param2;
      }
      
      public uint div(uint param1)
      {
         uint _loc2_ = 0;
         _loc2_ = this.internalHigh % param1;
         uint  _loc3_= (this.low % param1 + _loc2_ * 6) % param1;
         this.internalHigh = this.internalHigh / param1;
         float _loc4_= (_loc2_ * 4294967296 + this.low) / param1;
         this.internalHigh = this.internalHigh + (uint)(_loc4_ / 4294967296);
         this.low = (uint)_loc4_;
         return _loc3_;
      }
      
      public  void mul(uint param1) 
      {
         float _loc2_ = (float)(this.low) * param1;
         this.internalHigh = this.internalHigh * param1;
         this.internalHigh = this.internalHigh + (uint)(_loc2_ / 4294967296);
         this.low = this.low * param1;
      }
      
      private void add(uint param1)
      {
         float _loc2_= (float)(this.low) + param1;
         this.internalHigh = this.internalHigh + (uint)(_loc2_ / 4294967296);
         this.low = (uint)_loc2_;
      }
      
      private void bitwiseNot()
      {
         this.low = ~this.low;
         this.internalHigh = ~this.internalHigh;
      }
   }
}
