﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductionSchedulerLibrary
{

    public class SFC_Employee
    {
        private readonly long id;

        private String employeeNo;

        private String lastName;

        private String middleName;

        private String firstName;

        public SFC_Employee(long id, string employeeNo, string lastName, string middleName, string firstName)
        {
            this.id = id;
            this.EmployeeNo = employeeNo;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.FirstName = firstName;
        }

        public long Id
        {
            get
            {
                return id;
            }
        }

        public string EmployeeNo
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

        public string LastName
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

        public string MiddleName
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

        public string FirstName
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



        public override string ToString()
        {
            return "Employee:" + id + "," + employeeNo + "," + lastName + "," + firstName + " " + middleName;
        }
    }
}
