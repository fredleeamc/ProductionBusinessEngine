using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_ProductBuild
    {
        private readonly long id;

        private SFC_WorkOrder workOrder;

        private SFC_Employee employee;

        private long routerProcess;

        private SFC_Bom bomList;
    }
}
