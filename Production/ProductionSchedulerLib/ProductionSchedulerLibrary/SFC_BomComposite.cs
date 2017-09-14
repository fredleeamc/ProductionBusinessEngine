using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_BomComposite : SFC_BomComponent
    {
        private List<SFC_BomComponent> children;

        public SFC_BomComposite(long id, SFC_Item item, long qty) : base(id, item, qty)
        {
            children = new List<SFC_BomComponent>();
            this.isLeaf = false;
            item.SetBom(this);
        }

        public override void Add(SFC_BomComponent component)
        {
            if (!this.IsCircular(component))
            {
                component.SetParent(this);
                children.Add(component);
            }
            else
            {
                Console.WriteLine(this.Item.ItemCode + "<-" + component.Item.ItemCode + " is circular.");
            }
        }



        public override string Display(int depth)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(new String('-', depth) + Id + ":" + Item + ":" + Quantity + "\n");
            // Recursively display child nodes
            foreach (SFC_BomComponent component in children)
            {
                sb.Append(component.Display(depth + 2));
            }
            return sb.ToString();
        }

        public override bool IsItem()
        {
            return isLeaf;
        }

        public override void Remove(SFC_BomComponent component)
        {
            children.Remove(component);
        }

        public override int CountItems()
        {
            int count = 1;
            foreach (SFC_BomComponent component in children)
            {
                count += component.CountItems();
            }
            return count;
        }


        public override double EstimatedCost()
        {
            throw new NotImplementedException();
        }


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
    }
}
