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
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.WorkOrders = new HashSet<WorkOrder>();
        }
    
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long CustomerCompanyId { get; set; }
        public long TermsId { get; set; }
        public long CurrencyId { get; set; }
        public Nullable<long> CustomerTypeId { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
        public string AccountNo { get; set; }
        public Nullable<long> SalesAccountId { get; set; }
        public Nullable<long> SalesDiscountAccountId { get; set; }
        public Nullable<long> ArAccountId { get; set; }
        public Nullable<long> PaymentDiscountAccountId { get; set; }
        public decimal BeginningBalance { get; set; }
        public decimal CurrentBalance { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string OurSupplierCode { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CustomerCode { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Company Company1 { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}