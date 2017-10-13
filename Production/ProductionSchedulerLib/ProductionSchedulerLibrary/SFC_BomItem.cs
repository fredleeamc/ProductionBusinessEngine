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
        public SFC_BomItem(long id, String partName) : base(id, partName)
        {
            this.IsLeaf = true;
            this.ItemCount = 1;
        }

        public override void SetItem(SFC_Item thisItem)
        {
            if (thisItem != null)
            {
                this.Item = thisItem;
            }
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
            String sym = " ";
            String symP = "";
            if (this.Currency != null)
                sym = this.Currency.Symbol;
            if (this.ParentCurrency != null)
                symP = this.ParentCurrency.Symbol;

            String desc = Id + ":" + PartNo + ":" + PartName;
            String num1 = String.Format("{0:N}", Quantity);
            String num2 = String.Format("{0:N}", CalcSourceBomCost);
            String num3 = String.Format("{0:N}", CalcSourceUnitCost);
            String num4 = String.Format("{0:N}", CalcTotalQuantityRequired);
            String num5 = String.Format("{0:N}", CalcTargetBuildCost);
            //StringBuilder sb = new StringBuilder();
            //sb.Append(String.Format("{0:-20}{1,-40}{2,-40}", new String('-', depth) + "I", desc, num));
            String dash = new String('*', depth) + "I";
            Console.WriteLine(String.Format("{0}|{1}|Qty{2}|U" + sym + "{3}|S" + sym + "{4}|TQty{5}|TT" + symP + "{6}|{7}", dash.PadRight(20), desc.PadRight(30), num1.PadLeft(12), num3.PadLeft(12), num2.PadLeft(12), num4.PadLeft(12), num5.PadLeft(12), this.CurrencyExchange));

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
            return IsLeaf;
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
        public override void BillOfMaterials(ref Dictionary<String, decimal> materials, decimal multiplier)
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

        public override void metrics(int idepth, decimal multiplier, SFC_Currency baseCurrency)
        {
            Console.WriteLine(this.PartNo);
            this.Depth = idepth++;
            this.ParentCurrency = baseCurrency;
            this.CurrencyExchange = this.Currency.GetLatestExchange(baseCurrency);
            this.CalcSourceBomCost = this.UnitCost * this.Quantity;
            this.CalcTotalQuantityRequired = this.Quantity * multiplier;
            Console.WriteLine("CalcTotalQuantityRequired:" + this.CalcTotalQuantityRequired);
            this.CalcSourceUnitCost = this.UnitCost;
            Console.WriteLine("CalcSourceUnitCost:" + this.CalcSourceUnitCost);
            this.CalcSourceBuildCost = this.CalcSourceUnitCost * this.CalcTotalQuantityRequired;
            Console.WriteLine("CalcSourceBuildCost:" + this.CalcSourceBuildCost);
            if (baseCurrency == this.Currency)
            {
                this.CalcTargetUnitCost = this.CalcSourceUnitCost;
            }
            else
            {
                this.CalcTargetUnitCost = this.CalcSourceUnitCost / this.CurrencyExchange.BuyingRate;
            }
            this.CalcTargetBuildCost = this.CalcTotalQuantityRequired * this.CalcTargetUnitCost;
            Console.WriteLine("CalcTargetBuildCost:" + this.CalcTargetBuildCost);
        }

    }
}

