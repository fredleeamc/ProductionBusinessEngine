using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public  class SFC_Vendor
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
        /// The vendor code
        /// </summary>
        private readonly String vendorCode;

        /// <summary>
        /// The account no
        /// </summary>
        private readonly String accountNo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_vendor"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="company">The company.</param>
        /// <param name="vendorCode">The vendor code.</param>
        /// <param name="accountNo">The account no.</param>
        public SFC_Vendor(long id, SFC_Company company, string vendorCode, string accountNo)
        {
            this.id = id;
            this.company = company;
            this.vendorCode = vendorCode;
            this.accountNo = accountNo;
        }

        public long Id => id;

        public SFC_Company Company => company;

        public string VendorCode => vendorCode;

        public string AccountNo => accountNo;
    }
}
