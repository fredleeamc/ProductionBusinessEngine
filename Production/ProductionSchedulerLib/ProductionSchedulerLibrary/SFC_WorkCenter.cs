using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_WorkCenter
    {
        private readonly long id;

        private String workCenterName;

        private SFC_WorkCenterType workCenterType;

        private SFC_MachineType machineType;

        private List<SFC_Machine> wcMachines;

        public readonly static SFC_WorkCenter NONE = new SFC_WorkCenter(0, "NONE", SFC_WorkCenterType.NONE);

        public long Id
        {
            get
            {
                return id;
            }
        }

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

        public override string ToString()
        {
            return workCenterName + "[" + workCenterType + "]";
        }


        public SFC_WorkCenter(long id, string workCenterName, SFC_WorkCenterType workCenterType)
        {
            this.id = id;
            this.workCenterName = workCenterName;
            this.workCenterType = workCenterType;

            this.machineType = SFC_MachineType.NONE;
            this.wcMachines = new List<SFC_Machine>();
        }

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
