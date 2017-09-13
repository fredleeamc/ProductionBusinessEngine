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
        }

        public override void Add(SFC_BomComponent component)
        {
            children.Add(component);
        }

        public override string Display(int depth)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append(new String('-', depth) + id + ":" + item);
            // Recursively display child nodes
            foreach (SFC_BomComponent component in children)
            {
               sb.Append(component.Display(depth + 2));
            }
            return sb.ToString();
        }

        public override void Remove(SFC_BomComponent component)
        {
            children.Remove(component);
        }
    }
}
