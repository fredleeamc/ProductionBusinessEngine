using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_Machine
    {
        private readonly long id;

        private SFC_MachineType machineType;

        private String machineName;

        private SFC_WorkCenter workCenter;

        public long Id
        {
            get
            {
                return id;
            }
        }

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

        public SFC_Machine(long id, SFC_MachineType machineTypeId, string machineName)
        {
            this.id = id;
            this.machineType = machineTypeId;
            this.machineName = machineName;
        }

        public override string ToString()
        {
            return id + " " + machineType + " " + machineName;

        }

    }
}
