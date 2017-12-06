using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDescrypt.Entity
{
    public class MailSummaryInfo:Bean
    {
      private LongC _mailid;
      private String _szSenderName;
      private String _szTitle;
      private int _btRead;
      private int _btAccessory;
      private int _nSendTime;
      private int _btSystem;      
        private List<MailSummaryItem> _summaryitemlist=new List<MailSummaryItem>();

    override public void reading()
        {
                     this._mailid = readLong();
         this._szSenderName = readString();
         this._szTitle = readString();
         this._btRead = readByte();
         this._btAccessory = readByte();
         this._nSendTime = readInt();
         this._btSystem = readByte();
         _summaryitemlist = readObjList<MailSummaryItem, MailSummaryItem>();
         /*
          * var _loc1_:int = readShort();
         var _loc2_:int = 0;
         while(_loc2_ < _loc1_)
         {
            this._summaryitemlist[_loc2_] = readBean(com.game.mail.bean.MailSummaryItem) as com.game.mail.bean.MailSummaryItem;
            _loc2_++;
         }*/
        }

        public string getShowInfo()
    {
        string PrintInfo = string.Format("_mailid={0}{7};_szSenderName={1};_szTitle={2};_btRead={3};_btAccessory={4};_nSendTime={5};_btSystem={6}",
            Convert.ToString(_mailid.high, 16), _szSenderName, _szTitle, _btRead, _btAccessory, _nSendTime, _btSystem,Convert.ToString(_mailid.low, 16));
        return PrintInfo;
    }
    }

    public class MailSummaryItem:Bean
    {
      private int _itemid;
      private int _itemnum;
      override public void reading()
      {
         this._itemid = readInt();
         this._itemnum = readInt();
      }
    }
}
