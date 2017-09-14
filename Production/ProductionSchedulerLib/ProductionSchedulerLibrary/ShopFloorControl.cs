using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class ShopFloorControl
    {
        #region field
        protected static Dictionary<long, ShopFloorModel> shopControlList = null;

        private static ShopFloorControl instanceSFC = null;

        private static long binCount = 1;

        private static long itemCount = 1;

        private static long machineCount = 1;

        private static long workCenterCont = 1;

        private static long bomCount = 1;


        #endregion

        public static ShopFloorControl GetInstance()
        {
            if (instanceSFC == null)
            {
                instanceSFC = new ShopFloorControl();
                shopControlList = new Dictionary<long, ShopFloorModel>();
            }
            return instanceSFC;

        }




        #region shop floor model
        public ShopFloorModel CreateShopFloorModel(SFC_Company company)
        {
            return CreateShopFloorModel(company.Id, company.CompanyName);
        }

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
        public void AddCustomerList(long companyId, List<SFC_Customer> customerList)
        {
            foreach (SFC_Customer cust in customerList)
            {
                if (!shopControlList[companyId].Customers.ContainsKey(cust.Id))
                    shopControlList[companyId].AddCustomer(cust);
            }
        }

        public SFC_Customer getRandomCustomer(long companyId)
        {
            return shopControlList[companyId].getRandomCustomer();
        }

        public void ShowCustomers(long companyId)
        {
            shopControlList[companyId].ShowCustomers();
        }
        #endregion

        #region bom list
        public void AddBomList(long companyId, List<SFC_ItemLotBin> itemLotBinList)
        {
            foreach (SFC_ItemLotBin bin in itemLotBinList)
            {
                if (!shopControlList[companyId].LotBinList.ContainsKey(bin.Id))
                    shopControlList[companyId].AddLotBin(bin);
            }
        }
        #endregion

        #region employee
        public void AddEmployeeList(long companyId, List<SFC_Employee> employeeList)
        {
            foreach (SFC_Employee emp in employeeList)
            {
                if (!shopControlList[companyId].Employees.ContainsKey(emp.Id))
                    shopControlList[companyId].AddEmployee(emp);
            }
        }

        public SFC_Employee getRandomEmployee(long companyId)
        {
            return shopControlList[companyId].getRandomEmployee();
        }

        public void ShowEmployees(long companyId)
        {
            shopControlList[companyId].ShowEmployees();
        }
        #endregion

        #region item
        public static long NextItemCount()
        {
            return itemCount++;
        }

        public void AddItemList(long companyId, List<SFC_Item> itemList)
        {
            foreach (SFC_Item item in itemList)
            {
                if (!shopControlList[companyId].Items.ContainsKey(item.Id))
                    shopControlList[companyId].AddItem(item);
            }
        }

        public void ShowItems(long companyId)
        {
            shopControlList[companyId].ShowItems();
        }

        public void ShowItemStatus(long companyId)
        {
            shopControlList[companyId].ShowItemStatus();
        }

        public SFC_Item getRandomItem(long companyId)
        {
            return shopControlList[companyId].getRandomItem();
        }
        #endregion

        #region lot bin
        public static long NextBinCount()
        {
            return binCount++;
        }

        public void ShowLotBin(long companyId)
        {
            shopControlList[companyId].ShowLotbin();
        }

        public SFC_ItemLotBin getRandomItemLotBin(long companyId)
        {
            return shopControlList[companyId].getRandomLotBin();
        }
        #endregion

        #region machine type

        public void AddMachineType(long companyId, List<SFC_MachineType> machineTypeList)
        {
            foreach (SFC_MachineType machineType in machineTypeList)
            {
                if (!shopControlList[companyId].MachineTypes.ContainsKey(machineType.Id))
                    shopControlList[companyId].AddMachineType(machineType);
            }
        }
        public void ShowMachineTypes(long companyId)
        {
            shopControlList[companyId].ShowMachineTypes();
        }

        public SFC_MachineType getRandomMachineType(long companyId)
        {
            return shopControlList[companyId].getRandomMachineType();
        }
        #endregion

        #region machine
        public void AddMachines(long companyId, List<SFC_Machine> machineList)
        {
            foreach (SFC_Machine machineType in machineList)
            {
                if (!shopControlList[companyId].Machines.ContainsKey(machineType.Id))
                    shopControlList[companyId].AddMachine(machineType);
            }
        }

        public SFC_Machine getRandomMachine(long companyId)
        {
            return shopControlList[companyId].getRandomMachine();
        }

        public void ShowMachines(long companyId)
        {
            shopControlList[companyId].ShowMachines();
        }
        #endregion

        #region work center type
        public void AddWorkCenterTypes(long companyId, List<SFC_WorkCenterType> list)
        {
            foreach (SFC_WorkCenterType t in list)
            {
                if (!shopControlList[companyId].WorkCenterTypes.ContainsKey(t.Id))
                    shopControlList[companyId].AddWorkCenterType(t);
            }
        }

        public SFC_WorkCenterType getRandomWorkCenterType(long companyId)
        {
            return shopControlList[companyId].getRandomWorkCenterType();
        }

        public void ShowWorkCenterTypes(long companyId)
        {
            shopControlList[companyId].ShowWorkCenterTypes();
        }
        #endregion

        #region work center
        public void AddWorkCenters(long companyId, List<SFC_WorkCenter> workCenterList)
        {
            foreach (SFC_WorkCenter workCenter in workCenterList)
            {
                if (!shopControlList[companyId].WorkCenters.ContainsKey(workCenter.Id))
                    shopControlList[companyId].AddWorkCenter(workCenter);
            }
        }

        public SFC_WorkCenter getRandomWorkCenter(long companyId)
        {
            return shopControlList[companyId].getRandomWorkCenter();
        }

        public void ShowWorkCenters(long companyId)
        {
            shopControlList[companyId].ShowWorkCenters();
        }
        #endregion

        #region bom
        public static long NextBomCount()
        {
            return bomCount++;
        }

        public void AddBomList(long companyId, List<SFC_Bom> bomList)
        {
            foreach (SFC_Bom bom in bomList)
            {
                if (!shopControlList[companyId].Boms.ContainsKey(bom.Id))
                    shopControlList[companyId].AddBom(bom);
            }
        }

        public void ShowBoms(long companyId)
        {
            shopControlList[companyId].ShowBoms();
        }

        public SFC_Bom getRandomBom(long companyId)
        {
            return shopControlList[companyId].getRandomBom();
        }


        #endregion
    }
}
