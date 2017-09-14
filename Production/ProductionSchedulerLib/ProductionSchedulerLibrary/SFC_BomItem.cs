using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_BomItem : SFC_BomComponent
    {

        public SFC_BomItem(long id, SFC_Item item, double quantity) : base(id, item, quantity)
        {
            this.isLeaf = true;
        }

        public override void Add(SFC_BomComponent component)
        {
            Console.WriteLine("Cannot Add");
        }

        public override string Display(int depth)
        {
            return new String('-', depth) + id + ":" + item + ":" + quantity + "\n";
        }

        public override bool IsItem()
        {
            return isLeaf;
        }

        public override void Remove(SFC_BomComponent component)
        {
            Console.WriteLine("Cannot Remove");
        }

        public override int CountItems()
        {
            return 1;
        }

        public override double EstimatedCost()
        {
            return this.UnitCost * this.Quantity;
        }

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
