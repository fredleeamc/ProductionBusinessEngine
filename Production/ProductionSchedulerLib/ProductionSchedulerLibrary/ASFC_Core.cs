using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public abstract class ASFC_Core
    {
        private ShopFloorModel model;
        private SFC_CompanySettings settings;

        public ASFC_Core()
        {
        }

        public ShopFloorModel Model { get => model; set => model = value; }
        public SFC_CompanySettings Settings { get => settings; set => settings = value; }
    }
}
