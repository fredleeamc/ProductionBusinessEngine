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
    
    public partial class BomMfgConsumable
    {
        public long Id { get; set; }
        public Nullable<long> BomId { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<long> MfgConsumableId { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<decimal> EstimatedTotalCost { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
    
        public virtual Bom Bom { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual MfgConsumable MfgConsumable { get; set; }
    }
}