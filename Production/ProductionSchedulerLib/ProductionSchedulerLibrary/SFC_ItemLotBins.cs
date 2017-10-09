using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public  class SFC_ItemLotBins : Base_SFC_Container<SFC_ItemLotBin>
    {
        public  SFC_ItemLotBins() : base()
        {
        }

        /// <summary>
        /// Shows the boms.
        /// </summary>
        new public  void Print()
        {
            foreach (long id in Lists.Keys)
            {
                Console.Write(Lists[id]);
                Console.WriteLine(Lists[id].ItemStatus);
            }
        }
    }
}
