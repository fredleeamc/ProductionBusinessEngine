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
            sb.Append("BOM("+PartName+":"+PartNo+"):\n");
            sb.Append(this.thisBom.Display(1));
            return sb.ToString();
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

    }






}
