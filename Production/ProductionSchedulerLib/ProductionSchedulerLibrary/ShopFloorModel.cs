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
        /// The boms
        /// </summary>
        private readonly SFC_Boms boms;


        /// <summary>
        /// The employees
        /// </summary>
        private readonly SFC_Employees employees;

        /// <summary>
        /// The customers
        /// </summary>
        private readonly SFC_Customers customers;

        /// <summary>
        /// The lot bin
        /// </summary>
        private readonly SFC_ItemLotBins lotBins;

        /// <summary>
        /// The items
        /// </summary>
        private readonly SFC_Items items;

        /// <summary>
        /// The machine types
        /// </summary>
        private readonly SFC_MachineTypes machineTypes;

        /// <summary>
        /// The machines
        /// </summary>
        private readonly SFC_Machines machines;

        /// <summary>
        /// The work center types
        /// </summary>
        private readonly SFC_WorkCenterTypes workCenterTypes;

        /// <summary>
        /// The work centers
        /// </summary>
        private readonly SFC_WorkCenters workCenters;
        #endregion


        public SFC_Boms Boms => boms;

        public SFC_Employees Employees => employees;

        public SFC_Customers Customers => customers;

        public SFC_ItemLotBins LotBins => lotBins;

        public SFC_Items Items => items;

        public SFC_MachineTypes  MachineTypes => machineTypes;

        public SFC_Machines Machines => machines;     

        public SFC_WorkCenters WorkCenters => workCenters;

        public SFC_WorkCenterTypes WorkCenterTypes => workCenterTypes;

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
            this.employees = new SFC_Employees();
            this.customers = new SFC_Customers();
            this.lotBins = new SFC_ItemLotBins();
            this.items = new SFC_Items();
            this.machineTypes = new SFC_MachineTypes();
            this.machines = new SFC_Machines();
            this.workCenterTypes = new SFC_WorkCenterTypes();
            this.workCenters = new SFC_WorkCenters();
            this.boms = new SFC_Boms();
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
            customers.Print();
        }

        /// <summary>
        /// Gets the random customer.
        /// </summary>
        /// <returns></returns>
        public SFC_Customer getRandomCustomer()
        {
            return customers.GetRandom();
        }
        #endregion

        

        #region lotbin
        /// <summary>
        /// Adds the lot bin.
        /// </summary>
        /// <param name="itemLotBin">The item lot bin.</param>
        public void AddLotBin(SFC_ItemLotBin itemLotBin)
        {
            lotBins.Add(itemLotBin.Id, itemLotBin);
        }

        /// <summary>
        /// Removes the lot bin.
        /// </summary>
        /// <param name="itemLotBin">The item lot bin.</param>
        public void RemoveLotBin(SFC_ItemLotBin itemLotBin)
        {
            lotBins.Remove(itemLotBin.Id);
        }

        /// <summary>
        /// Shows the lotbin.
        /// </summary>
        public void ShowLotbin()
        {
            lotBins.Print();
        }
        /// <summary>
        /// Gets the random lot bin.
        /// </summary>
        /// <returns></returns>
        public SFC_ItemLotBin getRandomLotBin()
        {
            return lotBins.GetRandom();
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
            items.Print();
        }

        /// <summary>
        /// Shows the item status.
        /// </summary>
        public void ShowItemStatus()
        {
            items.PrintItemsStatus();
        }

        /// <summary>
        /// Gets the random item.
        /// </summary>
        /// <returns></returns>
        public SFC_Item getRandomItem()
        {
            return items.GetRandom();
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
            machineTypes.Print();
        }

        /// <summary>
        /// Gets the random type of the machine.
        /// </summary>
        /// <returns></returns>
        public SFC_MachineType getRandomMachineType()
        {  
            return machineTypes.GetRandom();
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
            workCenterTypes.Print();
        }

        /// <summary>
        /// Gets the random type of the work center.
        /// </summary>
        /// <returns></returns>
        public SFC_WorkCenterType getRandomWorkCenterType()
        {
            return workCenterTypes.GetRandom();
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
            machines.Print();
        }

        /// <summary>
        /// Gets the random machine.
        /// </summary>
        /// <returns></returns>
        public SFC_Machine getRandomMachine()
        {
            return machines.GetRandom();
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
            workCenters.Print();
        }

        /// <summary>
        /// Gets the random work center.
        /// </summary>
        /// <returns></returns>
        public SFC_WorkCenter getRandomWorkCenter()
        {
            return workCenters.GetRandom();
        }
        #endregion

 

    }
}
