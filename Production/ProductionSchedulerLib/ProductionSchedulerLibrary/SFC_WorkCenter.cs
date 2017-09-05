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

        public SFC_WorkCenter(long id, string workCenterName, SFC_WorkCenterType workCenterType)
        {
            this.id = id;
            this.workCenterName = workCenterName;
            this.workCenterType = workCenterType;
        }

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
    }
}
