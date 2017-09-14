using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionSchedulerLibrary;
using System.Threading;


namespace ProductionSchedulerProgram
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {

        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {

            DateTime ts1 = DateTime.Now;

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
            #endregion
            shopFloor.ShowEmployees(company.Id);

            #region Add Items
            int itemCount = 10;
            List<SFC_Item> itemList = new List<SFC_Item>();
            for (int itemId = 1; itemId <= itemCount; itemId++)
            {
                SFC_Item thisItem = new SFC_Item(ShopFloorControl.NextItemCount(), TextGenerator.RandomNames());
                itemList.Add(thisItem);
            }
            shopFloor.AddItemList(company.Id, itemList);

            #endregion
            //shopFloor.ShowItems(company.Id);

            #region Add LotBin Begin Balance
            int lotBinCount = 5;
            List<SFC_ItemLotBin> binList = new List<SFC_ItemLotBin>();
            for (int bin = 1; bin <= lotBinCount; bin++)
            {
                SFC_Item thisItem = shopFloor.getRandomItem(company.Id);
                SFC_ItemLotBin thisBin = new SFC_ItemLotBin(ShopFloorControl.NextBinCount(), thisItem, "BEGIN", "BEGIN");
                thisBin.ItemStatus.beginQuantity(1000);
                binList.Add(thisBin);
            }
            shopFloor.AddBomList(1, binList);
            #endregion
            //shopFloor.ShowLotBin(company.Id);
            //shopFloor.ShowItems(company.Id);

            #region Simulate Production
            int randomCount = 20;
            for (int i = 1; i < randomCount; i++)
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

            shopFloor.ShowItemStatus(company.Id);
            #endregion

            #region work center type
            List<SFC_WorkCenterType> workCenterTypeList = new List<SFC_WorkCenterType>();
            SFC_WorkCenterType finite = new SFC_WorkCenterType(1, "FINITE");
            SFC_WorkCenterType infinite = new SFC_WorkCenterType(2, "INFINITE");
            workCenterTypeList.Add(finite);
            workCenterTypeList.Add(infinite);
            shopFloor.AddWorkCenterTypes(company.Id, workCenterTypeList);
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

            #region Add Work Center
            int workCenterCount = 10;
            List<SFC_WorkCenter> workCenterList = new List<SFC_WorkCenter>();
            for (int workCenter = 1; workCenter <= workCenterCount; workCenter++)
            {
                SFC_WorkCenterType mtype = shopFloor.getRandomWorkCenterType(company.Id);
                SFC_WorkCenter thisWorkCenter = new SFC_WorkCenter(workCenter, "WC" + TextGenerator.RandomNumbers(3), finite);
                thisWorkCenter.MachineType = shopFloor.getRandomMachineType(company.Id);
                workCenterList.Add(thisWorkCenter);
            }
            shopFloor.AddWorkCenters(company.Id, workCenterList);
            #endregion

            #region Add Machine
            int machineCount = 10;
            List<SFC_Machine> machineList = new List<SFC_Machine>();
            for (int machine = 1; machine <= machineCount; machine++)
            {
                SFC_MachineType mtype = shopFloor.getRandomMachineType(company.Id);
                SFC_Machine thisMachine = new SFC_Machine(machine, TextGenerator.RandomNumbers(3), mtype);
                thisMachine.setWorkCenter(SFC_MachineType.GetRandomWorkCenter(mtype));
                machineList.Add(thisMachine);
            }
            shopFloor.AddMachines(company.Id, machineList);
            #endregion

            shopFloor.ShowMachineTypes(company.Id);
            shopFloor.ShowMachines(company.Id);
            shopFloor.ShowWorkCenters(company.Id);
            //Thread.Sleep(1000);


            #region bom
            SFC_BomComposite meter = new SFC_BomComposite(1, new SFC_Item(ShopFloorControl.NextItemCount(), "Meter"), 1);
            SFC_Bom meterbom = new SFC_Bom(1, "FM1S", "XAA111", meter);

            SFC_Item pcbItem = new SFC_Item(ShopFloorControl.NextItemCount(), "16-5");
            
            SFC_BomComponent pcb = new SFC_BomComposite(1, pcbItem, 1);
            SFC_BomComponent resistor = new SFC_BomComposite(2, new SFC_Item(1000, "Resistor 5K"), 10);

            SFC_BomComponent resistor2 = new SFC_BomComposite(2, new SFC_Item(1000, "Resistor 5K"), 30);

            SFC_BomComponent carbon = new SFC_BomComposite(3, new SFC_Item(ShopFloorControl.NextItemCount(), "Carbon"), 33);
            SFC_BomComponent metal = new SFC_BomItem(4, new SFC_Item(ShopFloorControl.NextItemCount(), "Metal"), 1.25);
            pcb.Add(resistor);
            pcb.Add(resistor2);
            resistor.Add(carbon);
            resistor.Add(metal);
            meter.Add(pcb);
            meter.Add(metal);
            pcb.Add(carbon);
            resistor.Add(metal);
            resistor.Add(metal);
            carbon.Add(meter);
            
            Console.WriteLine(meterbom);
            Console.WriteLine("Count:"+meterbom.CountItems());

            foreach(KeyValuePair<SFC_Item, double> pair in  meterbom.BuildBillOfMaterials())
            {
                Console.WriteLine("{0}:{1}", pair.Key, pair.Value);
            }

            #endregion

            #region work orders
            List<SFC_WorkOrder> workOrders = new List<SFC_WorkOrder>();
            SFC_Customer cust = new SFC_Customer(0, 0, TextGenerator.RandomNames(5, 10), TextGenerator.RandomNumbers(4));



            #endregion






            DateTime ts2 = DateTime.Now;
            Console.WriteLine("Total millisecs:" + ts2.Subtract(ts1).TotalMilliseconds);

            Thread.Sleep(2000);
        }
    }
}
