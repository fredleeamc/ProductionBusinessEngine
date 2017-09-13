using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductionSchedulerLibrary
{

    public class SFC_Bom
    {
        private readonly long id;

        private SFC_Item itemId;

        private SortedList<long, SFC_BomDetails> bomList;

        private SortedList<long, SFC_BomDetails> BomList { get => bomList; set => bomList = value; }



        public long Id => id;

        public SFC_Item ItemId { get => itemId; protected set => itemId = value; }

        private long index;

        //public SortedList<long, SFC_Item> BomList
        //{
        //    get
        //    {
        //        return bomList;
        //    }

        //    protected set
        //    {
        //        bomList = value;
        //    }
        //}

        public SFC_Bom(long id, SFC_Item itemId)
        {
            this.id = id;
            this.itemId = itemId;
            this.bomList = new SortedList<long, SFC_BomDetails>();
            this.index = 1;
        }

        public void addBomItem(SFC_Item item, long quantity)
        {
            long i = index++;
            SFC_BomDetails details = new SFC_BomDetails(i, quantity, item);
            lock (bomList)
            {
                bomList.Add(i, details);
            }

        }

        public void addBomChild(SFC_Bom bom, long quantity)
        {
            long i = index++;
            SFC_BomDetails details = new SFC_BomDetails(i, quantity, bom);
            lock (bomList)
            {
                bomList.Add(i, details);
            }
        }

        public void removeBom(long index)
        {
            if (bomList.ContainsKey(index))
            {
                lock (bomList)
                {
                    bomList.Remove(index);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("BOM:" + this.itemId);
            foreach (long seq in bomList.Keys)
            {
                SFC_BomDetails detail = bomList[seq];
                sb.Append("\t[" + seq + "]" + detail);
            }
            return sb.ToString();
        }

        private class SFC_BomDetails
        {
            private readonly long id;

            private long quantity;

            private SFC_Item item;

            private SFC_Bom bom;

            private readonly bool isBom;

            public SFC_BomDetails(long id, long quantity, SFC_Item item)
            {
                this.id = id;
                this.quantity = quantity;
                this.item = item;
                this.isBom = false;
            }

            public SFC_BomDetails(long id, long quantity, SFC_Bom bom)
            {
                this.id = id;
                this.quantity = quantity;
                this.bom = bom;
                this.isBom = true;
            }

            public long Id { get => id; }
            public long Quantitiy { get => quantity; set => quantity = value; }
            public SFC_Item Item { get => item; set => item = value; }
            public bool IsBom { get => isBom; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                if (!isBom)
                    sb.Append("->" + id + ":" + quantity + ":" + item);
                else
                    sb.Append("#>" + id + ":" + quantity + ":\nChild" + bom);
                return sb.ToString();
            }
        }

    }






}
