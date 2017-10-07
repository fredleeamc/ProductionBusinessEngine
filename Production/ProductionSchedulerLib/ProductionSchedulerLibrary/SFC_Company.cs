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
    public class SFC_Company
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The company name
        /// </summary>
        private String companyName;

        private SFC_Currency currency;


        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Company"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="companyName">Name of the company.</param>
        public SFC_Company(long id, string companyName)
        {
            this.id = id;
            this.companyName = companyName;
        }

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
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
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

        public SFC_Currency Currency { get => currency; set => currency = value; }

    }
}
