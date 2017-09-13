using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_BomItem : SFC_BomComponent
    {
        
        public SFC_BomItem(long id, SFC_Item item, long quantity) : base(id, item, quantity)
        {
            this.isLeaf = true;
        }

        public override void Add(SFC_BomComponent component)
        {
            Console.WriteLine("Cannot Add");
        }

        public override string Display(int depth)
        {
            return new String('-', depth) + id + ":" + item;
        }

        public override void Remove(SFC_BomComponent component)
        {
            Console.WriteLine("Cannot Remove");
        }
    }
}
