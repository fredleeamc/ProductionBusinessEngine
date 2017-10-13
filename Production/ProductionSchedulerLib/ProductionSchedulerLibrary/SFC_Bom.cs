using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductionSchedulerLibrary
{

    /// <summary>
    /// Wrapper for Bom
    /// </summary>
    public class SFC_Bom
    {
        ShopFloorModel model;
        private readonly long id;
        private readonly SFC_BomComposite bom;
        private Dictionary<String, decimal> materials;
        private SFC_CurrencyExchange currencyExchange;
        private SFC_Currency currency;
        public long? UnitId;
        public string EngineeringChangeStatusId;
        public string BomItemTypeId;
        public decimal? EstimatedTotalCost;
        public decimal? EstimatedMateriallCost;
        public decimal? EstimatedMfgConsumableCost;
        public decimal? PercentScrap;
        public decimal? EstimatedOtherCost;
        public decimal? CalculatedCostPerUnit;
        private decimal totalQuantity;
        private decimal totalBomCost;


        public long Id => id;
        public SFC_BomComposite Bom => bom;
        public decimal TotalQuantity
        {
            get => totalQuantity;
            set
            {
                totalQuantity = value;
                //this.Calculate();
            }
        }
        public decimal TotalBomCost { get => totalBomCost; }
        public SFC_CurrencyExchange CurrencyExchange { get => currencyExchange; set => currencyExchange = value; }
        public SFC_Currency Currency { get => currency; set => currency = value; }
        public ShopFloorModel Model { get => model; set => model = value; }


        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Bom"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="partName">Name of the part.</param>
        /// <param name="partNo">The part no.</param>
        /// <param name="bom">The bom.</param>
        public SFC_Bom(long id, SFC_BomComposite bom)
        {
            this.id = id;
            this.bom = bom;
            this.totalBomCost = 0;
            this.totalQuantity = 1;
            materials = new Dictionary<String, decimal>();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            String sym = "";
            if (this.Currency != null)
                sym = this.Currency.Symbol;
            StringBuilder sb = new StringBuilder();
            sb.Append("BOM(): Items:" + sym + " " + this.totalQuantity + " " + this.Currency + "\n");
            //sb.Append(this.thisBom.Display(1));
            return sb.ToString();
        }


        public void DisplayBom()
        {
            String sym = "";
            if (this.Bom.Currency != null)
                sym = this.Bom.Currency.Symbol;
            String sym2 = "";
            if (this.Currency != null)
                sym2 = this.Currency.Symbol;
            Calculate();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("BOM(" + PartName + ":" + PartNo + "): Items:" + this.CountItems() + "\n");
            //sb.Append(this.thisBom.Display(1));
            //Console.WriteLine(sb.ToString());

            Console.WriteLine("BOM(" + " " + ")\n" +
                " Currency:" + this.Currency + "\n" +
                " Items:" + (this.Bom.ItemCount + "").PadLeft(20) + "\n" +
                " Total:" + sym + String.Format("{0:N}", this.TotalBomCost).PadLeft(20) + "\n" +                 
                " Total:" + sym2 + String.Format("{0:N}", this.EstimatedMateriallCost).PadLeft(20) + "\n" +
                " Qty:  " + String.Format("{0:N}", this.TotalQuantity).PadLeft(20) + "\n" 
               
                );
                
            this.bom.Display(1);
            Console.WriteLine();
        }


        public void Calculate()
        {
            this.bom.metrics(1, this.totalQuantity, this.Currency);
            this.EstimatedMateriallCost = this.bom.CalcSourceBuildCost * (this.Bom.CurrencyExchange == null ? 1 : this.Bom.CurrencyExchange.BuyingRate);
            this.EstimatedTotalCost = this.EstimatedMateriallCost + this.EstimatedMfgConsumableCost + this.EstimatedOtherCost;
            this.totalBomCost = this.Bom.CalcSourceBuildCost ;


        }

        ///// <summary>
        ///// Counts the items.
        ///// </summary>
        ///// <returns></returns>
        //public long CountItems()
        //{
        //    return bom.CountItems();
        //}

        /// <summary>
        /// Builds the bill of materials.
        /// </summary>
        /// <returns></returns>
        public IOrderedEnumerable<KeyValuePair<String, decimal>> BuildBillOfMaterials()
        {
            materials = new Dictionary<String, decimal>();
            this.bom.BillOfMaterials(ref materials, this.TotalQuantity);

            var items = from pair in materials
                        orderby pair.Key
                        select pair;

            //foreach (KeyValuePair<SFC_Item, decimal> pair in items)
            //{
            //    Console.WriteLine("{0}:{1}", pair.Key, pair.Value);
            //}
            return items;
        }


        public void PrintBillOfMaterials()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("BILL BOM():\r\n");

            IEnumerable<KeyValuePair<String, decimal>> pairs = this.BuildBillOfMaterials();
            foreach (KeyValuePair<String, decimal> pair in pairs)
            {
                sb.Append(String.Format("{0}:{1} \n", pair.Key, pair.Value));
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
