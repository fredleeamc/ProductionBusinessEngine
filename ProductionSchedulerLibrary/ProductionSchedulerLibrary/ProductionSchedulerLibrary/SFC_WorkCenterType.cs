using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_WorkCenterType
    {
        private long id;

        private String workCenterTypeName;

        public SFC_WorkCenterType(long id, string workCenterTypeName)
        {
            this.id = id;
            this.workCenterTypeName = workCenterTypeName;
        }

        public long Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

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
    }
}
