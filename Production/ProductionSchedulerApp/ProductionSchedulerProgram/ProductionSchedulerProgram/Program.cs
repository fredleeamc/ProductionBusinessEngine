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
            ShopSequenceGenerator seqGen = ShopSequenceGenerator.Instance;
            DateTime ts1 = DateTime.Now;
            seqGen.CreateNewSequence("CO", 0);
            #region Initialize Shop Floor Control
            SFC_Company company = new SFC_Company(seqGen.GetNext("CO"), "Vision");
            ShopFloorControl shopFloor = ShopFloorControl.Instance;

            shopFloor.CreateShopFloorModel(company);
            shopFloor.Company[company.Id].Companies.Add(company);



            #endregion

            //Task t1 = new Task(() =>
            //           {
            // Start getting resources by company only
            #region Add Employee
            seqGen.CreateNewSequence("EMP", 0);
            seqGen.FormatSpecifier("EMP", "{0:D5}", true);
            int employeeCount = 10;
            for (int emp = 1; emp <= employeeCount; emp++)
            {
                SFC_Employee thisEmp = new SFC_Employee(seqGen.GetNext("EMP"), seqGen.GetPattern("EMP"),
                    TextGenerator.RandomNames(), TextGenerator.RandomNames(1, 1), TextGenerator.RandomNames());
                shopFloor.Company[company.Id].Employees.Add(thisEmp);
            }
            #endregion
            shopFloor.Company[company.Id].Employees.Print();

            #region Add Employee
            seqGen.CreateNewSequence("CUST", 0);

            seqGen.FormatSpecifier("C", "{0:D5}", true);
            int custCount = 10;
            for (int custn = 1; custn <= custCount; custn++)
            {
                SFC_Company comp = new SFC_Company(seqGen.GetNext("CO"), TextGenerator.RandomNames());
                SFC_Customer thisCust = new SFC_Customer(seqGen.GetNext("CUST"), comp, TextGenerator.RandomNumbers(8), TextGenerator.RandomNumbers(10));
                shopFloor.Company[company.Id].Customers.Add(thisCust);
            }
            #endregion
            shopFloor.Company[company.Id].Employees.Print();

            //           });
            //t1.Start();

            //ManualResetEventSlim rst = new ManualResetEventSlim();
            //rst.Reset();
            seqGen.CreateNewSequence("RM", 0);
            seqGen.FormatSpecifier("RM", "{0:D5}", true);
            //Task t2 = new Task(() =>
            //{
            #region Add Items

            int itemCount = 25;
            for (int itemId = 1; itemId <= itemCount; itemId++)
            {
                SFC_Item thisItem = new SFC_Item(seqGen.GetNext("RM"), seqGen.GetPattern("RM") + ":" + TextGenerator.RandomNames());
                shopFloor.Company[company.Id].Items.Add(thisItem);
            }
            shopFloor.Company[company.Id].Items.Print();

            //});


            #endregion
            //shopFloor.ShowItems(company.Id);

            #region Add LotBin Begin Balance
            seqGen.CreateNewSequence("BIN", 0);
            seqGen.FormatSpecifier("BIN", "{0:D4}", true);
            //Task t3 = new Task(() =>
            //{
            int lotBinCount = 5;
            for (int bin = 1; bin <= lotBinCount; bin++)
            {
                SFC_Item thisItem = shopFloor.Company[company.Id].Items.GetRandom();
                if (thisItem != null)
                {
                    SFC_ItemLotBin thisBin = new SFC_ItemLotBin(seqGen.GetNext("Bin"), thisItem, "BEGIN", "BEGIN");
                    thisBin.ItemStatus.beginQuantity(TextGenerator.RandomInt(100));
                    shopFloor.Company[company.Id].LotBins.Add(thisBin);
                }
            }
            shopFloor.Company[company.Id].LotBins.Print();
            //});

            #endregion
            //shopFloor.ShowLotBin(company.Id);
            //shopFloor.ShowItems(company.Id);
            //Task t4 = new Task(() =>
            //{
            #region Simulate Production
            int randomCount = 15;
            for (int i = 1; i <= randomCount; i++)
            {
                SFC_Item thisItem = shopFloor.Company[company.Id].Items.GetRandom();
                if (thisItem != null)
                {
                    SFC_ItemLotBin thisBin;
                    if (i % 2 == 0)
                    {
                        thisBin = shopFloor.Company[company.Id].LotBins.GetRandom();
                    }
                    else
                    {
                        thisBin = new SFC_ItemLotBin(seqGen.GetNext("BIN"), thisItem, seqGen.GetPattern("BIN"), TextGenerator.RandomNumbers(4));
                        thisBin.ItemStatus.ItemLotBin.HeatNo = TextGenerator.RandomNumbers(4);
                        thisBin.ItemStatus.ItemLotBin.BinNo = TextGenerator.RandomNumbers(3);
                    }
                    int qty = TextGenerator.RandomInt(200);
                    thisBin.ItemStatus.purchaseOrderQuantity(qty);

                    int mqty = qty - 2;
                    if (qty < 2)
                        mqty = qty;
                    thisBin.ItemStatus.movePurchaseOrderToReceiveQuantity(mqty);
                    thisBin.ItemStatus.reserveQuantity(qty / 10);
                    thisBin.ItemStatus.allocateToWorkOrderQuantity(mqty / 2);
                    thisBin.ItemStatus.moveAllocatedToProductionQuantity(mqty / 4);
                    thisBin.ItemStatus.moveReservedToAllocatedQuantity(qty / 20);
                    thisBin.ItemStatus.moveAllocatedToProductionQuantity(qty / 20);
                    thisBin.ItemStatus.moveToFinishGoods(mqty / 2);
                    thisBin.ItemStatus.scrapFromWarehouseQuantity(2);
                }
                else
                {
                    Console.WriteLine("No Item found");

                }
            }
            shopFloor.Company[company.Id].Items.PrintItemsStatus();
            //});
            #endregion
            //t2.Start();
            //t4.Start();
            //t3.Start();


            //rst.Set();

            //});

            //t2.Start();

            //Task t3 = new Task(() =>
            //{

            #region work center type

            SFC_WorkCenterType finite = new SFC_WorkCenterType(1, "FINITE");
            SFC_WorkCenterType infinite = new SFC_WorkCenterType(2, "INFINITE");

            shopFloor.Company[company.Id].WorkCenterTypes.Add(finite);
            shopFloor.Company[company.Id].WorkCenterTypes.Add(infinite);
            #endregion

            #region Add Machine type
            List<SFC_MachineType> machineTypeList = new List<SFC_MachineType>();
            SFC_MachineType lathe = new SFC_MachineType(1, "Lathe");
            SFC_MachineType hmill = new SFC_MachineType(2, "H. Mill");
            SFC_MachineType vmill = new SFC_MachineType(3, "V. Mill");
            SFC_MachineType rdrill = new SFC_MachineType(4, "Robo Drill");
            SFC_MachineType cutter = new SFC_MachineType(5, "Cutter");

            shopFloor.Company[company.Id].MachineTypes.Add(lathe);
            shopFloor.Company[company.Id].MachineTypes.Add(hmill);
            shopFloor.Company[company.Id].MachineTypes.Add(vmill);
            shopFloor.Company[company.Id].MachineTypes.Add(rdrill);
            shopFloor.Company[company.Id].MachineTypes.Add(cutter);

            #endregion

            #region Add Work Center
            int workCenterCount = 5;
            for (int workCenter = 1; workCenter <= workCenterCount; workCenter++)
            {
                SFC_WorkCenterType mtype = shopFloor.Company[company.Id].WorkCenterTypes.GetRandom();
                SFC_WorkCenter thisWorkCenter = new SFC_WorkCenter(workCenter, "WC" + TextGenerator.RandomNumbers(3), finite);
                thisWorkCenter.MachineType = shopFloor.Company[company.Id].MachineTypes.GetRandom();
                shopFloor.Company[company.Id].WorkCenters.Add(thisWorkCenter);
            }
            #endregion

            #region Add Machine
            int machineCount = 10;
            for (int machine = 1; machine <= machineCount; machine++)
            {
                SFC_MachineType mtype = shopFloor.Company[company.Id].MachineTypes.GetRandom();
                SFC_Machine thisMachine = new SFC_Machine(machine, TextGenerator.RandomNumbers(3), mtype);
                thisMachine.setWorkCenter(SFC_MachineType.GetRandomWorkCenter(mtype));
                shopFloor.Company[company.Id].Machines.Add(thisMachine);
            }
            shopFloor.Company[company.Id].Machines.Print();


            #endregion
            shopFloor.Company[company.Id].Machines.Print();
            shopFloor.Company[company.Id].MachineTypes.Print();
            shopFloor.Company[company.Id].WorkCenters.Print();

            //Thread.Sleep(1000);
            //});

            //t3.Start();

            //Task t4 = new Task(() =>
            //{
            //    rst.Wait();
            #region bom
            seqGen.CreateNewSequence("BOM", 0);
            seqGen.CreateNewSequence("BOMC", 0);
            seqGen.CreateNewSequence("BOMI", 0);
            for (int bitem = 0; bitem < 10; bitem++)
            {
                SFC_BomComposite c = new SFC_BomComposite(seqGen.GetNext("BOMC"), shopFloor.Company[company.Id].Items.GetRandom(), 1);
                int numItems = 1 + TextGenerator.RandomInt(10);
                List<SFC_BomComposite> u = new List<SFC_BomComposite>();
                u.Add(c);
                SFC_BomComposite w = c;
                for (int i = 0; i < numItems; i++)
                {
                    int r = TextGenerator.RandomInt(10);
                    if (r % 7 != 0)
                    {
                        bool success = false;
                        while (!success)
                        {
                            SFC_BomComposite d = new SFC_BomComposite(seqGen.GetNext("BOMC"), shopFloor.Company[company.Id].Items.GetRandom(), 1 + TextGenerator.RandomInt(10));
                            w = u[TextGenerator.RandomInt(u.Count)];
                            d.UnitCost = 0; // TextGenerator.RandomDouble(10);
                            d.Unit = "EACH";

                            if (w.Add(d))
                            {
                                u.Add(d);
                                bool success2 = false;
                                int ccount = 0;
                                while (!success2)
                                {
                                    int numItems2 = TextGenerator.RandomInt(3) + 1;
                                    for (int y = 0; y < numItems2; y++)
                                    {
                                        SFC_BomItem t = new SFC_BomItem(seqGen.GetNext("BOMI"), shopFloor.Company[company.Id].Items.GetRandom(), 1 + TextGenerator.RandomInt(10));
                                        t.UnitCost = 1; // TextGenerator.RandomDouble(10);
                                        t.Unit = "EACH";
                                        if (d.Add(t))
                                        {
                                            success2 = true;
                                            ccount++;
                                        }
                                        if (ccount > 20)
                                            break;
                                    }
                                }
                                success = true;
                            }
                        }
                        //w = d;
                    }
                    else
                    {
                        SFC_BomItem t = new SFC_BomItem(seqGen.GetNext("BOMC"), shopFloor.Company[company.Id].Items.GetRandom(), 1 + TextGenerator.RandomInt(10));
                        t.UnitCost = 10; // TextGenerator.RandomDouble(100);
                        t.Unit = "EACH";
                        w.Add(t);
                    }
                }
                SFC_Bom b = new SFC_Bom(seqGen.GetNext("BOM"), TextGenerator.RandomChars(8), TextGenerator.RandomChars(10), c);
                shopFloor.Company[company.Id].Boms.Add(b);
            }





            //SFC_BomComposite meter = new SFC_BomComposite(1, new SFC_Item(seqGen.GetNext("RM"), "Meter"), 1);
            //meter.UnitCost = 12.00;
            //meter.Unit = "EACH";
            //SFC_Bom meterbom = new SFC_Bom(1, "FM1S", "XAA111", meter);

            //SFC_Item pcbItem = new SFC_Item(seqGen.GetNext("RM"), "16-5");

            //SFC_BomComponent pcb = new SFC_BomComposite(1, pcbItem, 1);
            //pcb.UnitCost = 5;
            //pcb.Unit = "PC";

            //SFC_Item resistorItem = new SFC_Item(seqGen.GetNext("RM"), "Resistor 5K");

            //SFC_BomComponent resistor = new SFC_BomComposite(2, resistorItem, 20);
            //resistor.UnitCost = 4;
            //resistor.Unit = "PC";

            //SFC_BomComponent resistor2 = new SFC_BomComposite(2, resistorItem, 10);
            //resistor2.UnitCost = 3;
            //resistor2.Unit = "PC";

            //SFC_BomComponent carbon = new SFC_BomComposite(3, new SFC_Item(seqGen.GetNext("RM"), "Carbon"), 10);
            //carbon.UnitCost = 2;
            //carbon.Unit = "PC";

            //SFC_BomComponent metal = new SFC_BomItem(4, new SFC_Item(seqGen.GetNext("RM"), "Metal"), 0.5);
            //metal.UnitCost = 1;
            //metal.Unit = "PC";

            //pcb.Add(resistor);
            //pcb.Add(resistor2);
            //resistor.Add(carbon);
            //resistor.Add(metal);
            //meter.Add(pcb);
            //meter.Add(metal);
            //pcb.Add(carbon);
            //resistor.Add(metal);
            //resistor.Add(metal);
            //carbon.Add(meter);

            //shopFloor.Company[company.Id].Boms.Add(meterbom);

            //Console.WriteLine(meterbom);
            //Console.WriteLine("Count:" + meterbom.CountItems());

            //Console.WriteLine("Meter:$" + meter.EstimatedCost());
            //Console.WriteLine("Pcb:$" + pcb.EstimatedCost());
            //Console.WriteLine("Resistor:$" + resistor.EstimatedCost());
            //Console.WriteLine("Carbon:$" + carbon.EstimatedCost());
            //Console.WriteLine("Metal:$" + metal.EstimatedCost());


            Console.WriteLine("Bill of materials");

            shopFloor.Company[company.Id].Boms.Print();
            shopFloor.Company[company.Id].Boms.DisplayBom();
            shopFloor.Company[company.Id].Boms.PrintBillOfMaterials();

            //foreach (KeyValuePair<SFC_Item, double> pair in meterbom.BuildBillOfMaterials())
            //{
            //    Console.WriteLine("{0}:{1}", pair.Key, pair.Value);
            //}

            #endregion
            //});

            //t4.Start();
            seqGen.CreateNewSequence("WO", 0);
            #region work orders
            List<SFC_WorkOrder> workOrders = new List<SFC_WorkOrder>();

            SFC_WorkOrder wo1 = new SFC_WorkOrder(1, seqGen.GetYYYYMMPattern("WO"), shopFloor.Company[company.Id].Customers.GetRandom(),
                null, DateTime.Now, shopFloor.Company[company.Id].Items.GetRandom(), false);

            #endregion






            DateTime ts2 = DateTime.Now;
            Console.WriteLine("Total millisecs:" + ts2.Subtract(ts1).TotalMilliseconds);

            Thread.Sleep(2000);
        }
    }
}
