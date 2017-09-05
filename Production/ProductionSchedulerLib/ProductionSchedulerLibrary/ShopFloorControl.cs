using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class ShopFloorControl
    {

        protected static Dictionary<long, ShopFloorModel> shopControlList = null;

        private static ShopFloorControl instanceSFC = null;

        private static long binCount = 1;

        private static long itemCount = 1;

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

        public static long NextItemCount()
        {
            return itemCount++;
        }

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
            } else
            {
                model = shopControlList[companyId];
            }
            return model;
        }


        public void AddBomList(long companyId, List<SFC_ItemLotBin> itemLotBinList)
        {
            foreach (SFC_ItemLotBin bin in itemLotBinList)
            {
                if (!shopControlList[companyId].LotBinList.ContainsKey(bin.Id))
                    shopControlList[companyId].AddLotBin(bin);
            }
        }

        public void AddEmployeeList(long companyId, List<SFC_Employee> employeeList)
        {
            foreach (SFC_Employee emp in employeeList)
            {
                if (!shopControlList[companyId].Employees.ContainsKey(emp.Id))
                    shopControlList[companyId].AddEmployee(emp);
            }
        }

        public void AddItemList(long companyId, List<SFC_Item> itemList)
        {
            foreach (SFC_Item item in itemList)
            {
                if (!shopControlList[companyId].Items.ContainsKey(item.Id))
                    shopControlList[companyId].AddItems(item);
            }
        }

        public void ShowEmployees(long companyId)
        {
            shopControlList[companyId].ShowEmployees();
        }

        public void ShowLotBin(long companyId)
        {
            shopControlList[companyId].ShowLotbin();
        }

        public void ShowItems(long companyId)
        {
            shopControlList[companyId].ShowItems();
        }

        public SFC_Item getRandomItem(long companyId)
        {
            return shopControlList[companyId].getRandomItem();
        }

        public SFC_ItemLotBin getRandomItemLotBin(long companyId)
        {
            return shopControlList[companyId].getRandomLotBin();
        }

    }
}
