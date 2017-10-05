using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_Boms : SFC_Container<SFC_Bom>
    {
        public SFC_Boms() : base()
        {
        }

        public void PrintBillOfMaterials()
        {
            foreach (long b in Lists.Keys)
            {
                Lists[b].PrintBillOfMaterials();
            }
        }

        public void DisplayBom()
        {
            foreach (long b in Lists.Keys)
            {
                Lists[b].DisplayBom();
            }
        }
    }
}
