using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_RouterDetail
    {
        public long Id { get; set; }
        public Nullable<long> RouterId { get; set; }
        public Nullable<long> OperationSequence { get; set; }
        public Nullable<float> PercentOverlap { get; set; }
        public Nullable<long> RouterProcessId { get; set; }
        public Nullable<long> ChildRouterId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
        public string ProcessName { get; set; }
    }
}
