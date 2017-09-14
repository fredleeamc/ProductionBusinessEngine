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
    /// <seealso cref="ProductionSchedulerLibrary.SFC_BomComponent" />
    public class SFC_BomItem : SFC_BomComponent
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_BomItem"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <param name="quantity">The quantity.</param>
        public SFC_BomItem(long id, SFC_Item item, double quantity) : base(id, item, quantity)
        {
            this.isLeaf = true;
        }

        /// <summary>
        /// Adds the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        public override void Add(SFC_BomComponent component)
        {
            Console.WriteLine("Cannot Add");
        }

        /// <summary>
        /// Displays the specified depth.
        /// </summary>
        /// <param name="depth">The depth.</param>
        /// <returns></returns>
        public override string Display(int depth)
        {
            return new String('-', depth) + id + ":" + item + ":" + quantity + "\n";
        }

        /// <summary>
        /// Determines whether this instance is item.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is item; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsItem()
        {
            return isLeaf;
        }

        /// <summary>
        /// Removes the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        public override void Remove(SFC_BomComponent component)
        {
            Console.WriteLine("Cannot Remove");
        }

        /// <summary>
        /// Counts the items.
        /// </summary>
        /// <returns></returns>
        public override int CountItems()
        {
            return 1;
        }

        /// <summary>
        /// Estimateds the cost.
        /// </summary>
        /// <returns></returns>
        public override double EstimatedCost()
        {
            return this.UnitCost * this.Quantity;
        }

        /// <summary>
        /// Bills the of materials.
        /// </summary>
        /// <param name="materials">The materials.</param>
        public override void BillOfMaterials(ref Dictionary<SFC_Item, double> materials)
        {
            if (materials.ContainsKey(this.Item))
            {
                materials[this.Item] += this.Quantity;
            } else
            {
                materials.Add(this.Item, this.Quantity);
            }
        }
    }
}
