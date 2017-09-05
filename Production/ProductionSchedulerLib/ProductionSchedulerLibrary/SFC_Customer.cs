using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_Customer
    {
        private readonly long id;

        private SFC_Company company;

        private String customerCode;

        private String accountNo;

        public long Id
        {
            get
            {
                return id;
            }
        }

        public SFC_Company Company
        {
            get
            {
                return company;
            }

            protected set
            {
                company = value;
            }
        }

        public string CustomerCode
        {
            get
            {
                return customerCode;
            }

            protected set
            {
                customerCode = value;
            }
        }

        public string AccountNo
        {
            get
            {
                return accountNo;
            }

            protected set
            {
                accountNo = value;
            }
        }

        public SFC_Customer(long id, SFC_Company company, string customerCode, string accountNo)
        {
            this.id = id;
            this.company = company;
            this.customerCode = customerCode;
            this.accountNo = accountNo;
        }
    }
}
