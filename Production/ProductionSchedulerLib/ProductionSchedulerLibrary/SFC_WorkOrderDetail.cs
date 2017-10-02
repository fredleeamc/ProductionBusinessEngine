using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_WorkOrderDetail : IEquatable<SFC_WorkOrderDetail>, IComparable<SFC_WorkOrderDetail>
    {      
        public readonly static SFC_WorkOrderDetail NONE = new SFC_WorkOrderDetail(0, 0);

        private readonly long id;
        private readonly long operationSequence;

        private long routerDetailsId;
        private decimal orderedQuantity;
        private decimal producedQuantity;
        private decimal scrapQuantity;
        private decimal estimatedMaterialCost;
        private decimal estimatedLaborCost;
        private decimal estimatedOverheadCost;
        private decimal estimatedToolingCost;
        private decimal estimatedProductionConsumablesCost;
        private decimal estimatedPackagingCost;
        private decimal machineCost;

        public long Id => id;

        public long OperationSequence => operationSequence;

        public long RouterDetails { get => routerDetailsId; set => routerDetailsId = value; }
        public decimal OrderedQuantity { get => orderedQuantity; set => orderedQuantity = value; }
        public decimal ProducedQuantity { get => producedQuantity; set => producedQuantity = value; }
        public decimal ScrapQuantity { get => scrapQuantity; set => scrapQuantity = value; }
        public decimal EstimatedMaterialCost { get => estimatedMaterialCost; set => estimatedMaterialCost = value; }
        public decimal EstimatedLaborCost { get => estimatedLaborCost; set => estimatedLaborCost = value; }
        public decimal EstimatedOverheadCost { get => estimatedOverheadCost; set => estimatedOverheadCost = value; }
        public decimal EstimatedToolingCost { get => estimatedToolingCost; set => estimatedToolingCost = value; }
        public decimal EstimatedProductionConsumablesCost { get => estimatedProductionConsumablesCost; set => estimatedProductionConsumablesCost = value; }
        public decimal EstimatedPackagingCost { get => estimatedPackagingCost; set => estimatedPackagingCost = value; }
        public decimal MachineCost { get => machineCost; set => machineCost = value; }

        public SFC_WorkOrderDetail(long id, long operationSequence)
        {
            this.id = id;
            this.operationSequence = operationSequence;

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SFC_WorkOrderDetail);
        }

        public bool Equals(SFC_WorkOrderDetail other)
        {
            return other != null &&
                   id == other.id &&
                   operationSequence == other.operationSequence;
        }

        public int CompareTo(SFC_WorkOrderDetail other)
        {
            if (other == null)
                return 1;

            SFC_WorkOrderDetail otherItem = other as SFC_WorkOrderDetail;
            if (otherItem != null)
            {
                if (this.id == other.id)
                    return this.operationSequence.CompareTo(otherItem.operationSequence);
                else
                    return this.id.CompareTo(other.Id);
            }
            else
                throw new ArgumentException("Object is not a SFC_WorkOrderDetail");
        }

        public static bool operator ==(SFC_WorkOrderDetail detail1, SFC_WorkOrderDetail detail2)
        {
            return EqualityComparer<SFC_WorkOrderDetail>.Default.Equals(detail1, detail2);
        }

        public static bool operator !=(SFC_WorkOrderDetail detail1, SFC_WorkOrderDetail detail2)
        {
            return !(detail1 == detail2);
        }
    }
}
