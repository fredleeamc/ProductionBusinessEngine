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
    
    public partial class AssemblyDetails
    {
        public long Id { get; set; }
        public long ItemSequence { get; set; }
        public decimal Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Assembly Assembly { get; set; }
    }
}