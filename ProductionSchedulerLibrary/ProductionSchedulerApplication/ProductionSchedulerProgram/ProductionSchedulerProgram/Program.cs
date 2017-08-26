using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionSchedulerLibrary;
using System.Threading;

namespace ProductionSchedulerProgram
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Initialize Shop Floor Control
            SFC_Company company = new SFC_Company(1, "Vision");
            ShopFloorControl shopFloor = ShopFloorControl.GetInstance();
            shopFloor.CreateShopFloorModel(company);
            #endregion

            // Start getting resources by company only
            #region Add Employee
            int employeeCount = 10;
            List<SFC_Employee> empList = new List<SFC_Employee>();
            for (int emp = 1; emp <= employeeCount; emp++)
            {
                empList.Add(new SFC_Employee(emp, TextGenerator.RandomNumbers(8), TextGenerator.RandomNames(), TextGenerator.RandomNames(1, 1), TextGenerator.RandomNames()));
            }
            shopFloor.AddEmployeeList(1, empList);
            //shopFloor.ShowEmployees(1);
            #endregion

            #region Add Items
            int itemCount = 10;
            List<SFC_Item> itemList = new List<SFC_Item>();
            for (int itemId = 1; itemId <= itemCount; itemId++)
            {
                SFC_Item thisItem = new SFC_Item(ShopFloorControl.NextItemCount(), TextGenerator.RandomNames());
                itemList.Add(thisItem);
            }
            shopFloor.AddItemList(1, itemList);
            //shopFloor.ShowItems(1);
            #endregion

            #region Add LotBin Begin Balance
            int lotBinCount = 5;
            List<SFC_ItemLotBin> binList = new List<SFC_ItemLotBin>();
            for (int bin = 1; bin <= lotBinCount; bin++)
            {
                SFC_Item thisItem = shopFloor.getRandomItem(1);
                SFC_ItemLotBin thisBin = new SFC_ItemLotBin(ShopFloorControl.NextBinCount(), thisItem, "BEGIN", "BEGIN");
                thisBin.ItemStatus.beginQuantity(1000);
                binList.Add(thisBin);
            }
            shopFloor.AddBomList(1, binList);
            //shopFloor.ShowLotBin(1);
            //shopFloor.ShowItems(1);
            #endregion

            #region Simulate Production
            int randomCount = 20;
            for (int i = 0; i < randomCount; i++)
            {
                SFC_Item thisItem = shopFloor.getRandomItem(1);
                SFC_ItemLotBin thisBin = new SFC_ItemLotBin(ShopFloorControl.NextBinCount(), thisItem, "PO", TextGenerator.RandomNumbers(4));
                thisBin.ItemStatus.purchaseOrderQuantity(100);
                thisBin.ItemStatus.ItemLotBin.LotNo = TextGenerator.RandomNumbers(4);
                thisBin.ItemStatus.ItemLotBin.BinNo = TextGenerator.RandomNumbers(3);
                thisBin.ItemStatus.movePurchaseOrderToReceiveQuantity(100);
                thisBin.ItemStatus.reserveQuantity(20);
                thisBin.ItemStatus.allocateToWorkOrderQuantity(50);
                thisBin.ItemStatus.moveAllocatedToProductionQuantity(40);
                thisBin.ItemStatus.moveReservedToAllocatedQuantity(20);
                thisBin.ItemStatus.moveAllocatedToProductionQuantity(30);
                thisBin.ItemStatus.moveToFinishGoods(70);
                
            }
            #endregion
            shopFloor.ShowItems(1);


            Thread.Sleep(1000);
            

        }
    }
}
