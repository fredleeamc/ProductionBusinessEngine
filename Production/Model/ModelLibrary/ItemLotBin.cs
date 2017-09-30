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
    
    public partial class ItemLotBin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemLotBin()
        {
            this.ItemLocations = new HashSet<ItemLocation>();
            this.StockMovementDetails = new HashSet<StockMovementDetail>();
        }
    
        public long Id { get; set; }
        public long ItemId { get; set; }
        public string LotNo { get; set; }
        public string BinNo { get; set; }
        public string HeatNo { get; set; }
        public string BatchNo { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public Nullable<decimal> Received { get; set; }
        public Nullable<decimal> Allocated { get; set; }
        public Nullable<decimal> InProduction { get; set; }
        public Nullable<decimal> Reserved { get; set; }
        public Nullable<decimal> TotalAvailable { get; set; }
        public Nullable<decimal> Scrap { get; set; }
        public Nullable<long> UnitId { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
        public bool IsVoid { get; set; }
        public string ApprovalCode { get; set; }
        public Nullable<long> ApprovedByUserId { get; set; }
        public bool IsPrinted { get; set; }
        public bool IsSent { get; set; }
        public bool IsForeignCurrency { get; set; }
        public Nullable<long> CurrencyId { get; set; }
        public Nullable<long> CurrencyExchangeId { get; set; }
        public long CompanyId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<decimal> AdjustmentIn { get; set; }
        public Nullable<decimal> AdjustmentOut { get; set; }
        public Nullable<decimal> OnHand { get; set; }
        public Nullable<decimal> BeginBalance { get; set; }
        public Nullable<decimal> BeginQuantity { get; set; }
        public Nullable<decimal> TotalRequired { get; set; }
        public Nullable<decimal> Returns { get; set; }
        public Nullable<decimal> NetUsed { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Item Item { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemLocation> ItemLocations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockMovementDetail> StockMovementDetails { get; set; }
    }
}
