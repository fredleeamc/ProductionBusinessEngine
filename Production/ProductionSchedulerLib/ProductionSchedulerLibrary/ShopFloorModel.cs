using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductionSchedulerLibrary
{

    public class ShopFloorModel
    {
        #region fields
        static private Random rnd = new Random();

        private long companyId;

        private SFC_Company company;

        private Dictionary<long, SFC_Employee> employees;

        private Dictionary<long, SFC_Customer> customers;

        private Dictionary<long, SFC_ItemLotBin> lotBin;

        private Dictionary<long, SFC_Item> items;

        private Dictionary<long, SFC_MachineType> machineTypes;

        private Dictionary<long, SFC_Machine> machines;

        private Dictionary<long, SFC_WorkCenterType> workCenterTypes;

        private Dictionary<long, SFC_WorkCenter> workCenters;

        private Dictionary<long, SFC_Bom> boms;
        #endregion

        #region property
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

        public Dictionary<long, SFC_Customer> Customers
        {
            get => customers;
            protected set => customers = value;
        }

        public Dictionary<long, SFC_Bom> Boms
        {
            get => boms;
            protected set => boms = value;
        }

        #endregion

        #region constructor
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
            this.boms = new Dictionary<long, SFC_Bom>();
        }
        #endregion

        #region company
        public SFC_Company GetCompany()
        {
            return this.company;
        }
        #endregion

        #region customers
        public void AddCustomer(SFC_Customer scheduledCustomer)
        {
            customers.Add(scheduledCustomer.Id, scheduledCustomer);
        }

        public void RemoveCustomer(SFC_Customer removeCustomer)
        {
            customers.Remove(removeCustomer.Id);
        }

        public void ShowCustomers()
        {
            foreach (long custId in customers.Keys)
            {
                Console.WriteLine(customers[custId]);
            }
        }

        public SFC_Customer getRandomCustomer()
        {
            int rand = ShopFloorModel.rnd.Next(1, customers.Count + 1);
            return customers[rand];
        }
        #endregion

        #region employee
        public void AddEmployee(SFC_Employee scheduledEmployee)
        {
            employees.Add(scheduledEmployee.Id, scheduledEmployee);
        }

        public void RemoveEmployee(SFC_Employee removeEmployee)
        {
            employees.Remove(removeEmployee.Id);
        }

        public void ShowEmployees()
        {
            foreach (long empId in employees.Keys)
            {
                Console.WriteLine(employees[empId]);
            }
        }

        public SFC_Employee getRandomEmployee()
        {
            int rand = ShopFloorModel.rnd.Next(1, employees.Count + 1);
            return employees[rand];
        }
        #endregion

        #region lotbin
        public void AddLotBin(SFC_ItemLotBin itemLotBin)
        {
            lotBin.Add(itemLotBin.Id, itemLotBin);
        }

        public void RemoveLotBin(SFC_ItemLotBin itemLotBin)
        {
            lotBin.Remove(itemLotBin.Id);
        }

        public void ShowLotbin()
        {
            foreach (long lotId in lotBin.Keys)
            {
                Console.WriteLine(lotBin[lotId]);
                Console.WriteLine(lotBin[lotId].ItemStatus);
            }
        }
        public SFC_ItemLotBin getRandomLotBin()
        {
            int rand = ShopFloorModel.rnd.Next(1, lotBin.Count + 1);
            return lotBin[rand];
        }
        #endregion

        #region items
        public void AddItem(SFC_Item item)
        {
            items.Add(item.Id, item);
        }

        public void RemoveItem(SFC_Item item)
        {
            items.Remove(item.Id);
        }

        public void ShowItems()
        {
            foreach (long itemId in items.Keys)
            {
                Console.WriteLine(items[itemId]);
            }
        }

        public void ShowItemStatus()
        {
            foreach (long itemId in items.Keys)
            {
                Console.WriteLine(items[itemId].PrintStatus());
            }
        }

        public SFC_Item getRandomItem()
        {
            int rand = ShopFloorModel.rnd.Next(1, items.Count + 1);
            return items[rand];
        }
        #endregion

        #region machine type
        public void AddMachineType(SFC_MachineType machineType)
        {
            machineTypes.Add(machineType.Id, machineType);
        }

        public void RemoveMachineType(SFC_MachineType machineType)
        {
            machineTypes.Remove(machineType.Id);
        }

        public void ShowMachineTypes()
        {
            foreach (long machineId in machineTypes.Keys)
            {
                Console.WriteLine(machineTypes[machineId]);
            }
        }

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
        public void AddWorkCenterType(SFC_WorkCenterType workCenterType)
        {
            workCenterTypes.Add(workCenterType.Id, workCenterType);
        }

        public void RemoveWorkCenterType(SFC_WorkCenterType workCenterType)
        {
            workCenterTypes.Remove(workCenterType.Id);
        }

        public void ShowWorkCenterTypes()
        {
            foreach (long workCenterId in workCenterTypes.Keys)
            {
                Console.WriteLine(items[workCenterId]);
            }
        }

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
        public void AddMachine(SFC_Machine machine)
        {
            machines.Add(machine.Id, machine);
        }

        public void RemoveMachine(SFC_Machine machine)
        {
            machines.Remove(machine.Id);
        }

        public void ShowMachines()
        {
            foreach (long machineId in machines.Keys)
            {
                Console.WriteLine(machines[machineId]);
            }
        }

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
        public void AddWorkCenter(SFC_WorkCenter workCenter)
        {
            workCenters.Add(workCenter.Id, workCenter);
        }

        public void RemoveWorkCenter(SFC_WorkCenter workCenter)
        {
            workCenters.Remove(workCenter.Id);
        }

        public void ShowWorkCenters()
        {
            foreach (long workCenterId in workCenters.Keys)
            {
                Console.WriteLine(workCenters[workCenterId]);
            }
        }

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

        public void AddBom(SFC_Bom bom)
        {
            boms.Add(bom.Id, bom);
        }

        public void RemoveBom(SFC_Bom bom)
        {
            boms.Remove(bom.Id);
        }

        public void ShowBoms()
        {
            foreach (long bomId in boms.Keys)
            {
                Console.WriteLine(boms[bomId]);
            }
        }

        public SFC_Bom getRandomBom()
        {
            int rand = ShopFloorModel.rnd.Next(1, boms.Count + 1);
            return boms[rand];
        }

    }
}
