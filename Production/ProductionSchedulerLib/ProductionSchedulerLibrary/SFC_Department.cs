using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductionSchedulerLibrary
{

    public class SFC_Department
    {
        private readonly long id;

        private readonly String departmentName;

        public SFC_Department(long id, string departmentName)
        {
            this.id = id;
            this.departmentName = departmentName;
        }

        public long Id => id;

        public string DepartmentName => departmentName;
    }
}
