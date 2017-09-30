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
    public class ShopFloorControl
    {
        #region field
        /// <summary>
        /// The shop control list
        /// </summary>
        protected static Dictionary<long, ShopFloorModel> shopControlList = null;

        /// <summary>
        /// The instance SFC
        /// </summary>
        private static ShopFloorControl instanceSFC = null;
        #endregion

        private static Object lockObject = new Object();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ShopFloorControl Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instanceSFC == null)
                    {
                        instanceSFC = new ShopFloorControl();
                        shopControlList = new Dictionary<long, ShopFloorModel>();
                    }
                }
                return instanceSFC;
            }

        }




        #region shop floor model
        /// <summary>
        /// Creates the shop floor model.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public ShopFloorModel CreateShopFloorModel(SFC_Company company)
        {
            return CreateShopFloorModel(company.Id, company.CompanyName);
        }

        /// <summary>
        /// Creates the shop floor model.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="companyName">Name of the company.</param>
        /// <returns></returns>
        public ShopFloorModel CreateShopFloorModel(long companyId, String companyName)
        {
            ShopFloorModel model = null;
            if (!shopControlList.ContainsKey(companyId))
            {
                model = new ShopFloorModel(companyId, companyName);
                shopControlList.Add(companyId, model);
            }
            else
            {
                model = shopControlList[companyId];
            }
            return model;
        }
        #endregion

        #region customer
        /// <summary>
        /// Adds the customer list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="customerList">The customer list.</param>
        public void AddCustomerList(long companyId, List<SFC_Customer> customerList)
        {
            foreach (SFC_Customer cust in customerList)
            {
                if (!shopControlList[companyId].Customers.Lists.ContainsKey(cust.Id))
                    shopControlList[companyId].AddCustomer(cust);
            }
        }

        /// <summary>
        /// Gets the random customer.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public SFC_Customer getRandomCustomer(long companyId)
        {
            return shopControlList[companyId].getRandomCustomer();
        }

        /// <summary>
        /// Shows the customers.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        public void ShowCustomers(long companyId)
        {
            shopControlList[companyId].ShowCustomers();
        }
        #endregion

        #region bom list
        /// <summary>
        /// Adds the bom list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="itemLotBinList">The item lot bin list.</param>
        public void AddBomList(long companyId, List<SFC_ItemLotBin> itemLotBinList)
        {
            foreach (SFC_ItemLotBin bin in itemLotBinList)
            {
                shopControlList[companyId].LotBins.Add(bin.Id, bin);
            }
        }
        #endregion

        #region employee
        /// <summary>
        /// Adds the employee list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeList">The employee list.</param>
        public void AddEmployeeList(long companyId, List<SFC_Employee> employeeList)
        {
            foreach (SFC_Employee emp in employeeList)
            {
                if (!shopControlList[companyId].Employees.Lists.ContainsKey(emp.Id))
                    shopControlList[companyId].Employees.Add(emp.Id, emp);
            }
        }

        /// <summary>
        /// Gets the random employee.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public SFC_Employee getRandomEmployee(long companyId)
        {
            return shopControlList[companyId].Employees.GetRandom();
        }

        /// <summary>
        /// Shows the employees.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        public void ShowEmployees(long companyId)
        {
            shopControlList[companyId].Employees.Print();
        }
        #endregion

        #region items
        /// <summary>
        /// Adds the item list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="itemList">The item list.</param>
        public void AddItemList(long companyId, List<SFC_Item> itemList)
        {
            foreach (SFC_Item item in itemList)
            {
                shopControlList[companyId].Items.Add(item.Id, item);
            }
        }

        /// <summary>
        /// Shows the items.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        public void ShowItems(long companyId)
        {
            shopControlList[companyId].ShowItems();
        }

        /// <summary>
        /// Shows the item status.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        public void ShowItemStatus(long companyId)
        {
            shopControlList[companyId].ShowItemStatus();
        }

        /// <summary>
        /// Gets the random item.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public SFC_Item getRandomItem(long companyId)
        {
            return shopControlList[companyId].getRandomItem();
        }
        #endregion

        #region lot bin
        /// <summary>
        /// Shows the lot bin.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        public void ShowLotBin(long companyId)
        {
            shopControlList[companyId].ShowLotbin();
        }

        /// <summary>
        /// Gets the random item lot bin.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public SFC_ItemLotBin getRandomItemLotBin(long companyId)
        {
            return shopControlList[companyId].getRandomLotBin();
        }
        #endregion

        #region machine type

        /// <summary>
        /// Adds the type of the machine.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="machineTypeList">The machine type list.</param>
        public void AddMachineType(long companyId, List<SFC_MachineType> machineTypeList)
        {
            foreach (SFC_MachineType machineType in machineTypeList)
            {
                shopControlList[companyId].MachineTypes.Add(machineType.Id, machineType);
            }
        }
        /// <summary>
        /// Shows the machine types.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        public void ShowMachineTypes(long companyId)
        {
            shopControlList[companyId].ShowMachineTypes();
        }

        /// <summary>
        /// Gets the random type of the machine.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public SFC_MachineType getRandomMachineType(long companyId)
        {
            return shopControlList[companyId].getRandomMachineType();
        }
        #endregion

        #region machine
        /// <summary>
        /// Adds the machines.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="machineList">The machine list.</param>
        public void AddMachines(long companyId, List<SFC_Machine> machineList)
        {
            foreach (SFC_Machine machine in machineList)
            {
                shopControlList[companyId].Machines.Add(machine.Id, machine);
            }
        }

        /// <summary>
        /// Gets the random machine.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public SFC_Machine getRandomMachine(long companyId)
        {
            return shopControlList[companyId].getRandomMachine();
        }

        /// <summary>
        /// Shows the machines.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        public void ShowMachines(long companyId)
        {
            shopControlList[companyId].ShowMachines();
        }
        #endregion

        #region work center type
        /// <summary>
        /// Adds the work center types.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="list">The list.</param>
        public void AddWorkCenterTypes(long companyId, List<SFC_WorkCenterType> list)
        {
            foreach (SFC_WorkCenterType t in list)
            {
                shopControlList[companyId].WorkCenterTypes.Add(t.Id, t);
            }
        }

        /// <summary>
        /// Gets the random type of the work center.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public SFC_WorkCenterType getRandomWorkCenterType(long companyId)
        {
            return shopControlList[companyId].getRandomWorkCenterType();
        }

        /// <summary>
        /// Shows the work center types.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        public void ShowWorkCenterTypes(long companyId)
        {
            shopControlList[companyId].ShowWorkCenterTypes();
        }
        #endregion

        #region work center
        /// <summary>
        /// Adds the work centers.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="workCenterList">The work center list.</param>
        public void AddWorkCenters(long companyId, List<SFC_WorkCenter> workCenterList)
        {
            foreach (SFC_WorkCenter workCenter in workCenterList)
            {
                shopControlList[companyId].WorkCenters.Add(workCenter.Id, workCenter);
            }
        }

        /// <summary>
        /// Gets the random work center.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public SFC_WorkCenter getRandomWorkCenter(long companyId)
        {
            return shopControlList[companyId].getRandomWorkCenter();
        }

        /// <summary>
        /// Shows the work centers.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        public void ShowWorkCenters(long companyId)
        {
            shopControlList[companyId].ShowWorkCenters();
        }
        #endregion


        #region bill of materials
        /// <summary>
        /// Nexts the bom count.
        /// </summary>
        /// <returns></returns>
        public static long NextBomCount(long companyId)
        {
            return shopControlList[companyId].Boms.Count;
        }

        /// <summary>
        /// Adds the bom list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="bomList">The bom list.</param>
        public void AddBomList(long companyId, List<SFC_Bom> bomList)
        {
            foreach (SFC_Bom bom in bomList)
            {
                if (!shopControlList[companyId].Boms.Lists.ContainsKey(bom.Id))
                    shopControlList[companyId].Boms.Add(bom.Id, bom);
            }
        }

        /// <summary>
        /// Shows the boms.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        public void ShowBoms(long companyId)
        {
            shopControlList[companyId].Boms.Print();
        }

        /// <summary>
        /// Gets the random bom.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        public SFC_Bom getRandomBom(long companyId)
        {
            return shopControlList[companyId].Boms.GetRandom();
        }


        #endregion
    }
}
