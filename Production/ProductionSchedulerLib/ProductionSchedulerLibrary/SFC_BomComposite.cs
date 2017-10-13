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
        public SFC_BomComposite(long id, String partName) : base(id, partName)
        {
            children = new List<SFC_BomComponent>();
            this.IsLeaf = false;
        }


        public override void SetItem(SFC_Item thisItem)
        {
            if (thisItem != null)
            {
                this.Item = thisItem;
                this.Item.SetBom(this);
            }
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

        //public override decimal Cost()
        //{
        //    decimal nCost = 0;
        //    foreach (SFC_BomComponent component in children)
        //    {
        //        nCost += component.Cost();
        //    }
        //    this.BomCost = nCost;
        //    return nCost;
        //}



        /// <summary>
        /// Displays the specified depth.
        /// </summary>
        /// <param name="depth">The depth.</param>
        /// <returns></returns>
        public override string Display(int depth)
        {
            String sym = " ";
            String symP = " ";
            if (this.Currency != null)
                sym = this.Currency.Symbol;
            if (this.ParentCurrency != null)
                symP = this.ParentCurrency.Symbol;

            String desc = Id + ":" + PartNo + ":" + PartName;
            String num1 = String.Format("{0:N}", Quantity);
            String num2 = String.Format("{0:N}", Quantity * CalcSourceUnitCost);
            String num3 = String.Format("{0:N}", CalcSourceUnitCost);
            String num4 = String.Format("{0:N}", CalcTotalQuantityRequired);
            String num5 = String.Format("{0:N}", CalcTargetBuildCost);
            //StringBuilder sb = new StringBuilder();
            //sb.Append(String.Format("{0:-20}{1,-40}{2,-40}", new String('-', depth) + "I", desc, num));
            String dash = new String('*', depth) + "C";
            Console.WriteLine(String.Format("{0}|{1}|Qty{2}|U" + sym + "{3}|S" + sym + "{4}|TQty{5}|TT" + symP + "{6}|{7}", dash.PadRight(20), desc.PadRight(30), num1.PadLeft(12), num3.PadLeft(12), num2.PadLeft(12), num4.PadLeft(12), num5.PadLeft(12), this.CurrencyExchange));

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
            return IsLeaf;
        }

        /// <summary>
        /// Removes the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        public override void Remove(SFC_BomComponent component)
        {
            children.Remove(component);
        }

        ///// <summary>
        ///// Counts the items.
        ///// </summary>
        ///// <returns></returns>
        //public override int CountItems()
        //{
        //    int count = 1;
        //    foreach (SFC_BomComponent component in children)
        //    {
        //        count += component.CountItems();
        //    }
        //    return count;
        //}


        /// <summary>
        /// Estimateds the cost.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //public override decimal EstimatedCost()
        //{
        //    decimal thisCost = 0;
        //    if (children.Count > 0)
        //    {
        //        foreach (SFC_BomComponent component in children)
        //        {
        //            decimal t = component.EstimatedCost();
        //            thisCost += t;
        //            Console.WriteLine(component.Item + "=" + t + " Total:" + thisCost);
        //        }
        //        this.BomCost = thisCost;
        //    }
        //    else
        //    {
        //        thisCost = this.UnitCost * this.Quantity;
        //    }
        //    return thisCost;
        //}


        /// <summary>
        /// Bills the of materials.
        /// </summary>
        /// <param name="materials">The materials.</param>
        public override void BillOfMaterials(ref Dictionary<String, decimal> materials, decimal multiplier)
        {
            if (this.Item != null)
            {
                if (materials.ContainsKey(this.PartNo))
                {
                    materials[this.PartNo] += this.Quantity * multiplier;
                }
                else
                {
                    materials.Add(this.PartNo, this.Quantity * multiplier);
                }
            }

            foreach (SFC_BomComponent component in children)
            {
                component.BillOfMaterials(ref materials, multiplier / this.Quantity);
            }
        }

        public override void metrics(int idepth, decimal multiplier, SFC_Currency baseCurrency)
        {
            idepth++;
            long itemsCount = 0;
            decimal targetBuildCost = 0;
            decimal srcBuildCost = 0;
            this.ParentCurrency = baseCurrency;
            Console.WriteLine(this.PartNo);
            this.CalcSourceBomCost = this.UnitCost * this.Quantity;
            this.CalcTotalQuantityRequired = this.Quantity * multiplier;
            this.CurrencyExchange = this.Currency.GetLatestExchange(baseCurrency);
            Console.WriteLine("CalcTotalQuantityRequired:" + this.CalcTotalQuantityRequired);
            Console.WriteLine("IN");
            foreach (SFC_BomComponent component in children)
            {
                Console.WriteLine("Component:");
                component.metrics(idepth, this.CalcTotalQuantityRequired, baseCurrency);
                targetBuildCost += component.CalcTargetBuildCost;
                if (component.Currency != this.Currency)
                {
                    srcBuildCost += component.CalcSourceBuildCost / component.Currency.GetLatestExchange(this.Currency).BuyingRate;
                    Console.WriteLine("Exchange:" + component.Currency.GetLatestExchange(this.Currency));
                } else
                {
                    srcBuildCost += component.CalcSourceBuildCost; 
                }
                Console.WriteLine("srcBuildCost:" + srcBuildCost);
            }
            Console.WriteLine("OUT");
            Console.WriteLine(this.PartNo);
            this.CalcSourceBuildCost = srcBuildCost;
            this.CalcSourceUnitCost = srcBuildCost / this.CalcTotalQuantityRequired;
            Console.WriteLine("CalcSourceUnitCost:" + this.CalcSourceUnitCost);
            this.CalcTargetBuildCost = targetBuildCost;
            Console.WriteLine("CalcTargetBuildCost:" + this.CalcTargetBuildCost);
            this.CalcTargetUnitCost = targetBuildCost / this.CalcTotalQuantityRequired;
            Console.WriteLine("CalcTargetUnitCost:" + this.CalcTargetUnitCost);
            this.ItemCount = itemsCount + 1;
        }
    }
}
