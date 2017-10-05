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
        public ShopFloorModel CreateShopFloorModel(SFC_Company company)
        {
            return CreateShopFloorModel(company.Id, company.CompanyName);
        }

        /// <summary>
        /// Creates the shop floor model.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="companyName">Name of the company.</param>
        /// <returns></returns>
        public ShopFloorModel CreateShopFloorModel(long companyId, String companyName)
        {
            ShopFloorModel model = null;
            if (!shopControlList.ContainsKey(companyId))
            {
                model = new ShopFloorModel(companyId, companyName);
                shopControlList.Add(companyId, model);
            }
            else
            {
                model = shopControlList[companyId];
            }
            return model;
        }
        #endregion




       
    }
}
