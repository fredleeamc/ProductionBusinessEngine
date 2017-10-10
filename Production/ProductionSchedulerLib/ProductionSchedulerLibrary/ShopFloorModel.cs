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
    public  class ShopFloorModel
    {
        #region fields
        /// <summary>
        /// The random
        /// </summary>
        static private Random rnd = new Random();

        /// <summary>
        /// The company identifier
        /// </summary>
        private long companyId;

        /// <summary>
        /// The company
        /// </summary>
        private SFC_Company company;


        /// <summary>
        /// The boms
        /// </summary>
        private readonly SFC_Boms boms;


        /// <summary>
        /// The employees
        /// </summary>
        private readonly SFC_Employees employees;

        /// <summary>
        /// The customers
        /// </summary>
        private readonly SFC_Customers customers;

        /// <summary>
        /// The lot bin
        /// </summary>
        private readonly SFC_ItemLotBins lotBins;

        /// <summary>
        /// The items
        /// </summary>
        private readonly SFC_Items items;

        /// <summary>
        /// The machine types
        /// </summary>
        private readonly SFC_MachineTypes machineTypes;

        /// <summary>
        /// The machines
        /// </summary>
        private readonly SFC_Machines machines;

        /// <summary>
        /// The work center types
        /// </summary>
        private readonly SFC_WorkCenterTypes workCenterTypes;

        /// <summary>
        /// The work centers
        /// </summary>
        private readonly SFC_WorkCenters workCenters;


        private readonly SFC_ProductBuilds builds;

        private readonly SFC_Routers routers;

        private readonly SFC_WorkOrders workOrders;

        private readonly SFC_Companies companies;

        private readonly SFC_Currencies currencies;

        private readonly SFC_CurrencyExchanges currencyExchanges;

        private readonly SFC_CompanySettings settings;
        #endregion


        public  SFC_Boms Boms => boms;

        public  SFC_Employees Employees => employees;

        public  SFC_Customers Customers => customers;

        public  SFC_ItemLotBins LotBins => lotBins;

        public  SFC_Items Items => items;

        public  SFC_MachineTypes  MachineTypes => machineTypes;

        public  SFC_Machines Machines => machines;     

        public  SFC_WorkCenters WorkCenters => workCenters;

        public  SFC_WorkCenterTypes WorkCenterTypes => workCenterTypes;

        public  SFC_ProductBuilds Build => builds;

        public  SFC_Routers Routers => routers;

        public  SFC_WorkOrders WorkOrders => workOrders;

        public  SFC_Companies Companies => companies;


        public  SFC_Currencies Currencies => currencies;

        public  SFC_CurrencyExchanges CurrencyExchanges => currencyExchanges;

        public SFC_CompanySettings Settings => settings;



        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopFloorModel"/> class.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="companyName">Name of the company.</param>
        public  ShopFloorModel(long companyId, String companyName, SFC_CompanySettings settings)
        {
            this.companyId = companyId;
            this.settings = settings;
            company = new SFC_Company(companyId, companyName);
            this.companies = new SFC_Companies();
            this.companies.Model = this;
            this.employees = new SFC_Employees();
            this.employees.Model = this;
            this.customers = new SFC_Customers();
            this.customers.Model = this;
            this.lotBins = new SFC_ItemLotBins();
            this.lotBins.Model = this;
            this.items = new SFC_Items();
            this.items.Model = this;
            this.machineTypes = new SFC_MachineTypes();
            this.machineTypes.Model = this;
            this.machines = new SFC_Machines();
            this.machines.Model = this;
            this.workCenterTypes = new SFC_WorkCenterTypes();
            this.workCenterTypes.Model = this;
            this.workCenters = new SFC_WorkCenters();
            this.workCenters.Model = this;
            this.boms = new SFC_Boms();
            this.boms.Model = this;
            this.builds = new SFC_ProductBuilds();
            this.builds.Model = this;
            this.routers = new SFC_Routers();
            this.routers.Model = this;
            this.workOrders = new SFC_WorkOrders();
            this.workOrders.Model = this;
            this.currencies = new SFC_Currencies();
            this.currencies.Model = this;
            this.currencyExchanges = new SFC_CurrencyExchanges();
            this.currencyExchanges.Model = this;

        }
        #endregion

     
 

    }
}
