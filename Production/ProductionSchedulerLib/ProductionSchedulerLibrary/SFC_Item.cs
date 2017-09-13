using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_Item
    {
        private readonly long id;

        private String itemCode;

        private SFC_ItemStatus itemStatus;

        private List<SFC_ItemLotBin> bins;

        public SFC_Item(long id, string itemCode)
        {
            //this.id = id;
            //this.itemCode = itemCode;
            this.itemStatus = new SFC_ItemStatus(this);
            this.bins = new List<SFC_ItemLotBin>();
        }

        public bool addLotBin(SFC_ItemLotBin bin)
        {
            if (!bins.Contains(bin))
            {
                bins.Add(bin);
                return true;
            }
            else
                return false;
        }

        public long Id
        {
            get
            {
                return id;
            }
        }

        public string ItemCode
        {
            get
            {
                return itemCode;
            }

            protected set
            {
                itemCode = value;
            }
        }

        public SFC_ItemStatus ItemStatus
        {
            get
            {
                return itemStatus;
            }

            protected set
            {
                itemStatus = value;
            }
        }

        public List<SFC_ItemLotBin> Bins
        {
            get
            {
                return bins;
            }

            protected set
            {
                bins = value;
            }
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id + "," + itemCode + ":\n");
            sb.Append(String.Format("{0, 40}|{1,10}|<{2,10}|{3,10}|{4,10}>|<{5,10}|{6,10}|{7, 10}|{8,10}>|{9,10}|{10,10}|{11,10}|{12,10}|{13,10}\n",
                "Begin","Receive", "On Hand", "PO", "Used", "Production", "Allocated", "Reserved", "Available", "Required", "Scrap", "Returns", "Adjust In", "Adjust Out"));
            sb.Append(String.Format("{0,29}:", "Total") + itemStatus +"\n");
            foreach (SFC_ItemLotBin bin in this.bins)
            {
                sb.Append(String.Format("{0,29}:",bin) + bin.ItemStatus+"\n");
            }
            return sb.ToString();
        }
    }
}
