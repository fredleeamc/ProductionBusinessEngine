using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    abstract public class SFC_BomComponent
    {
        protected long id;

        protected SFC_Item item;

        protected long quantity;

        protected bool isLeaf;

        public SFC_BomComponent(long id, SFC_Item item, long quantity)
        {
            this.id = id;
            this.item = item;
            this.quantity = quantity;
            this.isLeaf = false;
        }

        public abstract void Add(SFC_BomComponent component);
        public abstract void Remove(SFC_BomComponent component);
        public abstract string Display(int depth);
    }
}
