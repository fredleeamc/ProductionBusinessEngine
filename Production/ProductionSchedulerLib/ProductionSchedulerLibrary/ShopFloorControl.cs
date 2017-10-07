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
    public class ShopFloorControl
    {
        #region field
        /// <summary>
        /// The shop control list
        /// </summary>
        private static Dictionary<long, ShopFloorModel> shopControlList = null;

        /// <summary>
        /// The instance SFC
        /// </summary>
        private static ShopFloorControl instanceSFC = null;
        #endregion

        private static Object lockObject = new Object();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static ShopFloorControl Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instanceSFC == null)
                    {
                        instanceSFC = new ShopFloorControl();
                        shopControlList = new Dictionary<long, ShopFloorModel>();
                    }
                }
                return instanceSFC;
            }

        }

        public Dictionary<long, ShopFloorModel> Company { get => shopControlList; }

        #region shop floor model
        /// <summary>
        /// Creates the shop floor model.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public ShopFloorModel CreateShopFloorModel(SFC_Company company, SFC_Currency currency)
        {
            ShopFloorModel model = null;
            if (!shopControlList.ContainsKey(company.Id))
            {
                model = new ShopFloorModel(company.Id, company.CompanyName, currency);
                shopControlList.Add(company.Id, model);
                company.Currency = currency;
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
        public ShopFloorModel CreateShopFloorModel(SFC_Company company)
        {
            if (company.Currency == null)
                throw new Exception("Currency not set");
            return CreateShopFloorModel(company, company.Currency);
        }
        #endregion




       
    }
}
