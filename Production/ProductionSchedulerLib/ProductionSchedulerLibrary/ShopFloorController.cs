using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class ShopFloorController
    {

        private readonly ShopFloorView view;
        private readonly ShopFloor models;

        public ShopFloorController(ShopFloorView view, ShopFloor models)
        {
            this.view = view;
            this.models = models;
        }

        public ShopFloorView View => view;

        public ShopFloor Models => models;
    }
}
