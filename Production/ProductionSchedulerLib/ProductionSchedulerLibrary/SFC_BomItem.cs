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
        public SFC_BomItem(long id, SFC_Item item, decimal quantity) : base(id, item, quantity)
        {
            this.isLeaf = true;
            this.ItemCount = 1;
        }

        /// <summary>
        /// Adds the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        public override bool Add(SFC_BomComponent component)
        {
            Console.WriteLine("Cannot Add");
            return false;
        }

        /// <summary>
        /// Displays the specified depth.
        /// </summary>
        /// <param name="depth">The depth.</param>
        /// <returns></returns>
        public override string Display(int depth)
        {
            String desc = id + ":" + item;
            String num1 = String.Format("{0:N}", Quantity);
            String num2 = String.Format("{0:N}", BomCost);
            String num3 = String.Format("{0:N}", UnitCost);
            String num4 = String.Format("{0:N}", CalculatedTotalQuantityRequired);
            String num5 = String.Format("{0:N}", CalculatedTotalBomTotalCost);
            //StringBuilder sb = new StringBuilder();
            //sb.Append(String.Format("{0:-20}{1,-40}{2,-40}", new String('-', depth) + "I", desc, num));
            String dash = new String('*', depth) + "I";
            Console.WriteLine(String.Format("{0}|{1}|Qty{2}|U${3}|S${4}|TQty${5}|TT${6}", dash.PadRight(20), desc.PadRight(30), num1.PadLeft(12), num3.PadLeft(12), num2.PadLeft(12), num4.PadLeft(12), num5.PadLeft(12)));

            //String desc = id + ":" + item;
            //String num1 = String.Format("{0:F2}", Quantity);
            //String num2 = String.Format("{0:F2}", BomCost);
            //String num3 = String.Format("{0:F2}", UnitCost);
            ////StringBuilder sb = new StringBuilder();
            ////sb.Append(String.Format("{0:-20}{1,-40}{2,-40}", new String('-', depth) + "I", desc, num));
            //String dash = new String('-', depth) + "I";
            //Console.WriteLine(String.Format("{0}|{1}|Qty{2}|${3}|${4}", dash.PadRight(20), desc.PadRight(30), num1.PadLeft(12), num3.PadLeft(12), num2.PadLeft(12)));
            return ""; // sb.ToString();
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

        ///// <summary>
        ///// Counts the items.
        ///// </summary>
        ///// <returns></returns>
        //public override int CountItems()
        //{
        //    return 1;
        //}

        //public override decimal Cost()
        //{
        //    return this.UnitCost * this.Quantity;
        //}

        /// <summary>
        /// Estimateds the cost.
        /// </summary>
        /// <returns></returns>
        //public override decimal EstimatedCost()
        //{
        //    return this.UnitCost * this.Quantity;
        //}

        /// <summary>
        /// Bills the of materials.
        /// </summary>
        /// <param name="materials">The materials.</param>
        public override void BillOfMaterials(ref Dictionary<SFC_Item, decimal> materials)
        {
            if (materials.ContainsKey(this.Item))
            {
                materials[this.Item] += this.Quantity;
            }
            else
            {
                materials.Add(this.Item, this.Quantity);
            }
        }

        public override void metrics(int idepth, decimal multiplier)
        {
            this.Depth = idepth++;
            this.CalculatedTotalComponentCost = this.UnitCost * this.Quantity;
            this.CalculatedTotalQuantityRequired = this.Quantity * multiplier;
            this.CalculatedTotalBomTotalCost = this.CalculatedTotalQuantityRequired * this.UnitCost;
            this.BomCost = this.UnitCost * this.Quantity;
        }

    }
}

