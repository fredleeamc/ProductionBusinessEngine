using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class ShopFloorView
    {
        private readonly ShopFloor models;
        private readonly ShopFloorController controller;

        public ShopFloorView(ShopFloor models, ShopFloorController controller)
        {
            this.models = models;
            this.controller = controller;
        }

        public ShopFloor Models => models;

        public ShopFloorController Controller => controller;
    }
}
