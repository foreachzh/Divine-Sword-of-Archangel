using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt
{
    public class PoseInfo
    {
        public Array inters;

        public Array poses;

        public Array offsets;

        public String sound;

        public float delay;

        private float _effectTime;

        public float EffectTime
        {
            get { return _effectTime; }
            set { _effectTime = value; }
        }

        private float _lastTime;

        public float LastTime
        {
            get { return _lastTime; }
            set { _lastTime = value; }
        }

        public String blendMode;

        private float _scale;

        public float Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        public Boolean layout;

        public uint effectFrame;

        public float offsetY;

        public float offsetX;

        public Boolean rotate360;

        public Boolean repeat;

        public uint poseIndex;

        private float _releaseTime;

        public float ReleaseTime
        {
            get { return _releaseTime; }
            set { _releaseTime = value; }
        }

        private uint _releaseFrame;

        public uint ReleaseFrame
        {
            get { return _releaseFrame; }
            set { _releaseFrame = value; }
        }

        private float _horseY;

        public float HorseY
        {
            get { return _horseY; }
            set { _horseY = value; }
        }


    }
}

//package com.f1.vmc
//{
//   import com.f1.structs.BaseInfo;
   
//   public class PoseInfo extends BaseInfo
//   {
       
      
//      public var inters:Array;
      
//      public var poses:Array;
      
//      public var offsets:Array;
      
//      public var sound:String;
      
//      public var delay:Number = 0;
      
//      private var _effectTime:Number = 0;
      
//      private var _lastTime:Number = 0;
      
//      public var blendMode:String;
      
//      private var _scale:Number;
      
//      public var layout:Boolean;
      
//      public var effectFrame:uint;
      
//      public var offsetY:Number = 0;
      
//      public var offsetX:Number = 0;
      
//      public var rotate360:Boolean;
      
//      public var repeat:Boolean;
      
//      public var poseIndex:uint;
      
//      private var _releaseTime:Number = 0;
      
//      private var _releaseFrame:uint;
      
//      private var _horseY:Number = 0;
      
//      public function PoseInfo()
//      {
//         super();
//      }
      
//      public function get scale() : Number
//      {
//         return this._scale;
//      }
      
//      public function set scale(param1:Number) : void
//      {
//         this._scale = param1;
//      }
      
//      public function get releaseFrame() : uint
//      {
//         return this._releaseFrame;
//      }
      
//      public function set releaseFrame(param1:uint) : void
//      {
//         this._releaseFrame = param1;
//      }
      
//      public function get releaseTime() : Number
//      {
//         return this._releaseTime;
//      }
      
//      public function set releaseTime(param1:Number) : void
//      {
//         this._releaseTime = param1;
//      }
      
//      public function get lastTime() : Number
//      {
//         return this._lastTime;
//      }
      
//      public function set lastTime(param1:Number) : void
//      {
//         this._lastTime = param1;
//      }
      
//      public function get effectTime() : Number
//      {
//         return this._effectTime;
//      }
      
//      public function set effectTime(param1:Number) : void
//      {
//         this._effectTime = param1;
//      }
      
//      public function get horseY() : Number
//      {
//         return this._horseY;
//      }
      
//      public function set horseY(param1:Number) : void
//      {
//         this._horseY = param1;
//      }
//   }
//}
