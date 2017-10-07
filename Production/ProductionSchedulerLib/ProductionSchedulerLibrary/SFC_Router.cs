using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_Router
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public Nullable<long> RevisionNo { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> DocumentSetId { get; set; }
        public bool IsObsolete { get; set; }
        public Nullable<System.DateTime> ObsoleteDate { get; set; }
        public Nullable<long> ReplacedByRouterId { get; set; }
        public string EngineeringChangeStatusId { get; set; }
        public bool IsVoid { get; set; }
        public string ApprovalCode { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
        public Nullable<long> ApprovedByUserId { get; set; }
        public bool IsPrinted { get; set; }
        public bool IsSent { get; set; }
        public Nullable<int> EngineeringPhaseId { get; set; }
        public string Description { get; set; }
        public Nullable<long> FamilyRouterId { get; set; }
        public Nullable<decimal> TargetQuantity { get; set; }
        public Nullable<decimal> MinQuantity { get; set; }
        public string RouterCode { get; set; }
        public Nullable<long> ManufacturingComponentId { get; set; }
        public Nullable<int> RouterActionId { get; set; }
        public string RouterTypeId { get; set; }
        public string Revision { get; set; }
        public Nullable<long> FinishedItemId { get; set; }
        public Nullable<long> WorkInstructionId { get; set; }
        public string PictureUrl { get; set; }
        public Nullable<decimal> EstimatedProcessCost { get; set; }
        public bool IsOutsideProcess { get; set; }
        public bool IsExported { get; set; }
        public Nullable<int> LeadTimeDays { get; set; }
        public Nullable<decimal> EstimatedTaxes { get; set; }
        public Nullable<decimal> EstimatedDuties { get; set; }
        public Nullable<decimal> EstimatedShippingCost { get; set; }
        public Nullable<decimal> EstimatedLandedCost { get; set; }
        public Nullable<decimal> PurchaseOrderQuantity { get; set; }
        public Nullable<decimal> EstimatedAdditionalOverhead { get; set; }
        public Nullable<long> CurrencyId { get; set; }
        public Nullable<long> CurrencyExchangeId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> DiagramId { get; set; }
        public bool IsCompleted { get; set; }
        public decimal OperationPlanYieldPercent { get; set; }
    }
}
