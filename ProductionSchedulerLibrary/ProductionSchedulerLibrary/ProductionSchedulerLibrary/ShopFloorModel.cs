using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductionSchedulerLibrary
{

    public class ShopFloorModel
    {
        static private Random rnd = new Random();

        private long companyId;

        private SFC_Company company;

        private Dictionary<long, SFC_Employee> employees;

        private Dictionary<long, SFC_ItemLotBin> lotBin;

        private Dictionary<long, SFC_Item> items;

        public Dictionary<long, SFC_Employee> Employees
        {
            get
            {
                return employees;
            }

            protected set
            {
                employees = value;
            }
        }

        public Dictionary<long, SFC_ItemLotBin> LotBinList
        {
            get
            {
                return lotBin;
            }

            protected set
            {
                lotBin = value;
            }
        }

        public Dictionary<long, SFC_Item> Items
        {
            get
            {
                return items;
            }

            protected set
            {
                items = value;
            }
        }

        public ShopFloorModel(long companyId, String companyName)
        {
            this.companyId = companyId;
            company = new SFC_Company(companyId, companyName);
            this.employees = new Dictionary<long, SFC_Employee>();
            this.lotBin = new Dictionary<long, SFC_ItemLotBin>();
            this.items = new Dictionary<long, SFC_Item>();
        }

        public SFC_Company GetCompany()
        {
            return this.company;
        }

        public void AddEmployee(SFC_Employee scheduledEmployee)
        {
            employees.Add(scheduledEmployee.Id, scheduledEmployee);
        }

        public void ShowEmployees()
        {
            foreach (long empId in employees.Keys)
            {
                Console.WriteLine(employees[empId]);
            }
        }

        public SFC_Employee getRandomEmployee()
        {
            int rand = ShopFloorModel.rnd.Next(0, employees.Count);
            return employees[rand];
        }

        public void AddLotBin(SFC_ItemLotBin itemLotBin)
        {
            lotBin.Add(itemLotBin.Id, itemLotBin);
        }

        public void ShowLotbin()
        {
            foreach (long lotId in lotBin.Keys)
            {
                Console.WriteLine(lotBin[lotId]);
                Console.WriteLine(lotBin[lotId].ItemStatus);
            }
        }
        public SFC_ItemLotBin getRandomLotBin()
        {
            int rand = ShopFloorModel.rnd.Next(1, lotBin.Count+1);
            return lotBin[rand];
        }


        public void AddItems(SFC_Item item)
        {
            items.Add(item.Id, item);
        }

        public void ShowItems()
        {
            foreach (long itemId in items.Keys)
            {
                Console.WriteLine(items[itemId]);
            }
        }

        public SFC_Item getRandomItem()
        {
            int rand = ShopFloorModel.rnd.Next(1, items.Count+1);
            return items[rand];
        }



    }
}
