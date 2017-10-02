using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class SFC_ProductBuild
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string PartName { get; set; }
        public int? EngineeringPhaseId { get; set; }
        public long? ModifiedByEmployeeId { get; set; }
        public long? ApprovedByUserId { get; set; }
        public string ApprovalCode { get; set; }
        public bool IsVoid { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string EngineeringNotes { get; set; }
        public long? FinishedItemId { get; set; }
        public string PartNo { get; set; }
        public long? DrawingAttachmentId { get; set; }
        public long? DocumentSetId { get; set; }
        public long? ParentProductBuildId { get; set; }
        public long? CurrencyId { get; set; }
        public long? CurrencyExchangeId { get; set; }
        public double? PercentScrap { get; set; }
        public decimal? EstimatedTaxes { get; set; }
        public decimal? EstimatedDuties { get; set; }
        public decimal? EstimatedShippingCost { get; set; }
        public decimal? EstimatedLandedCost { get; set; }
        public decimal? EstimatedAdditionalOverhead { get; set; }
        public decimal? EstimatedProcessCost { get; set; }
        public decimal? EstimatedMaterialCost { get; set; }
        public decimal? EstimatedPackagingCost { get; set; }
        public decimal? EstimatedMfgConsumableCost { get; set; }
        public decimal? EstimatedDevelopmentLaborCost { get; set; }
        public decimal? EstimatedDevelopmentInvestmentCost { get; set; }
        public decimal? EstimatedTotalCost { get; set; }
        public decimal? EstimatedOtherBomCost { get; set; }
        public decimal? CalculatedCostPerUnit { get; set; }
        public long? UnitId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? DiagramId { get; set; }
        public bool IsCompleted { get; set; }
        public decimal? BuildQuantitiy { get; set; }
        public double OperationPlanYieldPercent { get; set; }
    }
}
