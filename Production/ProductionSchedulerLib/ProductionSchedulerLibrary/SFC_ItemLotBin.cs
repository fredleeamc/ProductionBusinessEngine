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
    public class SFC_ItemLotBin
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;
        /// <summary>
        /// The item identifier
        /// </summary>
        private long itemId;
        /// <summary>
        /// The lot no
        /// </summary>
        private String lotNo;
        /// <summary>
        /// The bin no
        /// </summary>
        private String binNo;
        /// <summary>
        /// The batch no
        /// </summary>
        private String batchNo;
        /// <summary>
        /// The heat no
        /// </summary>
        private String heatNo;
        /// <summary>
        /// The item status
        /// </summary>
        private SFC_ItemStatus itemStatus;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        public long ItemId
        {
            get
            {
                return itemId;
            }

            protected set
            {
                itemId = value;
            }
        }

        /// <summary>
        /// The item
        /// </summary>
        private SFC_Item item;

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public SFC_Item Item
        {
            get
            {
                return item;
            }

            protected set
            {
                item = value;
            }
        }



        /// <summary>
        /// Gets or sets the lot no.
        /// </summary>
        /// <value>
        /// The lot no.
        /// </value>
        public string LotNo
        {
            get
            {
                return lotNo;
            }

            set
            {
                lotNo = value;
            }
        }

        /// <summary>
        /// Gets or sets the bin no.
        /// </summary>
        /// <value>
        /// The bin no.
        /// </value>
        public string BinNo
        {
            get
            {
                return binNo;
            }

            set
            {
                binNo = value;
            }
        }

        /// <summary>
        /// Gets or sets the item status.
        /// </summary>
        /// <value>
        /// The item status.
        /// </value>
        public SFC_ItemStatus ItemStatus
        {
            get
            {
                return itemStatus;
            }

            protected set
            {
                itemStatus = value;
            }
        }

        /// <summary>
        /// Gets or sets the batch no.
        /// </summary>
        /// <value>
        /// The batch no.
        /// </value>
        public string BatchNo
        {
            get
            {
                return batchNo;
            }

            set
            {
                batchNo = value;
            }
        }

        /// <summary>
        /// Gets or sets the heat no.
        /// </summary>
        /// <value>
        /// The heat no.
        /// </value>
        public string HeatNo
        {
            get
            {
                return heatNo;
            }

            set
            {
                heatNo = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_ItemLotBin"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <param name="lotNo">The lot no.</param>
        /// <param name="binNo">The bin no.</param>
        public SFC_ItemLotBin(long id, SFC_Item item, string lotNo, string binNo)
        {
            this.id = id;
            this.item = item;
            this.item.addLotBin(this);
            this.ItemId = item.Id;
            this.itemStatus = new SFC_ItemStatus(this);
            this.lotNo = lotNo;
            this.binNo = binNo;
        }



        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Lotbin:" + id + "," + itemId + "," + lotNo + "," + binNo;
        }
    }
}
