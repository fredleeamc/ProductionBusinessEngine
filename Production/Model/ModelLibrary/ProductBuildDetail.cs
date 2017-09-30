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
    
    public partial class ProductBuildDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductBuildDetail()
        {
            this.ProductBuildMaterials = new HashSet<ProductBuildMaterial>();
        }
    
        public long Id { get; set; }
        public Nullable<long> ProductBuildId { get; set; }
        public Nullable<long> OperationSequence { get; set; }
        public Nullable<long> RouterProcessId { get; set; }
        public Nullable<long> ManufacturedComponentId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
    
        public virtual ManufacturedComponent ManufacturedComponent { get; set; }
        public virtual ProductBuild ProductBuild { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual RouterProcess RouterProcess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildMaterial> ProductBuildMaterials { get; set; }
    }
}