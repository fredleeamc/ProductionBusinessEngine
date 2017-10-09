using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public  class SFC_ProductBuildDetail
    {
        private long id;
        private long operationSequence;
        private long? routerProcessId;
        private long? manufacturedComponentId;

        public SFC_ProductBuildDetail(long id)
        {
            this.id = id;
        }

        public long Id { get => id; set => id = value; }
        public long OperationSequence { get => operationSequence; set => operationSequence = value; }
        public long? RouterProcessId { get => routerProcessId; set => routerProcessId = value; }
        public long? ManufacturedComponentId { get => manufacturedComponentId; set => manufacturedComponentId = value; }
    }
}
