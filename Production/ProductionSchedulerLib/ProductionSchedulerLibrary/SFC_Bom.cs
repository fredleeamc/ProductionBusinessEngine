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
    public class SFC_Bom
    {

        private readonly long id;
        private readonly string partName;
        private readonly string partNo;
        private readonly SFC_BomComposite bom;
        private Dictionary<SFC_Item, decimal> materials;
        private SFC_CurrencyExchange currencyExchangeId;
        private SFC_Currency currencyId;
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
        private readonly decimal totalBomCost;


        public long Id => id;
        public string PartName => partName;
        public string PartNo => partNo;
        public SFC_BomComposite Bom => bom;
        public decimal TotalQuantity
        {
            get => totalQuantity;
            set
            {
                totalQuantity = value;                
                this.Calculate();
            }
        }
        public decimal TotalBomCost { get => totalBomCost; }
        public SFC_CurrencyExchange CurrencyExchangeId { get => currencyExchangeId; set => currencyExchangeId = value; }
        public SFC_Currency CurrencyId { get => currencyId; set => currencyId = value; }


        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Bom"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="partName">Name of the part.</param>
        /// <param name="partNo">The part no.</param>
        /// <param name="bom">The bom.</param>
        public SFC_Bom(long id, string partName, string partNo, SFC_BomComposite bom)
        {
            this.id = id;
            this.partName = partName;
            this.partNo = partNo;
            this.bom = bom;
            this.totalBomCost = 0;
            this.totalQuantity = 1;
            materials = new Dictionary<SFC_Item, decimal>();
        }





        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("BOM(" + PartName + ":" + PartNo + "): Items:" + this.CountItems() + "\n");
            //sb.Append(this.thisBom.Display(1));
            return sb.ToString();
        }


        public void DisplayBom()
        {
            Calculate();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("BOM(" + PartName + ":" + PartNo + "): Items:" + this.CountItems() + "\n");
            //sb.Append(this.thisBom.Display(1));
            //Console.WriteLine(sb.ToString());

            Console.WriteLine("BOM(" + PartName + ":" + PartNo + ")\n Items:" + this.CountItems() + "\n Total:" + this.TotalBomCost + "\n Qty:" + this.TotalQuantity);
            this.bom.Display(1);
            Console.WriteLine();
        }


        public void Calculate()
        {
            this.bom.metrics(1, this.totalQuantity);
            this.EstimatedMateriallCost = this.bom.CalculatedTotalBomTotalCost;
            this.EstimatedTotalCost = this.EstimatedMateriallCost + this.EstimatedMfgConsumableCost + this.EstimatedOtherCost;


        }

        /// <summary>
        /// Counts the items.
        /// </summary>
        /// <returns></returns>
        public long CountItems()
        {
            return bom.CountItems();
        }

        /// <summary>
        /// Builds the bill of materials.
        /// </summary>
        /// <returns></returns>
        public IOrderedEnumerable<KeyValuePair<SFC_Item, decimal>> BuildBillOfMaterials()
        {
            materials = new Dictionary<SFC_Item, decimal>();
            this.bom.BillOfMaterials(ref materials);

            var items = from pair in materials
                        orderby pair.Key.ItemCode
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
            sb.Append("BILL BOM(" + PartName + ":" + PartNo + "):\r\n");

            IEnumerable<KeyValuePair<SFC_Item, decimal>> pairs = this.BuildBillOfMaterials();
            foreach (KeyValuePair<SFC_Item, decimal> pair in pairs)
            {
                sb.Append(String.Format("{0}:{1} \n", pair.Key, pair.Value));
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
