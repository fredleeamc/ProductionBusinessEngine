using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_Items : SFC_Container<SFC_Item>
    {
        public SFC_Items() : base()
        {
        }

        /// <summary>
        /// Shows the item status.
        /// </summary>
        public void PrintItemsStatus()
        {
            foreach (long itemId in Lists.Keys)
            {
                Console.WriteLine(Lists[itemId].PrintStatus());
            }
        }
    }
}
