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
    public  class SFC_ProductBuild
    {
        private readonly long id;
        private readonly string partName;
        private int? engineeringPhaseId;
        private SFC_Item finishedItem;
        private readonly string partNo;

        private SFC_ProductBuild parentProductBuild;
        private SFC_Currency currency;
        private SFC_CurrencyExchange currencyExchange;
        private decimal? percentScrap;
        private decimal? estimatedTaxes;
        private decimal? estimatedDuties;
        private decimal? estimatedShippingCost;
        private decimal? estimatedLandedCost;
        private decimal? estimatedAdditionalOverhead;
        private decimal? estimatedProcessCost;
        private decimal? estimatedMaterialCost;
        private decimal? estimatedPackagingCost;
        private decimal? estimatedMfgConsumableCost;
        private decimal? estimatedDevelopmentLaborCost;
        private decimal? estimatedDevelopmentInvestmentCost;
        private decimal? estimatedTotalCost;
        private decimal? estimatedOtherBomCost;
        private decimal? calculatedCostPerUnit;
        private SFC_Unit unit;
        private bool isDeleted;
        private decimal? buildQuantitiy;
        private decimal operationPlanYieldPercent;

        public SFC_ProductBuild(long id, string partName, string partNo)
        {
            this.id = id;
            this.partName = partName;
            this.partNo = partNo;
        }

        public long Id { get => id; }
        public string PartName { get => partName; }
        public int? EngineeringPhaseId { get => engineeringPhaseId; set => engineeringPhaseId = value; }
        public SFC_Item FinishedItem { get => finishedItem; set => finishedItem = value; }
        public string PartNo { get => partNo; }
        public SFC_ProductBuild ParentProductBuild { get => parentProductBuild; set => parentProductBuild = value; }
        public SFC_Currency Currency { get => currency; set => currency = value; }
        public SFC_CurrencyExchange CurrencyExchange { get => currencyExchange; set => currencyExchange = value; }
        public decimal? PercentScrap { get => percentScrap; set => percentScrap = value; }
        public decimal? EstimatedTaxes { get => estimatedTaxes; set => estimatedTaxes = value; }
        public decimal? EstimatedDuties { get => estimatedDuties; set => estimatedDuties = value; }
        public decimal? EstimatedShippingCost { get => estimatedShippingCost; set => estimatedShippingCost = value; }
        public decimal? EstimatedLandedCost { get => estimatedLandedCost; set => estimatedLandedCost = value; }
        public decimal? EstimatedAdditionalOverhead { get => estimatedAdditionalOverhead; set => estimatedAdditionalOverhead = value; }
        public decimal? EstimatedProcessCost { get => estimatedProcessCost; set => estimatedProcessCost = value; }
        public decimal? EstimatedMaterialCost { get => estimatedMaterialCost; set => estimatedMaterialCost = value; }
        public decimal? EstimatedPackagingCost { get => estimatedPackagingCost; set => estimatedPackagingCost = value; }
        public decimal? EstimatedMfgConsumableCost { get => estimatedMfgConsumableCost; set => estimatedMfgConsumableCost = value; }
        public decimal? EstimatedDevelopmentLaborCost { get => estimatedDevelopmentLaborCost; set => estimatedDevelopmentLaborCost = value; }
        public decimal? EstimatedDevelopmentInvestmentCost { get => estimatedDevelopmentInvestmentCost; set => estimatedDevelopmentInvestmentCost = value; }
        public decimal? EstimatedTotalCost { get => estimatedTotalCost; set => estimatedTotalCost = value; }
        public decimal? EstimatedOtherBomCost { get => estimatedOtherBomCost; set => estimatedOtherBomCost = value; }
        public decimal? CalculatedCostPerUnit { get => calculatedCostPerUnit; set => calculatedCostPerUnit = value; }
        public SFC_Unit Unit { get => unit; set => unit = value; }
        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }
        public decimal? BuildQuantitiy { get => buildQuantitiy; set => buildQuantitiy = value; }
        public decimal OperationPlanYieldPercent { get => operationPlanYieldPercent; set => operationPlanYieldPercent = value; }
    }
}
