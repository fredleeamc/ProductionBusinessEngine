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
            ShopSequenceGenerator seqGen = ShopSequenceGenerator.Instance;
            ShopFloor shopFloor = ShopFloor.Instance;
            #endregion

            #region Definition
            SFC_Currency PH_Peso = new SFC_Currency(1, "PH_Peso", "P");
            SFC_Currency US_Dollar = new SFC_Currency(2, "US_Dollar", "$");

            SFC_CurrencyExchange pesoToDollar = new SFC_CurrencyExchange(1, PH_Peso, US_Dollar, DateTime.Now, 50M, 50M);
            SFC_CurrencyExchange dollarToPeso = new SFC_CurrencyExchange(2, US_Dollar, PH_Peso, DateTime.Now, 1M / 50M, 1M / 50M);
            SFC_CurrencyExchange pesoTopeso = new SFC_CurrencyExchange(1, PH_Peso, PH_Peso, DateTime.Now, 1M, 1M);
            SFC_CurrencyExchange dollarTodollar = new SFC_CurrencyExchange(2, US_Dollar, US_Dollar, DateTime.Now, 1M, 1M);

            decimal xchange1 = 1 * pesoToDollar.BuyingRate;
            Console.WriteLine(String.Format("1 Peso = ${0:F2}", xchange1));
            decimal xchange2 = 1 * dollarToPeso.SellingRate;
            Console.WriteLine(String.Format("1 Dollar = ${0:F2}", xchange2));
            #endregion

            #region Model Company
            seqGen.CreateNewSequence("CO", 0);
            SFC_Company company = new SFC_Company(seqGen.GetNext("CO"), "Vision");


            shopFloor.CreateShopFloorModel(company, PH_Peso);
            shopFloor.DefaultCurrency = PH_Peso;
            shopFloor.DefaultCurrencyExchange = pesoToDollar;
            shopFloor.Company[company.Id].Currencies.Add(PH_Peso);
            shopFloor.Company[company.Id].Currencies.Add(US_Dollar);
            shopFloor.Company[company.Id].CurrencyExchanges.Add(PH_Peso.Id, pesoToDollar);
            shopFloor.Company[company.Id].CurrencyExchanges.Add(US_Dollar.Id, dollarToPeso);
            shopFloor.Company[company.Id].CurrencyExchanges.Add(PH_Peso.Id, pesoTopeso);
            shopFloor.Company[company.Id].CurrencyExchanges.Add(US_Dollar.Id, dollarTodollar);

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
                    SFC_ItemLotBin thisBin = new SFC_ItemLotBin(seqGen.GetNext("BIN"), thisItem, "BEGIN", "BEGIN");
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
            seqGen.CreateNewSequence("FG", 0);
            for (int bitem = 1; bitem <= 10; bitem++)
            {
                SFC_Currency baseCurrency = shopFloor.Company[company.Id].Currencies.GetRandom();
                SFC_BomComposite c = new SFC_BomComposite(seqGen.GetNext("BOMC"), TextGenerator.RandomNames());
                int numItems = 1 + TextGenerator.RandomInt(10);
                List<SFC_BomComposite> u = new List<SFC_BomComposite>();
                c.Currency = shopFloor.Company[company.Id].Currencies.GetRandom();
                c.CurrencyExchange = c.Currency.GetLatestExchange(baseCurrency);
                c.PartName = TextGenerator.RandomString(10);
                c.Quantity = 1;
                u.Add(c);
                SFC_BomComposite w = c;
                for (int i = 0; i < numItems; i++)
                {
                    int r = TextGenerator.RandomInt(10);
                    if (r % 2 != 0)
                    {
                        bool success = false;
                        while (!success)
                        {
                            SFC_BomComposite d = new SFC_BomComposite(seqGen.GetNext("BOMC"), "COMP" + i);
                            w = u[TextGenerator.RandomInt(u.Count)];
                            d.PartName = TextGenerator.RandomNames();
                            d.Quantity = 4;
                            d.UnitCost = 4; // TextGenerator.RandomDouble(10);
                            d.Unit = "EACH";
                            d.Currency = shopFloor.Company[company.Id].Currencies.GetRandom();
                            d.CurrencyExchange = d.Currency.GetLatestExchange(c.Currency);
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
                                        SFC_BomItem t = new SFC_BomItem(seqGen.GetNext("BOMI"), d.PartNo + "I" + y);
                                        t.PartName = TextGenerator.RandomNames();
                                        t.Quantity = 2;
                                        t.UnitCost = 1; // TextGenerator.RandomDouble(10);
                                        t.Unit = "EACH";
                                        t.Currency = d.Currency;
                                        t.CurrencyExchange = t.Currency.GetLatestExchange(d.Currency);
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
                        SFC_BomItem t = new SFC_BomItem(seqGen.GetNext("BOMC"), "COMP" + i);
                        t.PartName = TextGenerator.RandomNames();
                        t.Quantity = 5;
                        t.UnitCost = 10; // TextGenerator.RandomDouble(100);
                        t.Unit = "EACH";
                        t.Currency = shopFloor.Company[company.Id].Currencies.GetRandom();
                        t.CurrencyExchange = t.Currency.GetLatestExchange(c.Currency);
                        w.Add(t);
                    }
                }
                SFC_Bom b = new SFC_Bom(seqGen.GetNext("BOM"), c);
                b.TotalQuantity = TextGenerator.RandomInt(5) + 1;
                b.Currency = baseCurrency;
                //b.CurrencyExchange = b.Currency.GetLatestExchange(c.Currency);
                shopFloor.Company[company.Id].Boms.Add(b);
            }


            //Build meter composite



            //seqGen.CreateNewSequence("FG", 0);
            seqGen.FormatSpecifier("RM", "{0:D5}", true);
            SFC_BomComposite meterC = new SFC_BomComposite(seqGen.GetNext("BOMC"), "1ERQ1T0");
            meterC.PartName = "Meter FM 1S";
            meterC.Quantity = 1;
            meterC.UnitCost = 00.00M;
            meterC.Unit = "EACH";
            meterC.Currency = US_Dollar;
            //meterC.CurrencyExchange = meterC.Currency.GetLatestExchange(US_Dollar);


            //SFC_Item pcbItem = new SFC_Item(seqGen.GetNext("RM"), "000016-5");

            SFC_BomComponent pcb = new SFC_BomComposite(seqGen.GetNext("BOMC"), "000016-5");
            pcb.PartName = "PCB16-5";
            pcb.Quantity = 1;
            pcb.UnitCost = 0.00M;
            pcb.Unit = "PC";
            pcb.Currency = US_Dollar;
            //pcb.CurrencyExchange = pcb.Currency.GetLatestExchange(US_Dollar);

            meterC.Add(pcb);

            for (int i = 2; i <= 10; i += 2)
            {
                //SFC_Item resistorItem = new SFC_Item(seqGen.GetNext("RM"), "R"+i);
                SFC_BomComponent resistor = new SFC_BomItem(seqGen.GetNext("BOMI"), "000000R" + i);
                resistor.PartName = "Resistor" + i;
                resistor.Quantity = i;
                resistor.UnitCost = i * 0.02M;
                resistor.Unit = "PC";
                resistor.Currency = US_Dollar;
                //resistor.CurrencyExchange = resistor.Currency.GetLatestExchange(US_Dollar);
                pcb.Add(resistor);
            }

            SFC_BomComponent meterBase = new SFC_BomComposite(seqGen.GetNext("BOMC"), "DMDBase12");
            meterBase.PartName = "Base";
            meterBase.Quantity = 1;
            meterBase.Unit = "PC";
            meterBase.UnitCost = 2.50M;
            meterBase.Currency = US_Dollar;

            SFC_BomComponent stabs = new SFC_BomItem(seqGen.GetNext("BOMI"), "STAB123");
            stabs.PartName = "Stabs";
            stabs.Quantity = 4;
            stabs.Unit = "PC";
            stabs.UnitCost = 50.0M;
            stabs.Currency = PH_Peso;

            SFC_BomComponent pin = new SFC_BomItem(seqGen.GetNext("BOMI"), "PIN123");
            pin.PartName = "Pins";
            pin.Quantity = 8;
            pin.Unit = "PC";
            pin.UnitCost = 0.250M;
            pin.Currency = US_Dollar;

            meterBase.Add(stabs);
            meterBase.Add(pin);

            meterC.Add(meterBase);


            SFC_Bom meterbom = new SFC_Bom(seqGen.GetNext("BOM"), meterC);
            meterbom.TotalQuantity = 10;
            meterbom.Currency = US_Dollar;
            meterC.CurrencyExchange = meterC.Currency.GetLatestExchange(meterbom.Currency);
            //meterbom.CurrencyExchange = meterbom.Currency.GetLatestExchange(US_Dollar);
            shopFloor.Company[company.Id].Boms.Add(meterbom);

            Console.WriteLine("Bill of materials");

            shopFloor.Company[company.Id].Boms.Print();
            shopFloor.Company[company.Id].Boms.DisplayBom();
            shopFloor.Company[company.Id].Boms.PrintBillOfMaterials();


            //Console.WriteLine("Change Bom Qty");
            //meterbom.TotalQuantity = 5;
            //shopFloor.Company[company.Id].Boms.DisplayBom();
            //shopFloor.Company[company.Id].Boms.PrintBillOfMaterials();


            //foreach (KeyValuePair<SFC_Item, decimal> pair in meterbom.BuildBillOfMaterials())
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
