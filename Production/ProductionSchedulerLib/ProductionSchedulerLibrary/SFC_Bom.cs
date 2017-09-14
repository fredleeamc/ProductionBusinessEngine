using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductionSchedulerLibrary
{

    public class SFC_Bom 
    {
        private readonly long id;

        private readonly string partName;

        private readonly string partNo;

        private readonly SFC_BomComposite thisBom;

        private Dictionary<SFC_Item, double> materials;


        public long Id => id;

        public string PartName => partName;

        public string PartNo => partNo;

        public SFC_Bom(long id, string partName, string partNo, SFC_BomComposite bom)
        {
            this.id = id;
            this.partName = partName;
            this.partNo = partNo;
            this.thisBom = bom;
            materials = new Dictionary<SFC_Item, double>();
        }



        public override string ToString()
        {        
            StringBuilder sb = new StringBuilder();
            sb.Append("BOM("+PartName+":"+PartNo+"):\n");
            sb.Append(this.thisBom.Display(1));
            return sb.ToString();
        }

        public long CountItems()
        {
            return thisBom.CountItems();
        }

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
