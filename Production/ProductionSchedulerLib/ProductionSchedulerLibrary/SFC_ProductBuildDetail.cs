using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_ProductBuildDetail
    {
        public long Id { get; set; }
        public long? ProductBuildId { get; set; }
        public long? OperationSequence { get; set; }
        public long? RouterProcessId { get; set; }
        public long? ManufacturedComponentId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedByEmployeeId { get; set; }
    }
}
