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
    
    public partial class MachineTool
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string ToolName { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public string PictureUrl { get; set; }
        public Nullable<long> AssetId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> SpecificationId { get; set; }
    
        public virtual Currency Currency { get; set; }
        public virtual Company Company { get; set; }
        public virtual Company Company1 { get; set; }
        public virtual CurrencyExchange CurrencyExchange { get; set; }
        public virtual Item Item { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual MachineToolType MachineToolType { get; set; }
    }
}
