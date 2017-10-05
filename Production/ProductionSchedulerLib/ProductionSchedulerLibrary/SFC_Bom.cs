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
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The part name
        /// </summary>
        private readonly string partName;

        /// <summary>
        /// The part no
        /// </summary>
        private readonly string partNo;

        /// <summary>
        /// The this bom
        /// </summary>
        private readonly SFC_BomComposite thisBom;

        /// <summary>
        /// The materials
        /// </summary>
        private Dictionary<SFC_Item, double> materials;

        private double totalQuantity;

        private double totalBomCost;

        public long? CurrencyExchangeId;
        public long? CurrencyId;
        public long? UnitId;
        public string EngineeringChangeStatusId;
        public string BomItemTypeId;
        public decimal? EstimatedTotalCost;
        public decimal? EstimatedMateriallCost;
        public decimal? EstimatedMfgConsumableCost;
        public double? PercentScrap;
        public decimal? EstimatedOtherCost;
        public decimal? CalculatedCostPerUnit;


        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id => id;

        /// <summary>
        /// Gets the name of the part.
        /// </summary>
        /// <value>
        /// The name of the part.
        /// </value>
        public string PartName => partName;

 

        /// <summary>
        /// Gets the part no.
        /// </summary>
        /// <value>
        /// The part no.
        /// </value>
        public string PartNo => partNo;

        public long Id1 => id;

        public string PartName1 => partName;

        public string PartNo1 => partNo;

        public SFC_BomComposite ThisBom => thisBom;

        public double TotalQuantity { get => totalQuantity; set => totalQuantity = value; }
        public double TotalBomCost { get => totalBomCost; set => totalBomCost = value; }


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
            this.thisBom = bom;
            this.totalBomCost = 0;
            this.totalQuantity = 0;
            materials = new Dictionary<SFC_Item, double>();
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

            Console.WriteLine("BOM(" + PartName + ":" + PartNo + ") | Items:" + this.CountItems() + "| Total:"+this.TotalBomCost+ "| Qty:"+this.TotalQuantity);
            this.thisBom.Display(1);
            Console.WriteLine();
        }


        public void Calculate()
        {
            double totalBomCost = 0;
            double levelBomCost = 0;
            double totalQty = 0;
            this.thisBom.metrics(1, ref levelBomCost, ref totalBomCost, ref totalQty);
            this.totalBomCost = totalBomCost;
            this.totalQuantity = totalQty;
        }

        /// <summary>
        /// Counts the items.
        /// </summary>
        /// <returns></returns>
        public long CountItems()
        {
            return thisBom.CountItems();
        }

        /// <summary>
        /// Builds the bill of materials.
        /// </summary>
        /// <returns></returns>
        public IOrderedEnumerable<KeyValuePair<SFC_Item, double>> BuildBillOfMaterials()
        {
            this.thisBom.BillOfMaterials(ref materials);

            var items = from pair in materials
                        orderby pair.Key.ItemCode
                        select pair;

            //foreach (KeyValuePair<SFC_Item, double> pair in items)
            //{
            //    Console.WriteLine("{0}:{1}", pair.Key, pair.Value);
            //}
            return items;
        }


        public void PrintBillOfMaterials()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("BILL BOM(" + PartName + ":" + PartNo + "):\r\n");
           
            IEnumerable <KeyValuePair<SFC_Item, double>> pairs = this.BuildBillOfMaterials();
            foreach (KeyValuePair<SFC_Item, double> pair in pairs)
            {
                sb.Append(String.Format("{0}:{1} \n", pair.Key, pair.Value));
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
