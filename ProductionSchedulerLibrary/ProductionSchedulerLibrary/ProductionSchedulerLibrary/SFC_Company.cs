using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_Company
    {
        private long id;

        private String companyName;

        public SFC_Company(long id, string companyName)
        {
            this.id = id;
            this.companyName = companyName;
        }

        public long Id
        {
            get
            {
                return id;
            }

            protected set
            {
                id = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return companyName;
            }

            protected set
            {
                companyName = value;
            }
        }


    }
}
