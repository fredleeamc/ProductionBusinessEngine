using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class SFC_ProductBuild
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The work order
        /// </summary>
        private SFC_WorkOrder workOrder;

        /// <summary>
        /// The employee
        /// </summary>
        private SFC_Employee employee;

        /// <summary>
        /// The router process
        /// </summary>
        private long routerProcess;

        /// <summary>
        /// The bom list
        /// </summary>
        private SFC_Bom bomList;
    }
}
