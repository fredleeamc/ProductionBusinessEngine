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
    public class SFC_WorkCenterType
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The work center type name
        /// </summary>
        private String workCenterTypeName;


        /// <summary>
        /// The none
        /// </summary>
        public readonly static SFC_WorkCenterType NONE = new SFC_WorkCenterType(0, "NONE");

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_WorkCenterType"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="workCenterTypeName">Name of the work center type.</param>
        public SFC_WorkCenterType(long id, string workCenterTypeName)
        {
            this.id = id;
            this.workCenterTypeName = workCenterTypeName;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets or sets the name of the work center type.
        /// </summary>
        /// <value>
        /// The name of the work center type.
        /// </value>
        public string WorkCenterTypeName
        {
            get
            {
                return workCenterTypeName;
            }

            set
            {
                workCenterTypeName = value;
            }
        }




        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return workCenterTypeName;
        }
    }
}
