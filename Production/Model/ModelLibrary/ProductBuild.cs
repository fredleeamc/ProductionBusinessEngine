//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductBuild
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductBuild()
        {
            this.ProductBuild1 = new HashSet<ProductBuild>();
            this.ProductBuildBomLinks = new HashSet<ProductBuildBomLink>();
            this.ProductBuildDetails = new HashSet<ProductBuildDetail>();
            this.ProductBuildDevelopmentLabors = new HashSet<ProductBuildDevelopmentLabor>();
            this.ProductBuildDrafts = new HashSet<ProductBuildDraft>();
            this.ProductBuildInvestments = new HashSet<ProductBuildInvestment>();
            this.ProductBuildInvestments1 = new HashSet<ProductBuildInvestment>();
            this.ProductBuildRouterLinks = new HashSet<ProductBuildRouterLink>();
            this.WorkOrders = new HashSet<WorkOrder>();
        }
    
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string PartName { get; set; }
        public Nullable<int> EngineeringPhaseId { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
        public Nullable<long> ApprovedByUserId { get; set; }
        public string ApprovalCode { get; set; }
        public bool IsVoid { get; set; }
        public Nullable<System.DateTime> ApprovedOn { get; set; }
        public string EngineeringNotes { get; set; }
        public Nullable<long> FinishedItemId { get; set; }
        public string PartNo { get; set; }
        public Nullable<long> DrawingAttachmentId { get; set; }
        public Nullable<long> DocumentSetId { get; set; }
        public Nullable<long> ParentProductBuildId { get; set; }
        public Nullable<long> CurrencyId { get; set; }
        public Nullable<long> CurrencyExchangeId { get; set; }
        public Nullable<double> PercentScrap { get; set; }
        public Nullable<decimal> EstimatedTaxes { get; set; }
        public Nullable<decimal> EstimatedDuties { get; set; }
        public Nullable<decimal> EstimatedShippingCost { get; set; }
        public Nullable<decimal> EstimatedLandedCost { get; set; }
        public Nullable<decimal> EstimatedAdditionalOverhead { get; set; }
        public Nullable<decimal> EstimatedProcessCost { get; set; }
        public Nullable<decimal> EstimatedMaterialCost { get; set; }
        public Nullable<decimal> EstimatedPackagingCost { get; set; }
        public Nullable<decimal> EstimatedMfgConsumableCost { get; set; }
        public Nullable<decimal> EstimatedDevelopmentLaborCost { get; set; }
        public Nullable<decimal> EstimatedDevelopmentInvestmentCost { get; set; }
        public Nullable<decimal> EstimatedTotalCost { get; set; }
        public Nullable<decimal> EstimatedOtherBomCost { get; set; }
        public Nullable<decimal> CalculatedCostPerUnit { get; set; }
        public Nullable<long> UnitId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> DiagramId { get; set; }
        public bool IsCompleted { get; set; }
        public Nullable<decimal> BuildQuantitiy { get; set; }
        public double OperationPlanYieldPercent { get; set; }
    
        public virtual EngineeringPhase EngineeringPhase { get; set; }
        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Item Item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuild> ProductBuild1 { get; set; }
        public virtual ProductBuild ProductBuild2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildBomLink> ProductBuildBomLinks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildDetail> ProductBuildDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildDevelopmentLabor> ProductBuildDevelopmentLabors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildDraft> ProductBuildDrafts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildInvestment> ProductBuildInvestments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildInvestment> ProductBuildInvestments1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildRouterLink> ProductBuildRouterLinks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual CurrencyExchange CurrencyExchange { get; set; }
    }
}
