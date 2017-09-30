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
    
    public partial class RouterOutsideDetail
    {
        public long Id { get; set; }
        public Nullable<long> RouterId { get; set; }
        public string EngineeringChangeStatusId { get; set; }
        public Nullable<long> OperationSequence { get; set; }
        public string OperationDescription { get; set; }
        public Nullable<double> PercentOverlap { get; set; }
        public Nullable<long> WorkInstructionId { get; set; }
        public Nullable<decimal> EstimatedProcessCost { get; set; }
        public long VendorId { get; set; }
        public Nullable<long> AddressId { get; set; }
        public Nullable<int> LeadTimeDays { get; set; }
        public Nullable<decimal> EstimatedTaxes { get; set; }
        public Nullable<decimal> EstimatedDuties { get; set; }
        public Nullable<decimal> EstimatedShippingCost { get; set; }
        public Nullable<decimal> EstimatedLandedCost { get; set; }
        public Nullable<decimal> EstimatedAdditionalOverhead { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
    
        public virtual EngineeringChangeStatu EngineeringChangeStatu { get; set; }
        public virtual Router Router { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
