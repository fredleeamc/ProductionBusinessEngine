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
    public class SFC_Machine
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The machine type
        /// </summary>
        private SFC_MachineType machineType;

        /// <summary>
        /// The machine name
        /// </summary>
        private String machineName;

        /// <summary>
        /// The work center
        /// </summary>
        private SFC_WorkCenter workCenter;

        /// <summary>
        /// The none
        /// </summary>
        public readonly static SFC_Machine NONE = new SFC_Machine(0, "NONE", SFC_MachineType.NONE);

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
        /// Gets or sets the type of the machine.
        /// </summary>
        /// <value>
        /// The type of the machine.
        /// </value>
        public SFC_MachineType MachineType
        {
            get
            {
                return machineType;
            }

            protected set
            {
                machineType = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the machine.
        /// </summary>
        /// <value>
        /// The name of the machine.
        /// </value>
        public string MachineName
        {
            get
            {
                return machineName;
            }

            protected set
            {
                machineName = value;
            }
        }

        /// <summary>
        /// Gets or sets the work center.
        /// </summary>
        /// <value>
        /// The work center.
        /// </value>
        public SFC_WorkCenter WorkCenter
        {
            get
            {
                return workCenter;
            }

            protected set
            {
                workCenter = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Machine"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="machineName">Name of the machine.</param>
        /// <param name="machineTypeId">The machine type identifier.</param>
        public SFC_Machine(long id, string machineName, SFC_MachineType machineTypeId)
        {
            this.id = id;
            this.machineType = machineTypeId;
            this.machineName = machineName;
            this.workCenter = SFC_WorkCenter.NONE;
        }

        /// <summary>
        /// Sets the work center.
        /// </summary>
        /// <param name="wc">The wc.</param>
        /// <returns></returns>
        public bool setWorkCenter(SFC_WorkCenter wc)
        {
            bool result = false;            
            if (wc != null)
            {
                if (!wc.isCompatible(this))
                {
                    this.WorkCenter = SFC_WorkCenter.NONE;
                    result = false;
                } else
                {
                    this.WorkCenter = wc;
                    result = true;
                }
            } 
            return result;
        }



        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return id + " " + machineType + "." + machineName + "  [" + workCenter + "]";

        }

    }
}
