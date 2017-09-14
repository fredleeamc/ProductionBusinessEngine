using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    abstract public class SFC_BomComponent
    {
        protected readonly long id;

        protected readonly SFC_Item item;

        protected double quantity;

        private double unitCost;

        private double bomCost;

        protected bool isLeaf;

        private string unit;

        protected SFC_BomComposite parent;

        public long Id { get => id; }
        public SFC_Item Item { get => item; }
        public double Quantity { get => quantity; set => quantity = value; }
        protected double UnitCost { get => unitCost; set => unitCost = value; }
        protected string Unit { get => unit; set => unit = value; }
        public double BomCost { get => bomCost; set => bomCost = value; }

        public SFC_BomComponent(long id, SFC_Item item, double quantity)
        {
            this.id = id;
            this.item = item;
            this.quantity = quantity;
            this.isLeaf = false;
            parent = null;
        }

        public abstract void Add(SFC_BomComponent component);
        public abstract void Remove(SFC_BomComponent component);
        public abstract string Display(int depth);
        public abstract bool IsItem();
        public abstract int CountItems();
        public abstract double EstimatedCost();
        public abstract void BillOfMaterials(ref Dictionary<SFC_Item, double> materials);

        public void SetParent(SFC_BomComposite parent)
        {
            this.parent = parent;
        }

        public bool IsCircular(SFC_BomComponent child)
        {
            bool result = false;
            if (!this.Equals(child))
            {
                SFC_BomComposite thisObj = this as SFC_BomComposite;
                if (thisObj != null)
                {
                    SFC_BomComposite parentHist = thisObj;
                    while (parentHist != null)
                    {
                        if (child.Equals(parentHist))
                        {
                            result = true;
                            break;
                        }
                        parentHist = parentHist.parent;
                    }
                }
            }
            else
            {
                result = true;
            }
            return result;
        }
    }
}
