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
    public class SFC_Customer
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The company
        /// </summary>
        private long company;

        /// <summary>
        /// The customer code
        /// </summary>
        private String customerCode;

        /// <summary>
        /// The account no
        /// </summary>
        private String accountNo;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public long Company
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

        /// <summary>
        /// Gets or sets the customer code.
        /// </summary>
        /// <value>
        /// The customer code.
        /// </value>
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

        /// <summary>
        /// Gets or sets the account no.
        /// </summary>
        /// <value>
        /// The account no.
        /// </value>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Customer"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="company">The company.</param>
        /// <param name="customerCode">The customer code.</param>
        /// <param name="accountNo">The account no.</param>
        public SFC_Customer(long id, long company, string customerCode, string accountNo)
        {
            this.id = id;
            this.company = company;
            this.customerCode = customerCode;
            this.accountNo = accountNo;
        }
    }
}
