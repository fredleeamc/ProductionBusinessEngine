using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_MachineType
    {
        private readonly int id;

        private String name;

        public SFC_MachineType(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            protected set
            {
                name = value;
            }
        }

        public override string ToString()
        {
            return name;
        }

    }
}
