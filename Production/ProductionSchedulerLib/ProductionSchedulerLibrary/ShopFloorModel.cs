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
            this.employees = new SFC_Employees();
            this.customers = new SFC_Customers();
            this.lotBins = new SFC_ItemLotBins();
            this.items = new SFC_Items();
            this.machineTypes = new SFC_MachineTypes();
            this.machines = new SFC_Machines();
            this.workCenterTypes = new SFC_WorkCenterTypes();
            this.workCenters = new SFC_WorkCenters();
            this.boms = new SFC_Boms();
            this.builds = new SFC_ProductBuilds();
            this.routers = new SFC_Routers();
            this.workOrders = new SFC_WorkOrders();
            this.currencies = new SFC_Currencies();
            this.currencyExchanges = new SFC_CurrencyExchanges();
        }
        #endregion

     
 

    }
}
