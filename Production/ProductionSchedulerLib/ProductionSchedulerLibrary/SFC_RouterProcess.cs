using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public  class SFC_RouterProcess
    {
        private readonly long id;
        private readonly string processName;
        private string processDescription;
        private string engineeringChangeStatusId;
        private long? manufacturedComponentId;
        private long? workInstructionId;
        private decimal? estimatedFixedProcessCost;
        private decimal? estimatedVariableCostPiece;
        private bool isExported;
        private int? leadTimeDays;
        private decimal? estimatedTaxes;
        private decimal? estimatedDuties;
        private decimal? estimatedShippingCost;
        private decimal? estimatedLandedCost;
        private decimal? estimatedAdditionalOverhead;
        private long? currencyId;
        private long? currencyExchangeId;
        private bool isDeleted;
        private DateTime? createdOn;
        private DateTime? modifiedOn;
        private long? modifiedByEmployeeId;
        private bool isCompleted;

        public  long Id => id;

        public  string ProcessName => processName;

        public  string ProcessDescription { get => processDescription; set => processDescription = value; }
        public  string EngineeringChangeStatusId { get => engineeringChangeStatusId; set => engineeringChangeStatusId = value; }
        public  long? ManufacturedComponentId { get => manufacturedComponentId; set => manufacturedComponentId = value; }
        public  long? WorkInstructionId { get => workInstructionId; set => workInstructionId = value; }
        public  decimal? EstimatedFixedProcessCost { get => estimatedFixedProcessCost; set => estimatedFixedProcessCost = value; }
        public  decimal? EstimatedVariableCostPiece { get => estimatedVariableCostPiece; set => estimatedVariableCostPiece = value; }
        public  bool IsExported { get => isExported; set => isExported = value; }
        public  int? LeadTimeDays { get => leadTimeDays; set => leadTimeDays = value; }
        public  decimal? EstimatedTaxes { get => estimatedTaxes; set => estimatedTaxes = value; }
        public  decimal? EstimatedDuties { get => estimatedDuties; set => estimatedDuties = value; }
        public  decimal? EstimatedShippingCost { get => estimatedShippingCost; set => estimatedShippingCost = value; }
        public  decimal? EstimatedLandedCost { get => estimatedLandedCost; set => estimatedLandedCost = value; }
        public  decimal? EstimatedAdditionalOverhead { get => estimatedAdditionalOverhead; set => estimatedAdditionalOverhead = value; }
        public  long? CurrencyId { get => currencyId; set => currencyId = value; }
        public  long? CurrencyExchangeId { get => currencyExchangeId; set => currencyExchangeId = value; }
        public  bool IsDeleted { get => isDeleted; set => isDeleted = value; }
        public  DateTime? CreatedOn { get => createdOn; set => createdOn = value; }
        public  DateTime? ModifiedOn { get => modifiedOn; set => modifiedOn = value; }
        public  long? ModifiedByEmployeeId { get => modifiedByEmployeeId; set => modifiedByEmployeeId = value; }
        public  bool IsCompleted { get => isCompleted; set => isCompleted = value; }

        public  SFC_RouterProcess(long id, String processName)
        {
            this.id = id;
            this.processName = processName;
        }
    }
}
