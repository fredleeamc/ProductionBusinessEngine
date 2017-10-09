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
    public  class ShopFloor
    {
        #region field
        /// <summary>
        /// The shop control list
        /// </summary>
        private static Dictionary<long, ShopFloorModel> shopControlList = null;

        /// <summary>
        /// The instance SFC
        /// </summary>
        private static ShopFloor instanceSFC = null;
        #endregion

        private static Object lockObject = new Object();

        private static SFC_Currency defaultCurrency = new SFC_Currency(1, "Not set", "");
        private static SFC_CurrencyExchange defaultCurrencyExchange = new SFC_CurrencyExchange(1, defaultCurrency, defaultCurrency, DateTime.Now, 1, 1);

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public  static ShopFloor Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instanceSFC == null)
                    {
                        instanceSFC = new ShopFloor();
                    }
                }
                return instanceSFC;
            }

        }

        private ShopFloor()
        {
            shopControlList = new Dictionary<long, ShopFloorModel>();

        }

        public  Dictionary<long, ShopFloorModel> Company { get => shopControlList; }
        public  SFC_Currency DefaultCurrency { get => defaultCurrency; set => defaultCurrency = value; }
        public  SFC_CurrencyExchange DefaultCurrencyExchange { get => defaultCurrencyExchange; set => defaultCurrencyExchange = value; }

        #region shop floor model
        /// <summary>
        /// Creates the shop floor model.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public  ShopFloorModel CreateShopFloorModel(SFC_Company company, SFC_Currency currency)
        {
            ShopFloorModel model = null;
            if (!shopControlList.ContainsKey(company.Id))
            {
                model = new ShopFloorModel(company.Id, company.CompanyName, company.Settings);
                shopControlList.Add(company.Id, model);
                company.Settings.DefaultCurrency = currency;
                model.Companies.Add(company);              
            }
            else
            {
                model = shopControlList[company.Id];
            }
            return model;
        }


        /// <summary>
        /// Creates the shop floor model.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Currency not set</exception>
        public  ShopFloorModel CreateShopFloorModel(SFC_Company company)
        {
            if (company.Settings.DefaultCurrency == null)
                throw new Exception("Currency not set");
            return CreateShopFloorModel(company, company.Settings.DefaultCurrency);
        }
        #endregion





    }
}
