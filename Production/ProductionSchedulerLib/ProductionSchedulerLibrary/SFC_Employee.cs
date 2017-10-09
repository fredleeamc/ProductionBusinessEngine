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
    public  class SFC_Employee
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The employee no
        /// </summary>
        private String employeeNo;

        /// <summary>
        /// The last name
        /// </summary>
        private String lastName;

        /// <summary>
        /// The middle name
        /// </summary>
        private String middleName;

        /// <summary>
        /// The first name
        /// </summary>
        private String firstName;

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Employee"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="employeeNo">The employee no.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="middleName">Name of the middle.</param>
        /// <param name="firstName">The first name.</param>
        public  SFC_Employee(long id, string employeeNo, string lastName, string middleName, string firstName)
        {
            this.id = id;
            this.EmployeeNo = employeeNo;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.FirstName = firstName;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public  long Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets or sets the employee no.
        /// </summary>
        /// <value>
        /// The employee no.
        /// </value>
        public  string EmployeeNo
        {
            get
            {
                return employeeNo;
            }

            protected set
            {
                employeeNo = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public  string LastName
        {
            get
            {
                return lastName;
            }

            protected set
            {
                lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        public  string MiddleName
        {
            get
            {
                return middleName;
            }

            protected set
            {
                middleName = value;
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public  string FirstName
        {
            get
            {
                return firstName;
            }

            protected set
            {
                firstName = value;
            }
        }



        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public  override string ToString()
        {
            return "Employee:" + id + "," + employeeNo + "," + lastName + "," + firstName + " " + middleName;
        }
    }
}
