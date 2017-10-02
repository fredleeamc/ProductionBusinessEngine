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
    
    public partial class RouterDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RouterDetail()
        {
            this.WorkOrderDetails = new HashSet<WorkOrderDetail>();
            this.RouterDetailsLinks = new HashSet<RouterDetailsLink>();
            this.RouterDetailsLinks1 = new HashSet<RouterDetailsLink>();
        }
    
        public long Id { get; set; }
        public Nullable<long> RouterId { get; set; }
        public Nullable<long> OperationSequence { get; set; }
        public Nullable<double> PercentOverlap { get; set; }
        public Nullable<long> RouterProcessId { get; set; }
        public Nullable<long> ChildRouterId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
        public string ProcessName { get; set; }
    
        public virtual Router Router { get; set; }
        public virtual Router Router1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrderDetail> WorkOrderDetails { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual RouterProcess RouterProcess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouterDetailsLink> RouterDetailsLinks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouterDetailsLink> RouterDetailsLinks1 { get; set; }
    }
}
