using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_RouterProcessDetail
    {
        public long Id;
        public long? RouterProcessId;
        public long? OperationSequence;
        public long WorkCenterId;
        public string OperationDescription;
        public decimal? QuantityOperators;
        public decimal? EstimatedSetupTime;
        public long? SetupUnitId;
        public decimal? EstimatedSetupHour;
        public long? RunUnitId;
        public decimal? EstimatedMachineRuntime;
        public long? MachineUnitId;
        public decimal? EstimatedMachineRuntimeHour;
        public bool IsSkipOperation;
        public string EngineeringChangeStatusId;
        public float? PercentOverlap;
        public long? WorkInstructionId;
        public long? WorkCenterGroupId;
        public decimal? QuantitySetters;
        public decimal? EstimatedSetupHourlyRate;
        public decimal? EstimatedSetupCost;
        public decimal? EstimatedRunTimePiece;
        public decimal? EstimatedRuntimeHourPiece;
        public decimal? EstimatedRuntimeHourlyRate;
        public decimal? EstimatedRuntimeCostPiece;
        public decimal? EstimatedMachineRuntimeHourlyRate;
        public decimal? EstimatedMachineRuntimeCost;
        public decimal? EstimatedTeardownTime;
        public long? TeardownUnitId;
        public decimal? EstimatedTeardownHour;
        public decimal? EstimatedTeardownHourlyRate;
        public decimal? EstimatedTeardownCost;
        public long? CurrencyId;
        public long? CurrencyExchangeId;
        public decimal? EstimatedLaborOverheadFactor;
        public decimal? EstimatedLaborOverheadCost;
        public bool IsDeleted;
        public DateTime? CreatedOn;
        public DateTime? ModifiedOn;
        public long? ModifiedByEmployeeId;
        public long? MachineFixtureId;
    }
}
