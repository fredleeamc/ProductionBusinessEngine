using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class SFC_BomComponent
    {

        private readonly long id;
        private SFC_Item item;
        private String partName;
        private String partNo;

        private long itemCount;
        private decimal unitCost;            //Input by user
        private decimal calcSourceUnitCost;  //From child bom currency
        private decimal calcTargetUnitCost;  //From parent bom currency 

        private decimal quantity;                   //Qty of this component needed to make qty of parent bom: Input by user
        private decimal calcTotalQuantityRequired;  //From bom build requirements

        private decimal calcSourceBomCost;     //

        private decimal calcSourceBuildCost;  //calcTotalQuantityRequired * calcsourceUnitCost
        private decimal calcTargetBuildCost;  //calcTotalQuantityRequired * calcTargetUnitCost


        private bool isLeaf;
        private string unit;
        private int depth;
        private SFC_Currency currency;
        private SFC_Currency parentCurrency;
        private SFC_CurrencyExchange currencyExchange;
        private SFC_BomComposite parent;

        protected long Id => id;


        public string PartName { get => partName; set => partName = value; }
        public string PartNo { get => partNo; set => partNo = value; }
        public decimal Quantity { get => quantity; set => quantity = value; }
        public long ItemCount { get => itemCount; set => itemCount = value; }
        protected bool IsLeaf { get => isLeaf; set => isLeaf = value; }
        public string Unit { get => unit; set => unit = value; }
        public int Depth { get => depth; set => depth = value; }
        public SFC_Currency Currency { get => currency; set => currency = value; }
        public SFC_CurrencyExchange CurrencyExchange { get => currencyExchange; set => currencyExchange = value; }
        protected SFC_BomComposite Parent { get => parent; set => parent = value; }
        protected SFC_Item Item { get => item; set => item = value; }



        public decimal CalcSourceUnitCost { get => calcSourceUnitCost; set => calcSourceUnitCost = value; }

        public decimal CalcTargetUnitCost { get => calcTargetUnitCost; set => calcTargetUnitCost = value; }

        public decimal CalcSourceBomCost { get => calcSourceBomCost; set => calcSourceBomCost = value; }


        public decimal CalcTotalQuantityRequired { get => calcTotalQuantityRequired; set => calcTotalQuantityRequired = value; }


        public decimal CalcSourceBuildCost { get => calcSourceBuildCost; set => calcSourceBuildCost = value; }


        public decimal CalcTargetBuildCost { get => calcTargetBuildCost; set => calcTargetBuildCost = value; }




        public decimal UnitCost { get => unitCost; set => unitCost = value; }
        public SFC_Currency ParentCurrency { get => parentCurrency; set => parentCurrency = value; }



        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_BomComponent"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <param name="quantity">The quantity.</param>
        //public SFC_BomComponent(long id, SFC_Item item, decimal quantity)
        public SFC_BomComponent(long id, String partNo)
        {
            this.id = id;
            //this.item = item;
            this.quantity = 0M;
            this.partNo = partNo;
            this.isLeaf = false;
            parent = null;
        }

        //public abstract decimal Cost();

        public abstract void metrics(int depth, decimal qtyMultiplier, SFC_Currency baseCurrency);


        /// <summary>
        /// Adds the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        public abstract bool Add(SFC_BomComponent component);
        /// <summary>
        /// Removes the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        public abstract void Remove(SFC_BomComponent component);
        /// <summary>
        /// Displays the specified depth.
        /// </summary>
        /// <param name="depth">The depth.</param>
        /// <returns></returns>
        public abstract string Display(int depth);
        /// <summary>
        /// Determines whether this instance is item.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is item; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsItem();
        ///// <summary>
        ///// Counts the items.
        ///// </summary>
        ///// <returns></returns>
        //public abstract int CountItems();
        /// <summary>
        /// Estimateds the cost.
        /// </summary>
        /// <returns></returns>
        //public abstract decimal EstimatedCost();
        /// <summary>
        /// Bills the of materials.
        /// </summary>
        /// <param name="materials">The materials.</param>
        public abstract void BillOfMaterials(ref Dictionary<String, decimal> materials, decimal multiplier);

        /// <summary>
        /// Sets the parent.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void SetParent(SFC_BomComposite parent)
        {
            this.parent = parent;
        }


        public abstract void SetItem(SFC_Item thisItem);

        /// <summary>
        /// Determines whether the specified child is circular.
        /// </summary>
        /// <param name="child">The child.</param>
        /// <returns>
        ///   <c>true</c> if the specified child is circular; otherwise, <c>false</c>.
        /// </returns>
        public bool IsCircular(SFC_BomComponent child)
        {
            bool result = false;
            if (!this.Equals(child) || this.PartNo.Equals(child.PartNo))
            {
                SFC_BomComposite thisObj = this as SFC_BomComposite;
                if (thisObj != null)
                {
                    SFC_BomComposite parentHist = thisObj;
                    while (parentHist != null)
                    {
                        if (child.Equals(parentHist) || child.PartNo.Equals(parentHist.PartNo))
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
