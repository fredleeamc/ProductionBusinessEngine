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
    
    public partial class BomDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BomDetail()
        {
            this.ProductBuildMaterials = new HashSet<ProductBuildMaterial>();
        }
    
        public long Id { get; set; }
        public long BomId { get; set; }
        public Nullable<int> ProcurementTypeId { get; set; }
        public Nullable<long> UnitId { get; set; }
        public string Note { get; set; }
        public string RefDesignators { get; set; }
        public Nullable<long> ChildBomId { get; set; }
        public Nullable<long> CurrencyExchangeId { get; set; }
        public Nullable<long> CurrencyId { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> EstimatedTotalCost { get; set; }
        public Nullable<decimal> EstimatedUnitCost { get; set; }
        public Nullable<long> ManufacturedComponentId { get; set; }
        public Nullable<long> ItemBuyId { get; set; }
        public string BomItemTypeId { get; set; }
        public long VendorId { get; set; }
        public bool IsImported { get; set; }
        public Nullable<long> AddressId { get; set; }
        public Nullable<decimal> RequiredQuantity { get; set; }
        public Nullable<decimal> PurchaseOrderQuantity { get; set; }
        public Nullable<int> LeadTimeDays { get; set; }
        public Nullable<decimal> EstimatedTaxes { get; set; }
        public Nullable<decimal> EstimatedDuties { get; set; }
        public Nullable<decimal> EstimatedShippingCost { get; set; }
        public Nullable<decimal> EstimatedAdditionalOverhead { get; set; }
        public Nullable<decimal> EstimatedLandedCost { get; set; }
        public Nullable<double> PercentScrap { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
    
        public virtual Bom Bom { get; set; }
        public virtual Bom Bom1 { get; set; }
        public virtual BomItemType BomItemType { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ManufacturedComponent ManufacturedComponent { get; set; }
        public virtual Vendor Vendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildMaterial> ProductBuildMaterials { get; set; }
    }
}