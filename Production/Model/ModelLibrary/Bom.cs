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
    
    public partial class Bom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bom()
        {
            this.Bom1 = new HashSet<Bom>();
            this.BomDetails = new HashSet<BomDetail>();
            this.BomDetails1 = new HashSet<BomDetail>();
            this.BomMfgConsumables = new HashSet<BomMfgConsumable>();
            this.BomOtherCostDetails = new HashSet<BomOtherCostDetail>();
            this.ProductBuildBomLinks = new HashSet<ProductBuildBomLink>();
        }
    
        public long Id { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
        public string PartName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Note { get; set; }
        public bool IsVoid { get; set; }
        public string ApprovalCode { get; set; }
        public Nullable<long> ApprovedByUserId { get; set; }
        public bool IsPrinted { get; set; }
        public bool IsSent { get; set; }
        public long CompanyId { get; set; }
        public Nullable<int> EngineeringPhaseId { get; set; }
        public Nullable<long> DocumentSetId { get; set; }
        public Nullable<long> ParentBomId { get; set; }
        public string PartNo { get; set; }
        public Nullable<long> CurrencyExchangeId { get; set; }
        public Nullable<long> CurrencyId { get; set; }
        public Nullable<long> UnitId { get; set; }
        public string EngineeringChangeStatusId { get; set; }
        public string BomItemTypeId { get; set; }
        public Nullable<decimal> EstimatedTotalCost { get; set; }
        public Nullable<decimal> EstimatedMateriallCost { get; set; }
        public Nullable<decimal> EstimatedMfgConsumableCost { get; set; }
        public Nullable<double> PercentScrap { get; set; }
        public Nullable<decimal> EstimatedOtherCost { get; set; }
        public Nullable<decimal> CalculatedCostPerUnit { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> DiagramId { get; set; }
        public bool IsCompleted { get; set; }
    
        public virtual BomItemType BomItemType { get; set; }
        public virtual Company Company { get; set; }
        public virtual EngineeringChangeStatu EngineeringChangeStatu { get; set; }
        public virtual EngineeringPhase EngineeringPhase { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bom> Bom1 { get; set; }
        public virtual Bom Bom2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomDetail> BomDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomDetail> BomDetails1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomMfgConsumable> BomMfgConsumables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomOtherCostDetail> BomOtherCostDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildBomLink> ProductBuildBomLinks { get; set; }
    }
}