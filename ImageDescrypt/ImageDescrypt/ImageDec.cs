using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// using XRFAppPlat.Logger;
//using FluorineFx;
//using FluorineFx.AMF3;
using System.Net.Http;

namespace ImageDescrypt
{
    /*
    public class ImageDec
    {
        // 图片保存 字节流保存为图片
        /// <summary>
        /// 字节数组生成图片
        /// </summary>
        /// <param name="Bytes">字节数组</param>
        /// <returns>图片</returns>
        private void byteArrayToImage(byte[] Bytes, string strName)
        {
            MemoryStream ms = new MemoryStream(Bytes);
            Image image = Bitmap.FromStream(ms, true);
            if (image != null)
            {
                string name = DateTime.Now.ToString("yyyyMMddhhmmssff") + ".jpg";
                image.Save(curPath + name);
                image.Dispose();
            }
        }

        private string curPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private List<string> decodeNameList = new List<string>();
        private List<ByteArray> decodeList = new List<ByteArray>();

        private void Load(byte[] arr, string strName, bool bl)
        {
            byteArrayToImage(arr, strName);
        }

        /// <summary>
        /// 图片拆解为小的字节数组
        /// </summary>
        /// <param name="param1"></param>
        public void writeBinRes(byte[] param1)
      {
         String _loc4_ = null;
         PoseInfo _loc11_ = new PoseInfo();
         //:* = null;
         // var _loc13_:* = null;
         uint _loc14_ = 0;
         uint _loc15_ = 0;
         // this.resetByteLoader();
         // param1.position = 0;
         // ConsoleLog.Instance.writeInformationLog("VMC解析");
         if(param1 ==null)
         {
            // ConsoleLog.Instance.writeInformationLog("二进制资源为空");
            // this.reset();
            return;
         }

        MemoryStream ms = new MemoryStream(param1);
        FluorineFx.AMF3.ByteArray arr = new ByteArray(ms);
            
        // 从字节数组中读取一个以 AMF 序列化格式进行编码的对象。
        ASObject asObj = (ASObject)arr.ReadObject();
        List<KeyValuePair<string, object> > _loc2_ = asObj.ToList();
         // (List<ByteArray>)asObj;
         //PoseInfo cfgs =(PoseInfo)arr.ReadObject();
         //Array imgCfgs = arr.ReadObject() as Array;
         //if(cfgs == null)
         //{
         //   // ConsoleLog.Instance.writeInformationLog("VMC文件格式有问题");
         //   //this._loading = false;
         //   //this._loaded = true;
         //   //this.doCallBack(this._completeFuns);
         //   //this.removeFuns();
         //   return;
         //}
        // this._poseInfos = new Dictionary();
         //float _loc3_ = (uint)(cfgs.LastTime) / 1000;
         //if(string.IsNullOrEmpty( cfgs.blendMode))
         //{
         //   _loc4_ = cfgs.blendMode;
         //}
         //float _loc5_ = cfgs.Scale;
         //Boolean _loc6_ = cfgs.repeat;
         //float _loc7_ = 0;
         //int _loc8_ = 0;
         //if(!_loc6_)
         //{
         //   if(cfgs.EffectTime > 0)
         //   {
         //      _loc7_ = (uint)cfgs.EffectTime / 1000;
         //   }
         //   else
         //   {
         //      _loc7_ = _loc3_ / 2;
         //   }
         //   if(cfgs.effectFrame > 0)
         //   {
         //      _loc8_ = (int)cfgs.effectFrame;
         //   }
         //   else if(cfgs.inters.Length >0)
         //   {
         //      _loc8_ = cfgs.inters.Length / 2;
         //   }
         //}
         //float _loc9_= (cfgs.ReleaseTime) / 1000;
         //uint _loc10_ = cfgs.ReleaseFrame;
         //foreach(var _loc12_ in cfgs.offsets)
         //{
         //   _loc11_ = new PoseInfo();
         //   _loc11_.inters = cfgs.inters;
         //   _loc11_.offsets = _loc12_;
         //   if(cfgs.offsetY != float.Epsilon )
         //   {
         //      _loc11_.offsetY = (float)(cfgs.offsetY);
         //   }
         //   if(cfgs.offsetX != float.Epsilon)
         //   {
         //      _loc11_.offsetX = (float)(cfgs.offsetX);
         //   }
         //   _loc11_.rotate360 = cfgs.rotate360;
         //   _loc11_.LastTime = _loc3_;
         //   _loc11_.EffectTime = _loc7_;
         //   _loc11_.effectFrame = (uint)_loc8_;
         //   _loc11_.ReleaseTime = _loc9_;
         //   _loc11_.ReleaseFrame = _loc10_;
         //   _loc14_ = (uint)_loc11_.offsets.Length;
         //   // _loc11_.poses=[];
         //   _loc15_ = 0;
         //   while(_loc15_ < _loc14_)
         //   {
         //      // _loc11_.poses.(_loc12_ + "_" + _loc15_);
         //      _loc15_++;
         //   }
         //   _loc11_.blendMode = _loc4_;
         //   _loc11_.Scale = _loc5_;
         //   _loc11_.HorseY = cfgs.HorseY;
         //   // _poseInfos[_loc12_] = _loc11_;
         //}
         this.decodeNameList.Clear();// = 0;
         this.decodeList.Clear();// = 0;
         foreach(KeyValuePair<string,object> _loc13_ in _loc2_)
         {
            // if(_loc13_ != null)
            {
               this.decodeNameList.Add(_loc13_.Key);
               this.decodeList.Add((ByteArray)_loc13_.Value);
            }
         }

         foreach (ByteArray barr in decodeList)
         {
             byte[] b=new byte[barr.Length];
             barr.ReadBytes(b, 0, barr.Length);
             byteArrayToImage(b, "12345");
         }
         // VMCManager.decodeBuffer.addItem(this.decodeBinPic);
      }

        public void DownloadImage()
        {
            string ImageURL = "http://res1.dts.37wan.com/res_cndts/art/res/skill/jn04204_000100.jpg";
            HttpClient client = new HttpClient();
            byte[] body =  client.GetByteArrayAsync(ImageURL).Result;
            writeBinRes(body);
        }
    }*/
}
