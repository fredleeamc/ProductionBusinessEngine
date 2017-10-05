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
    
    public partial class ManufacturedSubComponent
    {
        public long Id { get; set; }
        public Nullable<long> ManufacturedComponentId { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<long> DocumentSetId { get; set; }
        public Nullable<decimal> EstimatedCost { get; set; }
        public Nullable<decimal> ActualCost { get; set; }
        public Nullable<long> DrawingAttachmentId { get; set; }
        public Nullable<long> UnitId { get; set; }
        public Nullable<long> RawMaterialItemBuyId { get; set; }
        public Nullable<long> ChildManufacturedComponentId { get; set; }
        public string Note { get; set; }
        public Nullable<long> DescriptionId { get; set; }
        public string ComponentNo { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
    
        public virtual ManufacturedComponent ManufacturedComponent { get; set; }
        public virtual ManufacturedComponent ManufacturedComponent1 { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
