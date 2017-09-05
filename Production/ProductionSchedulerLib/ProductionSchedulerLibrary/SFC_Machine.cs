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

        private long machineTypeId;

        private String machineName;

        public long Id
        {
            get
            {
                return id;
            }
        }

        public long MachineTypeId
        {
            get
            {
                return machineTypeId;
            }

            protected set
            {
                machineTypeId = value;
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

        public SFC_Machine(long id, long machineTypeId, string machineName)
        {
            this.id = id;
            this.machineTypeId = machineTypeId;
            this.machineName = machineName;
        }
    }
}
