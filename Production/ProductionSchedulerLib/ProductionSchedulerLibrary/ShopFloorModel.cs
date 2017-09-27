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
    public class ShopFloorModel
    {
        #region fields
        /// <summary>
        /// The random
        /// </summary>
        static private Random rnd = new Random();

        /// <summary>
        /// The company identifier
        /// </summary>
        private long companyId;

        /// <summary>
        /// The company
        /// </summary>
        private SFC_Company company;

        /// <summary>
        /// The employees
        /// </summary>
        private Dictionary<long, SFC_Employee> employees;

        /// <summary>
        /// The customers
        /// </summary>
        private Dictionary<long, SFC_Customer> customers;

        /// <summary>
        /// The lot bin
        /// </summary>
        private Dictionary<long, SFC_ItemLotBin> lotBin;

        /// <summary>
        /// The items
        /// </summary>
        private Dictionary<long, SFC_Item> items;

        /// <summary>
        /// The machine types
        /// </summary>
        private Dictionary<long, SFC_MachineType> machineTypes;

        /// <summary>
        /// The machines
        /// </summary>
        private Dictionary<long, SFC_Machine> machines;

        /// <summary>
        /// The work center types
        /// </summary>
        private Dictionary<long, SFC_WorkCenterType> workCenterTypes;

        /// <summary>
        /// The work centers
        /// </summary>
        private Dictionary<long, SFC_WorkCenter> workCenters;

        /// <summary>
        /// The boms
        /// </summary>
        private SFC_Boms boms;
        #endregion

        #region property
        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>
        /// The employees.
        /// </value>
        public Dictionary<long, SFC_Employee> Employees
        {
            get
            {
                return employees;
            }

            protected set
            {
                employees = value;
            }
        }

        /// <summary>
        /// Gets or sets the lot bin list.
        /// </summary>
        /// <value>
        /// The lot bin list.
        /// </value>
        public Dictionary<long, SFC_ItemLotBin> LotBinList
        {
            get
            {
                return lotBin;
            }

            protected set
            {
                lotBin = value;
            }
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public Dictionary<long, SFC_Item> Items
        {
            get
            {
                return items;
            }

            protected set
            {
                items = value;
            }
        }

        /// <summary>
        /// Gets or sets the machine types.
        /// </summary>
        /// <value>
        /// The machine types.
        /// </value>
        public Dictionary<long, SFC_MachineType> MachineTypes
        {
            get
            {
                return machineTypes;
            }

            protected set
            {
                machineTypes = value;
            }
        }

        /// <summary>
        /// Gets or sets the machines.
        /// </summary>
        /// <value>
        /// The machines.
        /// </value>
        public Dictionary<long, SFC_Machine> Machines
        {
            get
            {
                return machines;
            }

            protected set
            {
                machines = value;
            }
        }

        /// <summary>
        /// Gets or sets the work center types.
        /// </summary>
        /// <value>
        /// The work center types.
        /// </value>
        public Dictionary<long, SFC_WorkCenterType> WorkCenterTypes
        {
            get
            {
                return workCenterTypes;
            }

            protected set
            {
                workCenterTypes = value;
            }
        }

        /// <summary>
        /// Gets or sets the work centers.
        /// </summary>
        /// <value>
        /// The work centers.
        /// </value>
        public Dictionary<long, SFC_WorkCenter> WorkCenters
        {
            get
            {
                return workCenters;
            }

            protected set
            {
                workCenters = value;
            }
        }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        public Dictionary<long, SFC_Customer> Customers
        {
            get => customers;
            protected set => customers = value;
        }
        public SFC_Boms Boms { get => boms; set => boms = value; }



        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopFloorModel"/> class.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="companyName">Name of the company.</param>
        public ShopFloorModel(long companyId, String companyName)
        {
            this.companyId = companyId;
            company = new SFC_Company(companyId, companyName);
            this.employees = new Dictionary<long, SFC_Employee>();
            this.customers = new Dictionary<long, SFC_Customer>();
            this.lotBin = new Dictionary<long, SFC_ItemLotBin>();
            this.items = new Dictionary<long, SFC_Item>();
            this.machineTypes = new Dictionary<long, SFC_MachineType>();
            this.machines = new Dictionary<long, SFC_Machine>();
            this.workCenterTypes = new Dictionary<long, SFC_WorkCenterType>();
            this.workCenters = new Dictionary<long, SFC_WorkCenter>();
            this.Boms = new SFC_Boms();
        }
        #endregion

        #region company
        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <returns></returns>
        public SFC_Company GetCompany()
        {
            return this.company;
        }
        #endregion

        #region customers
        /// <summary>
        /// Adds the customer.
        /// </summary>
        /// <param name="scheduledCustomer">The scheduled customer.</param>
        public void AddCustomer(SFC_Customer scheduledCustomer)
        {
            customers.Add(scheduledCustomer.Id, scheduledCustomer);
        }

        /// <summary>
        /// Removes the customer.
        /// </summary>
        /// <param name="removeCustomer">The remove customer.</param>
        public void RemoveCustomer(SFC_Customer removeCustomer)
        {
            customers.Remove(removeCustomer.Id);
        }

        /// <summary>
        /// Shows the customers.
        /// </summary>
        public void ShowCustomers()
        {
            foreach (long custId in customers.Keys)
            {
                Console.WriteLine(customers[custId]);
            }
        }

        /// <summary>
        /// Gets the random customer.
        /// </summary>
        /// <returns></returns>
        public SFC_Customer getRandomCustomer()
        {
            int rand = ShopFloorModel.rnd.Next(1, customers.Count + 1);
            return customers[rand];
        }
        #endregion

        #region employee
        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="scheduledEmployee">The scheduled employee.</param>
        public void AddEmployee(SFC_Employee scheduledEmployee)
        {
            employees.Add(scheduledEmployee.Id, scheduledEmployee);
        }

        /// <summary>
        /// Removes the employee.
        /// </summary>
        /// <param name="removeEmployee">The remove employee.</param>
        public void RemoveEmployee(SFC_Employee removeEmployee)
        {
            employees.Remove(removeEmployee.Id);
        }

        /// <summary>
        /// Shows the employees.
        /// </summary>
        public void ShowEmployees()
        {
            foreach (long empId in employees.Keys)
            {
                Console.WriteLine(employees[empId]);
            }
        }

        /// <summary>
        /// Gets the random employee.
        /// </summary>
        /// <returns></returns>
        public SFC_Employee getRandomEmployee()
        {
            int rand = ShopFloorModel.rnd.Next(1, employees.Count + 1);
            return employees[rand];
        }
        #endregion

        #region lotbin
        /// <summary>
        /// Adds the lot bin.
        /// </summary>
        /// <param name="itemLotBin">The item lot bin.</param>
        public void AddLotBin(SFC_ItemLotBin itemLotBin)
        {
            lotBin.Add(itemLotBin.Id, itemLotBin);
        }

        /// <summary>
        /// Removes the lot bin.
        /// </summary>
        /// <param name="itemLotBin">The item lot bin.</param>
        public void RemoveLotBin(SFC_ItemLotBin itemLotBin)
        {
            lotBin.Remove(itemLotBin.Id);
        }

        /// <summary>
        /// Shows the lotbin.
        /// </summary>
        public void ShowLotbin()
        {
            foreach (long lotId in lotBin.Keys)
            {
                Console.WriteLine(lotBin[lotId]);
                Console.WriteLine(lotBin[lotId].ItemStatus);
            }
        }
        /// <summary>
        /// Gets the random lot bin.
        /// </summary>
        /// <returns></returns>
        public SFC_ItemLotBin getRandomLotBin()
        {
            int rand = ShopFloorModel.rnd.Next(1, lotBin.Count + 1);
            return lotBin[rand];
        }
        #endregion

        #region items
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddItem(SFC_Item item)
        {
            items.Add(item.Id, item);
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void RemoveItem(SFC_Item item)
        {
            items.Remove(item.Id);
        }

        /// <summary>
        /// Shows the items.
        /// </summary>
        public void ShowItems()
        {
            foreach (long itemId in items.Keys)
            {
                Console.WriteLine(items[itemId]);
            }
        }

        /// <summary>
        /// Shows the item status.
        /// </summary>
        public void ShowItemStatus()
        {
            foreach (long itemId in items.Keys)
            {
                Console.WriteLine(items[itemId].PrintStatus());
            }
        }

        /// <summary>
        /// Gets the random item.
        /// </summary>
        /// <returns></returns>
        public SFC_Item getRandomItem()
        {
            int rand = ShopFloorModel.rnd.Next(1, items.Count + 1);
            return items[rand];
        }
        #endregion

        #region machine type
        /// <summary>
        /// Adds the type of the machine.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        public void AddMachineType(SFC_MachineType machineType)
        {
            machineTypes.Add(machineType.Id, machineType);
        }

        /// <summary>
        /// Removes the type of the machine.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        public void RemoveMachineType(SFC_MachineType machineType)
        {
            machineTypes.Remove(machineType.Id);
        }

        /// <summary>
        /// Shows the machine types.
        /// </summary>
        public void ShowMachineTypes()
        {
            foreach (long machineId in machineTypes.Keys)
            {
                Console.WriteLine(machineTypes[machineId]);
            }
        }

        /// <summary>
        /// Gets the random type of the machine.
        /// </summary>
        /// <returns></returns>
        public SFC_MachineType getRandomMachineType()
        {
            if (machineTypes.Count != 0)
            {
                int rand = ShopFloorModel.rnd.Next(1, machineTypes.Count + 1);
                return machineTypes[rand];
            }
            else
                return SFC_MachineType.NONE;
        }



        #endregion

        #region work center type
        /// <summary>
        /// Adds the type of the work center.
        /// </summary>
        /// <param name="workCenterType">Type of the work center.</param>
        public void AddWorkCenterType(SFC_WorkCenterType workCenterType)
        {
            workCenterTypes.Add(workCenterType.Id, workCenterType);
        }

        /// <summary>
        /// Removes the type of the work center.
        /// </summary>
        /// <param name="workCenterType">Type of the work center.</param>
        public void RemoveWorkCenterType(SFC_WorkCenterType workCenterType)
        {
            workCenterTypes.Remove(workCenterType.Id);
        }

        /// <summary>
        /// Shows the work center types.
        /// </summary>
        public void ShowWorkCenterTypes()
        {
            foreach (long workCenterId in workCenterTypes.Keys)
            {
                Console.WriteLine(items[workCenterId]);
            }
        }

        /// <summary>
        /// Gets the random type of the work center.
        /// </summary>
        /// <returns></returns>
        public SFC_WorkCenterType getRandomWorkCenterType()
        {
            if (workCenterTypes.Count != 0)
            {
                int rand = ShopFloorModel.rnd.Next(1, workCenterTypes.Count + 1);
                return workCenterTypes[rand];
            }
            else
                return SFC_WorkCenterType.NONE;
        }
        #endregion

        #region machines
        /// <summary>
        /// Adds the machine.
        /// </summary>
        /// <param name="machine">The machine.</param>
        public void AddMachine(SFC_Machine machine)
        {
            machines.Add(machine.Id, machine);
        }

        /// <summary>
        /// Removes the machine.
        /// </summary>
        /// <param name="machine">The machine.</param>
        public void RemoveMachine(SFC_Machine machine)
        {
            machines.Remove(machine.Id);
        }

        /// <summary>
        /// Shows the machines.
        /// </summary>
        public void ShowMachines()
        {
            foreach (long machineId in machines.Keys)
            {
                Console.WriteLine(machines[machineId]);
            }
        }

        /// <summary>
        /// Gets the random machine.
        /// </summary>
        /// <returns></returns>
        public SFC_Machine getRandomMachine()
        {
            if (machines.Count != 0)
            {
                int rand = ShopFloorModel.rnd.Next(1, machines.Count + 1);
                return machines[rand];
            }
            else
                return SFC_Machine.NONE;

        }
        #endregion

        #region work center
        /// <summary>
        /// Adds the work center.
        /// </summary>
        /// <param name="workCenter">The work center.</param>
        public void AddWorkCenter(SFC_WorkCenter workCenter)
        {
            workCenters.Add(workCenter.Id, workCenter);
        }

        /// <summary>
        /// Removes the work center.
        /// </summary>
        /// <param name="workCenter">The work center.</param>
        public void RemoveWorkCenter(SFC_WorkCenter workCenter)
        {
            workCenters.Remove(workCenter.Id);
        }

        /// <summary>
        /// Shows the work centers.
        /// </summary>
        public void ShowWorkCenters()
        {
            foreach (long workCenterId in workCenters.Keys)
            {
                Console.WriteLine(workCenters[workCenterId]);
            }
        }

        /// <summary>
        /// Gets the random work center.
        /// </summary>
        /// <returns></returns>
        public SFC_WorkCenter getRandomWorkCenter()
        {
            if (workCenters.Count != 0)
            {
                int rand = ShopFloorModel.rnd.Next(1, workCenters.Count + 1);
                return workCenters[rand];
            }
            else
                return SFC_WorkCenter.NONE;

        }
        #endregion

 

    }
}
