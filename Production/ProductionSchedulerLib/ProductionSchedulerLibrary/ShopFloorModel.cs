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

        private Dictionary<long, SFC_ItemLotBin> lotBin;

        private Dictionary<long, SFC_Item> items;

        private Dictionary<long, SFC_MachineType> machineTypes;

        private Dictionary<long, SFC_Machine> machines;

        private Dictionary<long, SFC_WorkCenterType> workCenterTypes;

        private Dictionary<long, SFC_WorkCenter> workCenters;
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
        #endregion

        #region constructor
        public ShopFloorModel(long companyId, String companyName)
        {
            this.companyId = companyId;
            company = new SFC_Company(companyId, companyName);
            this.employees = new Dictionary<long, SFC_Employee>();
            this.lotBin = new Dictionary<long, SFC_ItemLotBin>();
            this.items = new Dictionary<long, SFC_Item>();
            this.machineTypes = new Dictionary<long, SFC_MachineType>();
            this.machines = new Dictionary<long, SFC_Machine>();
            this.workCenterTypes = new Dictionary<long, SFC_WorkCenterType>();
            this.workCenters = new Dictionary<long, SFC_WorkCenter>();
        }
        #endregion

        #region company
        public SFC_Company GetCompany()
        {
            return this.company;
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
            int rand = ShopFloorModel.rnd.Next(0, employees.Count);
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
            int rand = ShopFloorModel.rnd.Next(1, lotBin.Count+1);
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

        public SFC_Item getRandomItem()
        {
            int rand = ShopFloorModel.rnd.Next(1, items.Count+1);
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
                Console.WriteLine(items[machineId]);
            }
        }

        public SFC_MachineType getRandomMachineTypes()
        {
            int rand = ShopFloorModel.rnd.Next(1, machineTypes.Count + 1);
            return machineTypes[rand];
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
            int rand = ShopFloorModel.rnd.Next(1, machines.Count + 1);
            return machines[rand];
        }
        #endregion
    }
}
