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

        public static long NextBinCount()
        {
            return binCount++;
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

        public SFC_Item getRandomItem(long companyId)
        {
            return shopControlList[companyId].getRandomItem();
        }
        #endregion



        #region lot bin
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
            return shopControlList[companyId].getRandomMachineTypes();
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

    }
}
