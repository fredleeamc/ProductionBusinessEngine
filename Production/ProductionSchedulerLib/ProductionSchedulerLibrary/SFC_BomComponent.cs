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
        protected double quantity;

        /// <summary>
        /// The unit cost
        /// </summary>
        private double unitCost;

        /// <summary>
        /// The bom cost
        /// </summary>
        private double bomCost;

        /// <summary>
        /// The is leaf
        /// </summary>
        protected bool isLeaf;

        /// <summary>
        /// The unit
        /// </summary>
        private string unit;

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
        public double Quantity { get => quantity; set => quantity = value; }
        /// <summary>
        /// Gets or sets the unit cost.
        /// </summary>
        /// <value>
        /// The unit cost.
        /// </value>
        protected double UnitCost { get => unitCost; set => unitCost = value; }
        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        protected string Unit { get => unit; set => unit = value; }
        /// <summary>
        /// Gets or sets the bom cost.
        /// </summary>
        /// <value>
        /// The bom cost.
        /// </value>
        public double BomCost { get => bomCost; set => bomCost = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_BomComponent"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <param name="quantity">The quantity.</param>
        public SFC_BomComponent(long id, SFC_Item item, double quantity)
        {
            this.id = id;
            this.item = item;
            this.quantity = quantity;
            this.isLeaf = false;
            parent = null;
        }

        /// <summary>
        /// Adds the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        public abstract void Add(SFC_BomComponent component);
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
        public abstract double EstimatedCost();
        /// <summary>
        /// Bills the of materials.
        /// </summary>
        /// <param name="materials">The materials.</param>
        public abstract void BillOfMaterials(ref Dictionary<SFC_Item, double> materials);

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
