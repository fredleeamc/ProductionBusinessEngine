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
    public  class SFC_EmployeeTask
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        public  SFC_EmployeeTask(long id)
        {
            this.id = id;
        }

        public  long Id => id;
    }
}
