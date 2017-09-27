using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_WorkOrderDetails
    {
        private readonly long id;
        public readonly static SFC_WorkOrderDetails NONE = new SFC_WorkOrderDetails();
        public readonly long workOrder;
        public long productBuildDetails;
        public decimal orderedQuantity;
        public decimal producedQuantity;
        public decimal scrapQuantity;
        public decimal estimatedMaterialCost;
        public decimal estimatedLaborCost;
        public decimal estimatedOverheadCost;
        public decimal estimatedToolingCost;
        public decimal estimatedProductionConsumablesCost;
        public decimal estimatedPackagingCost;
        public decimal machineCost;
    }
}
