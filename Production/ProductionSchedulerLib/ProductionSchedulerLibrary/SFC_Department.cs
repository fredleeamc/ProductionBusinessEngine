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
    public class SFC_Department
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The department name
        /// </summary>
        private readonly String departmentName;

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Department"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="departmentName">Name of the department.</param>
        public SFC_Department(long id, string departmentName)
        {
            this.id = id;
            this.departmentName = departmentName;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id => id;

        /// <summary>
        /// Gets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        public string DepartmentName => departmentName;
    }
}
