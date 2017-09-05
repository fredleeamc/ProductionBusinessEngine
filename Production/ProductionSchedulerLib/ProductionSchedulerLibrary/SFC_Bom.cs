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

        private long itemId;

        private SortedList<long, SFC_Item> bomList;

        private SortedList<long, long> bomQty;

        public long Id
        {
            get
            {
                return id;
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

        public SFC_Bom(long id, long itemId, SortedList<long, SFC_Item> bomList)
        {
            this.id = id;
            this.itemId = itemId;
            this.bomList = bomList;
        }

        public void addBom(SFC_Item item)
        {
            bomList.Add(item.Id, item);
        }

        public void removeBom(SFC_Item item)
        {

        }

    }
}
