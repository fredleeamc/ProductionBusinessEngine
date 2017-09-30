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
    
    public partial class EngineeringChangeStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EngineeringChangeStatu()
        {
            this.Boms = new HashSet<Bom>();
            this.ManufacturedComponents = new HashSet<ManufacturedComponent>();
            this.Routers = new HashSet<Router>();
            this.RouterOutsideDetails = new HashSet<RouterOutsideDetail>();
            this.RouterProcesses = new HashSet<RouterProcess>();
            this.RouterProcessDetails = new HashSet<RouterProcessDetail>();
        }
    
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsUrgentPriority { get; set; }
        public bool IsProcessStopped { get; set; }
        public bool IsNeedAuthorization { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
        public bool IsVoid { get; set; }
        public string ApprovalCode { get; set; }
        public Nullable<long> ApprovedByUserId { get; set; }
        public bool IsPrinted { get; set; }
        public bool IsSent { get; set; }
        public long CompanyId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bom> Boms { get; set; }
        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufacturedComponent> ManufacturedComponents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Router> Routers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouterOutsideDetail> RouterOutsideDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouterProcess> RouterProcesses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouterProcessDetail> RouterProcessDetails { get; set; }
    }
}