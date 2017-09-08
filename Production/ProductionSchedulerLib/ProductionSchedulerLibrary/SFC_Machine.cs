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

        public readonly static SFC_Machine NONE = new SFC_Machine(0, "NONE", SFC_MachineType.NONE);

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

        public SFC_Machine(long id, string machineName, SFC_MachineType machineTypeId)
        {
            this.id = id;
            this.machineType = machineTypeId;
            this.machineName = machineName;
            this.workCenter = SFC_WorkCenter.NONE;
        }

        public bool setWorkCenter(SFC_WorkCenter wc)
        {
            bool result = true;
            this.WorkCenter = wc;
            if (wc != null)
                if (!wc.isCompatible(this))
                {
                    this.workCenter = SFC_WorkCenter.NONE;
                    result = false;
                }
            return result;
        }

        public override string ToString()
        {
            return id + " " + machineType + "." + machineName + "  [" + workCenter + "]";

        }

    }
}
