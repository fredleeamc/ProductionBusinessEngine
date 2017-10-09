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
    public  class SFC_ItemLotBin
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;
        /// <summary>
        /// The item identifier
        /// </summary>
        private readonly long itemId;
        /// <summary>
        /// The lot no
        /// </summary>
        private readonly String lotNo;
        /// <summary>
        /// The bin no
        /// </summary>
        private String binNo;
        /// <summary>
        /// The batch no
        /// </summary>
        private readonly String batchNo;
        /// <summary>
        /// The heat no
        /// </summary>
        private String heatNo;
        /// <summary>
        /// The item status
        /// </summary>
        private readonly SFC_ItemStatus itemStatus;
        /// <summary>
        /// The item
        /// </summary>
        private readonly SFC_Item item;
        /// <summary>
        /// The unit cost
        /// </summary>
        private decimal unitCost;

        /// <summary>
        /// The unit
        /// </summary>
        private string unit;

        private SFC_Currency currency;

        private SFC_CurrencyExchange currencyExchange;

  

        public  decimal UnitCost { get => unitCost; set => unitCost = value; }

        public  string Unit { get => unit; set => unit = value; }

        public  long Id => id;

        public  long ItemId => itemId;

        public  string LotNo => lotNo;

        public  string BinNo { get => binNo; set => binNo = value; }

        public  string BatchNo => batchNo;

        public  string HeatNo { get => heatNo; set => heatNo = value; }

        public  SFC_ItemStatus ItemStatus => itemStatus;

        public  SFC_Item Item => item;

        public  decimal UnitCost1 { get => unitCost; set => unitCost = value; }
        public  string Unit1 { get => unit; set => unit = value; }
        public SFC_Currency Currency { get => currency; set => currency = value; }
        public SFC_CurrencyExchange CurrencyExchange { get => currencyExchange; set => currencyExchange = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_ItemLotBin"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <param name="lotNo">The lot no.</param>
        /// <param name="binNo">The bin no.</param>
        public  SFC_ItemLotBin(long id, SFC_Item item, string lotNo, string batchNo)
        {
            this.id = id;
            this.item = item;
            this.item.addLotBin(this);
            this.itemId = item.Id;
            this.itemStatus = new SFC_ItemStatus(this);
            this.lotNo = lotNo;
            this.batchNo = batchNo;
        }



        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public  override string ToString()
        {
            return "Lotbin:" + id + "," + itemId + "," + lotNo + "," + batchNo;
        }
    }
}
