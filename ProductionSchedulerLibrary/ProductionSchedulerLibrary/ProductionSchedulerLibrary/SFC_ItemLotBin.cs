using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_ItemLotBin
    {
        private long id;
        private long itemId;
        private String lotNo;
        private String binNo;
        private String batchNo;
        private String heatNo;
        private SFC_ItemStatus itemStatus;

        public long Id
        {
            get
            {
                return id;
            }

            protected set
            {
                id = value;
            }
        }

        public long ItemId
        {
            get
            {
                return itemId;
            }

            protected set
            {
                itemId = value;
            }
        }

        private SFC_Item item;

        public SFC_Item Item
        {
            get
            {
                return item;
            }

            protected set
            {
                item = value;
            }
        }



        public string LotNo
        {
            get
            {
                return lotNo;
            }

            set
            {
                lotNo = value;
            }
        }

        public string BinNo
        {
            get
            {
                return binNo;
            }

            set
            {
                binNo = value;
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

        public string BatchNo
        {
            get
            {
                return batchNo;
            }

            set
            {
                batchNo = value;
            }
        }

        public string HeatNo
        {
            get
            {
                return heatNo;
            }

            set
            {
                heatNo = value;
            }
        }

        public SFC_ItemLotBin(long id, SFC_Item item, string lotNo, string binNo)
        {
            this.id = id;
            this.item = item;
            this.item.addLotBin(this);
            this.ItemId = item.Id;
            this.itemStatus = new SFC_ItemStatus(this);
            this.lotNo = lotNo;
            this.binNo = binNo;
        }



        public override string ToString()
        {
            return "Lotbin:" + id + "," + itemId + "," + lotNo + "," + binNo;
        }
    }
}
