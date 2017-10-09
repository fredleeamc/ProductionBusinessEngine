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
        /// <summary>
        /// The identifier
        /// </summary>
        protected readonly long id;

        /// <summary>
        /// The item
        /// </summary>
        protected readonly SFC_Item item;

        /// <summary>
        /// The quantity
        /// </summary>
        protected decimal quantity;

        /// <summary>
        /// The unit cost
        /// </summary>
        private decimal unitCost;

        private decimal calculatedTotalComponentCost;

        private decimal calculatedTotalQuantityRequired;

        private decimal calculatedTotalBomTotalCost;


        /// <summary>
        /// The bom cost
        /// </summary>
        private decimal bomCost;

        /// <summary>
        /// The is leaf
        /// </summary>
        protected bool isLeaf;

        /// <summary>
        /// The unit
        /// </summary>
        private string unit;

        private int depth;

        private SFC_Currency currency;

        private SFC_CurrencyExchange currencyExchange;

        /// <summary>
        /// The parent
        /// </summary>
        protected SFC_BomComposite parent;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id { get => id; }
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public SFC_Item Item { get => item; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public decimal Quantity { get => quantity; set => quantity = value; }
        /// <summary>
        /// Gets or sets the unit cost.
        /// </summary>
        /// <value>
        /// The unit cost.
        /// </value>
        public decimal UnitCost { get => unitCost; set => unitCost = value; }
        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        public string Unit { get => unit; set => unit = value; }
        /// <summary>
        /// Gets or sets the bom cost.
        /// </summary>
        /// <value>
        /// The bom cost.
        /// </value>
        public decimal BomCost { get => bomCost; set => bomCost = value; }
        public int Depth { get => depth; set => depth = value; }
        public SFC_Currency Currency { get => currency; set => currency = value; }
        public SFC_CurrencyExchange CurrencyExchange { get => currencyExchange; set => currencyExchange = value; }
        public decimal CalculatedTotalComponentCost { get => calculatedTotalComponentCost; set => calculatedTotalComponentCost = value; }
        public decimal CalculatedTotalQuantityRequired { get => calculatedTotalQuantityRequired; set => calculatedTotalQuantityRequired = value; }
        public decimal CalculatedTotalBomTotalCost { get => calculatedTotalBomTotalCost; set => calculatedTotalBomTotalCost = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_BomComponent"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <param name="quantity">The quantity.</param>
        public SFC_BomComponent(long id, SFC_Item item, decimal quantity)
        {
            this.id = id;
            this.item = item;
            this.quantity = quantity;
            this.isLeaf = false;
            parent = null;
        }

        public abstract decimal Cost();

        public abstract void metrics(int depth, decimal qtyMultiplier);


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
        /// <summary>
        /// Counts the items.
        /// </summary>
        /// <returns></returns>
        public abstract int CountItems();
        /// <summary>
        /// Estimateds the cost.
        /// </summary>
        /// <returns></returns>
        //public abstract decimal EstimatedCost();
        /// <summary>
        /// Bills the of materials.
        /// </summary>
        /// <param name="materials">The materials.</param>
        public abstract void BillOfMaterials(ref Dictionary<SFC_Item, decimal> materials);

        /// <summary>
        /// Sets the parent.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void SetParent(SFC_BomComposite parent)
        {
            this.parent = parent;
        }

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
            if (!this.Equals(child) || this.item.Equals(child.Item))
            {
                SFC_BomComposite thisObj = this as SFC_BomComposite;
                if (thisObj != null)
                {
                    SFC_BomComposite parentHist = thisObj;
                    while (parentHist != null)
                    {
                        if (child.Equals(parentHist) || (child.Item.Equals(parentHist.Item)))
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
