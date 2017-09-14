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
    public class SFC_WorkCenter
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The work center name
        /// </summary>
        private String workCenterName;

        /// <summary>
        /// The work center type
        /// </summary>
        private SFC_WorkCenterType workCenterType;

        /// <summary>
        /// The machine type
        /// </summary>
        private SFC_MachineType machineType;

        /// <summary>
        /// The wc machines
        /// </summary>
        private List<SFC_Machine> wcMachines;

        /// <summary>
        /// The none
        /// </summary>
        public readonly static SFC_WorkCenter NONE = new SFC_WorkCenter(0, "NONE", SFC_WorkCenterType.NONE);

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
        /// Gets or sets the name of the work center.
        /// </summary>
        /// <value>
        /// The name of the work center.
        /// </value>
        public string WorkCenterName
        {
            get
            {
                return workCenterName;
            }

            protected set
            {
                workCenterName = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the work center.
        /// </summary>
        /// <value>
        /// The type of the work center.
        /// </value>
        public SFC_WorkCenterType WorkCenterType
        {
            get
            {
                return workCenterType;
            }

            protected set
            {
                workCenterType = value;
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
            set
            {
                if (machineType != null)
                {
                    SFC_MachineType.RemoveWorkCenter(this);
                }                
                machineType = value;
                SFC_MachineType.AddWorkCenter(machineType, this);
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
            return workCenterName + "[" + workCenterType + "]";
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_WorkCenter"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="workCenterName">Name of the work center.</param>
        /// <param name="workCenterType">Type of the work center.</param>
        public SFC_WorkCenter(long id, string workCenterName, SFC_WorkCenterType workCenterType)
        {
            this.id = id;
            this.workCenterName = workCenterName;
            this.workCenterType = workCenterType;

            this.machineType = SFC_MachineType.NONE;
            this.wcMachines = new List<SFC_Machine>();
        }

        /// <summary>
        /// Determines whether the specified machine is compatible.
        /// </summary>
        /// <param name="machine">The machine.</param>
        /// <returns>
        ///   <c>true</c> if the specified machine is compatible; otherwise, <c>false</c>.
        /// </returns>
        public bool isCompatible(SFC_Machine machine)
        {

            bool result = false;
            if (machine != null)
                if (machineType.Equals(SFC_MachineType.NONE))
                {
                    machineType = machine.MachineType;
                    result = true;
                }
                else if (machineType == machine.MachineType)
                {
                    result = true;
                }
            return result;
        }

        /// <summary>
        /// Adds the machine.
        /// </summary>
        /// <param name="machine">The machine.</param>
        /// <returns></returns>
        public bool AddMachine(SFC_Machine machine)
        {
            bool result = false;
            if (isCompatible(machine))
            {
                wcMachines.Add(machine);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Removes the machine.
        /// </summary>
        /// <param name="machine">The machine.</param>
        /// <returns></returns>
        public bool RemoveMachine(SFC_Machine machine)
        {
            bool result = false;
            if (wcMachines.Contains(machine))
            {
                result = wcMachines.Remove(machine);
            }
            return result;
        }
    }
}
