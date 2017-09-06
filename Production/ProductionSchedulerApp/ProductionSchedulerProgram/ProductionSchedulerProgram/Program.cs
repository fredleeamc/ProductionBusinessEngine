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
            shopFloor.AddEmployeeList(company.Id, empList);
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
            shopFloor.AddItemList(company.Id, itemList);
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
                SFC_Item thisItem = shopFloor.getRandomItem(company.Id);
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
                thisBin.ItemStatus.scrapFromWarehouseQuantity(2);               
            }

            shopFloor.ShowItems(company.Id);
            #endregion

            #region Add Machine type

            List<SFC_MachineType> machineTypeList = new List<SFC_MachineType>();
            SFC_MachineType lathe = new SFC_MachineType(1, "Lathe");
            SFC_MachineType hmill = new SFC_MachineType(2, "H. Mill");
            SFC_MachineType vmill = new SFC_MachineType(3, "V. Mill");
            SFC_MachineType rdrill = new SFC_MachineType(4, "Robo Drill");
            SFC_MachineType cutter = new SFC_MachineType(5, "Cutter");
            machineTypeList.Add(lathe);
            machineTypeList.Add(hmill);
            machineTypeList.Add(vmill);
            machineTypeList.Add(rdrill);
            machineTypeList.Add(cutter);

            shopFloor.AddMachineType(company.Id, machineTypeList);
            #endregion

            #region Add Machine
            int machineCount = 20;
            List<SFC_Machine> machineList = new List<SFC_Machine>();
            for (int machine = 1; machine <= machineCount; machine++)
            {
                SFC_MachineType mtype = shopFloor.getRandomMachineType(company.Id);
                SFC_Machine thisMachine = new SFC_Machine(machine, mtype, TextGenerator.RandomNumbers(3));
                machineList.Add(thisMachine);
            }
            shopFloor.AddMachines(company.Id, machineList);

            shopFloor.ShowMachineTypes(company.Id);
            shopFloor.ShowMachines(company.Id);
            #endregion


            Thread.Sleep(1000);
            

        }
    }
}
