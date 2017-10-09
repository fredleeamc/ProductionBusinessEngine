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
    public  class SFC_Customer
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The company
        /// </summary>
        private readonly SFC_Company company;

        /// <summary>
        /// The customer code
        /// </summary>
        private readonly String customerCode;

        /// <summary>
        /// The account no
        /// </summary>
        private readonly String accountNo;     

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Customer"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="company">The company.</param>
        /// <param name="customerCode">The customer code.</param>
        /// <param name="accountNo">The account no.</param>
        public  SFC_Customer(long id, SFC_Company company, string customerCode, string accountNo)
        {
            this.id = id;
            this.company = company;
            this.customerCode = customerCode;
            this.accountNo = accountNo;
        }

        public  long Id => id;

        public  SFC_Company Company => company;

        public  string CustomerCode => customerCode;

        public  string AccountNo => accountNo;
    }
}
