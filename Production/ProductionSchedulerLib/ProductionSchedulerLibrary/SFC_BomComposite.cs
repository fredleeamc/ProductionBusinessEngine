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
    public class SFC_BomComposite : SFC_BomComponent
    {
        /// <summary>
        /// The children
        /// </summary>
        private List<SFC_BomComponent> children;

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_BomComposite"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <param name="qty">The qty.</param>
        public SFC_BomComposite(long id, SFC_Item item, double qty) : base(id, item, qty)
        {
            children = new List<SFC_BomComponent>();
            this.isLeaf = false;
            item.SetBom(this);
        }

        /// <summary>
        /// Adds the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        public override bool Add(SFC_BomComponent component)
        {
            if (!this.IsCircular(component))
            {
                component.SetParent(this);
                children.Add(component);
                //this.BomCost = this.Cost();
                return true;
            }
            else
            {
                //Console.WriteLine(this.Item.ItemCode + "<-" + component.Item.ItemCode + " is circular.");
                return false;
            }
        }

        public override double Cost()
        {
            double nCost = 0;
            foreach (SFC_BomComponent component in children)
            {
                nCost += component.Cost();
            }
            this.BomCost = nCost;
            return nCost;
        }



        /// <summary>
        /// Displays the specified depth.
        /// </summary>
        /// <param name="depth">The depth.</param>
        /// <returns></returns>
        public override string Display(int depth)
        {
            String desc = id + ":" + item;
            String num1 = String.Format("{0:F2}", Quantity);
            String num2 = String.Format("{0:F2}", BomCost);
            String num3 = String.Format("{0:F2}", UnitCost);
            //StringBuilder sb = new StringBuilder();
            //sb.Append(String.Format("{0:-20}{1,-40}{2,-40}", new String('-', depth) + "I", desc, num));
            String dash = new String('*', this.Depth * 2) + "C";
            Console.WriteLine(String.Format("{0}|{1}|Qty{2}|${3}|${4}", dash.PadRight(20), desc.PadRight(30), num1.PadLeft(12), num3.PadLeft(12), num2.PadLeft(12)));
            
            foreach (SFC_BomComponent component in children)
            {
                //sb.Append(component.Display(depth + 2));
                component.Display(depth + 2);
            }
            return ""; //sb.ToString();
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
            children.Remove(component);
        }

        /// <summary>
        /// Counts the items.
        /// </summary>
        /// <returns></returns>
        public override int CountItems()
        {
            int count = 1;
            foreach (SFC_BomComponent component in children)
            {
                count += component.CountItems();
            }
            return count;
        }


        /// <summary>
        /// Estimateds the cost.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override double EstimatedCost()
        {
            double thisCost = 0;
            if (children.Count > 0)
            {
                foreach (SFC_BomComponent component in children)
                {
                    double t = component.EstimatedCost();
                    thisCost += t;
                    Console.WriteLine(component.Item + "=" + t + " Total:" + thisCost);
                }
                this.BomCost = thisCost;
            }
            else
            {
                thisCost = this.UnitCost * this.Quantity;
            }
            return thisCost;
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
            }
            else
            {
                materials.Add(this.Item, this.Quantity);
            }

            foreach (SFC_BomComponent component in children)
            {
                component.BillOfMaterials(ref materials);
            }
        }

        public override void metrics(int idepth, ref double dcost, ref double dbomCost, ref double dqty)
        {
            this.Depth = idepth + 1;
            double cost = 0;
            double bqty = 0;
            foreach (SFC_BomComponent component in children)
            {
                component.metrics(this.Depth, ref dcost, ref dbomCost, ref bqty);
                cost += dcost;
            }
            this.UnitCost = cost;
            this.BomCost = cost * this.Quantity;
            dcost = this.BomCost;
        }
    }
}
