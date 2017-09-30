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
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.ManufacturedComponents = new HashSet<ManufacturedComponent>();
            this.ProductBuilds = new HashSet<ProductBuild>();
            this.ProductBuildDrafts = new HashSet<ProductBuildDraft>();
            this.Routers = new HashSet<Router>();
            this.ItemLocations = new HashSet<ItemLocation>();
            this.ItemLotBins = new HashSet<ItemLotBin>();
            this.ItemSerials = new HashSet<ItemSerial>();
            this.Machines = new HashSet<Machine>();
            this.StockMovementDetails = new HashSet<StockMovementDetail>();
            this.WorkOrders = new HashSet<WorkOrder>();
        }
    
        public long Id { get; set; }
        public Nullable<long> ItemCategoryId { get; set; }
        public long CompanyId { get; set; }
        public Nullable<long> ItemClassId { get; set; }
        public long DescriptionId { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
        public Nullable<long> DocumentSetId { get; set; }
        public Nullable<long> SalesAccountId { get; set; }
        public Nullable<long> SalesDiscountAccountId { get; set; }
        public Nullable<long> BudgetCogsAccountId { get; set; }
        public Nullable<long> InventoryAccountId { get; set; }
        public Nullable<long> TaxAccountId { get; set; }
        public Nullable<long> VatAccountId { get; set; }
        public Nullable<long> AdjustmentAccountId { get; set; }
        public Nullable<long> AssemblyAccountId { get; set; }
        public string ItemCode { get; set; }
        public string Revision { get; set; }
        public Nullable<decimal> ActualCost { get; set; }
        public Nullable<decimal> LastCost { get; set; }
        public Nullable<decimal> MaterialCost { get; set; }
        public Nullable<decimal> LaborCost { get; set; }
        public Nullable<decimal> OverheadCost { get; set; }
        public bool Inactive { get; set; }
        public long StockingUnitId { get; set; }
        public string BarCode { get; set; }
        public bool IsSold { get; set; }
        public bool IsBought { get; set; }
        public bool IsMfgComponent { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ProductLineId { get; set; }
        public bool IsMfgConsumable { get; set; }
        public bool IsObsolete { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ShortDescription { get; set; }
        public Nullable<long> SpecificationId { get; set; }
        public Nullable<long> ItemSubcategory { get; set; }
        public bool IsService { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufacturedComponent> ManufacturedComponents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuild> ProductBuilds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildDraft> ProductBuildDrafts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Router> Routers { get; set; }
        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemLocation> ItemLocations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemLotBin> ItemLotBins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemSerial> ItemSerials { get; set; }
        public virtual ItemStatu ItemStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Machine> Machines { get; set; }
        public virtual MfgConsumable MfgConsumable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockMovementDetail> StockMovementDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}