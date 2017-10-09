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
    public  class SFC_ItemStatus
    {
        /// <summary>
        /// The item
        /// </summary>
        private readonly SFC_Item item;
        /// <summary>
        /// The item lot bin
        /// </summary>
        private SFC_ItemLotBin itemLotBin;
        /// <summary>
        /// The is item
        /// </summary>
        private readonly bool isItem;
        /// <summary>
        /// The begin balance
        /// </summary>
        private decimal beginBalance;
        /// <summary>
        /// The receive
        /// </summary>
        private decimal receive;
        /// <summary>
        /// The on hand
        /// </summary>
        private decimal onHand;
        /// <summary>
        /// The on purchase
        /// </summary>
        private decimal onPurchase;
        /// <summary>
        /// The in production
        /// </summary>
        private decimal inProduction;
        /// <summary>
        /// The allocated
        /// </summary>
        private decimal allocated;
        /// <summary>
        /// The reserved
        /// </summary>
        private decimal reserved;
        /// <summary>
        /// The total available
        /// </summary>
        private decimal totalAvailable;
        /// <summary>
        /// The total required
        /// </summary>
        private decimal totalRequired;
        /// <summary>
        /// The scrap
        /// </summary>
        private decimal scrap;
        /// <summary>
        /// The net used
        /// </summary>
        private decimal netUsed;
        /// <summary>
        /// The vendor return
        /// </summary>
        private decimal vendorReturn;
        /// <summary>
        /// The adjustment in
        /// </summary>
        private decimal adjustmentIn;
        /// <summary>
        /// The adjustment out
        /// </summary>
        private decimal adjustmentOut;
        /// <summary>
        /// The minimum automatic order
        /// </summary>
        private decimal minAutoOrder;
        /// <summary>
        /// The reorder point
        /// </summary>
        private decimal reorderPoint;


        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public  SFC_Item Item => item;

        /// <summary>
        /// Gets or sets the item lot bin.
        /// </summary>
        /// <value>
        /// The item lot bin.
        /// </value>
        public  SFC_ItemLotBin ItemLotBin { get => itemLotBin; set => itemLotBin = value; }

        /// <summary>
        /// Gets a value indicating whether this instance is item.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is item; otherwise, <c>false</c>.
        /// </value>
        public  bool IsItem => isItem;

        /// <summary>
        /// Gets or sets the begin balance.
        /// </summary>
        /// <value>
        /// The begin balance.
        /// </value>
        public  decimal BeginBalance { get => beginBalance; set => beginBalance = value; }
        /// <summary>
        /// Gets or sets the receive.
        /// </summary>
        /// <value>
        /// The receive.
        /// </value>
        public  decimal Receive { get => receive; set => receive = value; }
        /// <summary>
        /// Gets or sets the on hand.
        /// </summary>
        /// <value>
        /// The on hand.
        /// </value>
        public  decimal OnHand { get => onHand; set => onHand = value; }
        /// <summary>
        /// Gets or sets the on purchase.
        /// </summary>
        /// <value>
        /// The on purchase.
        /// </value>
        public  decimal OnPurchase { get => onPurchase; set => onPurchase = value; }
        /// <summary>
        /// Gets or sets the in production.
        /// </summary>
        /// <value>
        /// The in production.
        /// </value>
        public  decimal InProduction { get => inProduction; set => inProduction = value; }
        /// <summary>
        /// Gets or sets the allocated.
        /// </summary>
        /// <value>
        /// The allocated.
        /// </value>
        public  decimal Allocated { get => allocated; set => allocated = value; }
        /// <summary>
        /// Gets or sets the reserved.
        /// </summary>
        /// <value>
        /// The reserved.
        /// </value>
        public  decimal Reserved { get => reserved; set => reserved = value; }
        /// <summary>
        /// Gets or sets the total available.
        /// </summary>
        /// <value>
        /// The total available.
        /// </value>
        public  decimal TotalAvailable { get => totalAvailable; set => totalAvailable = value; }
        /// <summary>
        /// Gets or sets the total required.
        /// </summary>
        /// <value>
        /// The total required.
        /// </value>
        public  decimal TotalRequired { get => totalRequired; set => totalRequired = value; }
        /// <summary>
        /// Gets or sets the scrap.
        /// </summary>
        /// <value>
        /// The scrap.
        /// </value>
        public  decimal Scrap { get => scrap; set => scrap = value; }
        /// <summary>
        /// Gets or sets the net used.
        /// </summary>
        /// <value>
        /// The net used.
        /// </value>
        public  decimal NetUsed { get => netUsed; set => netUsed = value; }
        /// <summary>
        /// Gets or sets the vendor return.
        /// </summary>
        /// <value>
        /// The vendor return.
        /// </value>
        public  decimal VendorReturn { get => vendorReturn; set => vendorReturn = value; }
        /// <summary>
        /// Gets or sets the adjustment in.
        /// </summary>
        /// <value>
        /// The adjustment in.
        /// </value>
        public  decimal AdjustmentIn { get => adjustmentIn; set => adjustmentIn = value; }
        /// <summary>
        /// Gets or sets the adjustment out.
        /// </summary>
        /// <value>
        /// The adjustment out.
        /// </value>
        public  decimal AdjustmentOut { get => adjustmentOut; set => adjustmentOut = value; }
        /// <summary>
        /// Gets or sets the minimum automatic order.
        /// </summary>
        /// <value>
        /// The minimum automatic order.
        /// </value>
        public  decimal MinAutoOrder { get => minAutoOrder; set => minAutoOrder = value; }
        /// <summary>
        /// Gets or sets the reorder point.
        /// </summary>
        /// <value>
        /// The reorder point.
        /// </value>
        public  decimal ReorderPoint { get => reorderPoint; set => reorderPoint = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_ItemStatus"/> class.
        /// </summary>
        /// <param name="thisItem">The this item.</param>
        public  SFC_ItemStatus(SFC_Item thisItem)
        {
            this.item = thisItem;
            this.isItem = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_ItemStatus"/> class.
        /// </summary>
        /// <param name="itemLotBin">The item lot bin.</param>
        public  SFC_ItemStatus(SFC_ItemLotBin itemLotBin)
        {
            this.itemLotBin = itemLotBin;
            this.isItem = false;
        }

        /*
         * Split lotbin but maintain lotbin number
         */
        /// <summary>
        /// Splits the lot bin.
        /// </summary>
        /// <param name="newLotBin">The new lot bin.</param>
        /// <param name="qtyToTransfer">The qty to transfer.</param>
        /// <returns></returns>
        public  bool splitLotBin(SFC_ItemLotBin newLotBin, decimal qtyToTransfer)
        {
            bool result = false;
            lock(this)
            {
                if (qtyToTransfer < this.onHand)
                {
                    newLotBin.Item.ItemStatus.beginQuantity(qtyToTransfer);
                    this.onHand -= qtyToTransfer;
                    this.totalAvailable -= qtyToTransfer;
                    //No need to update item master since quantity will not change
                }                 
            }
            return result;
        }


        /*
         * This will reset begin quantity, receive, on hand, and total available to qty value
         */
        /// <summary>
        /// Begins the quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        public  void beginQuantity(decimal qty)
        {
            lock (this)
            {
                this.beginBalance = qty;
                this.receive = qty;
                this.onHand = qty;
                this.totalAvailable = qty;
                if (!this.isItem && this.ItemLotBin.Item != null)
                    this.ItemLotBin.Item.ItemStatus.addBeginQuantity(qty);
            }
        }


        /*
         * This will reset begin quantity, receive, on hand, and total available to qty value
         */
        /// <summary>
        /// Adds the begin quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        public  void addBeginQuantity(decimal qty)
        {
            lock (this)
            {
                this.beginBalance += qty;
                this.receive += qty;
                this.onHand += qty;
                this.totalAvailable += qty;
                if (!this.isItem && this.ItemLotBin.Item != null)
                    this.ItemLotBin.Item.ItemStatus.addBeginQuantity(qty);
            }
        }
        /*
         * Receive quantity that did not go through order by purchasing
         * Non-production
         */
        /// <summary>
        /// Receives the quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        public  void receiveQuantity(decimal qty)
        {
            lock (this)
            {
                this.receive += qty;
                this.onHand += qty;
                this.totalAvailable += qty;
                if (!this.isItem && this.ItemLotBin.Item != null)
                    this.ItemLotBin.Item.ItemStatus.receiveQuantity(qty);
            }
        }

        /*
         * Receive quantity that did not go through order by purchasing
         * Non-production
         */
        /// <summary>
        /// Uses the quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        /// <returns></returns>
        public  bool useQuantity(decimal qty)
        {
            bool result = false;
            lock (this)
            {
                if (this.onHand >= qty)
                {
                    this.onHand -= qty;
                    this.totalAvailable -= qty;
                    if (!this.isItem && this.ItemLotBin.Item != null)
                        this.ItemLotBin.Item.ItemStatus.useQuantity(qty);
                    result = true;
                }
            }
            return result;
        }

        /*
         * Quantity that is already ordered by purchasing
         * Production
         */
        /// <summary>
        /// Purchases the order quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        public  void purchaseOrderQuantity(decimal qty)
        {
            lock (this)
            {
                this.onPurchase += qty;
                this.totalAvailable += qty;
                if (!this.isItem && this.ItemLotBin.Item != null)
                    this.ItemLotBin.Item.ItemStatus.purchaseOrderQuantity(qty);
            }
        }

        /* 
         * Quantity that was ordered by purchasing now received
         * Production
         */
        /// <summary>
        /// Moves the purchase order to receive quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        /// <returns></returns>
        public  bool movePurchaseOrderToReceiveQuantity(decimal qty)
        {
            bool result = false;
            lock (this)
            {
                if (this.onPurchase >= qty)
                {
                    this.onHand += qty;
                    this.receive += qty;
                    this.onPurchase -= qty;
                    if (!this.isItem && this.ItemLotBin.Item != null)
                        this.ItemLotBin.Item.ItemStatus.movePurchaseOrderToReceiveQuantity(qty);
                    result = true;
                }
            }
            return result;
        }

        /*
         * Quantity allocated to work order.  
         * Generated when Work Order is generated.
         * Production
         */
        /// <summary>
        /// Allocates to work order quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        /// <returns></returns>
        public  bool allocateToWorkOrderQuantity(decimal qty)
        {
            bool result = false;
            lock (this)
            {
                if (this.totalAvailable >= qty)
                {
                    this.allocated += qty;
                    this.totalAvailable -= qty;
                    this.totalRequired += qty;
                    if (!this.isItem && this.ItemLotBin.Item != null)
                        this.ItemLotBin.Item.ItemStatus.allocateToWorkOrderQuantity(qty);
                    result = true;
                }
            }
            return result;
        }

        /*
         * Quantity must be allocated first when Work Order is generated, then
         * issue the allocated quanity to production.
         * Production
         */
        /// <summary>
        /// Moves the allocated to production quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        /// <returns></returns>
        public  bool moveAllocatedToProductionQuantity(decimal qty)
        {
            bool result = false;
            lock (this)
            {
                if (this.allocated >= qty && this.onHand >= qty)
                {
                    this.onHand -= qty;
                    this.allocated -= qty;
                    this.netUsed += qty;
                    this.inProduction += qty;
                    if (!this.isItem && this.ItemLotBin.Item != null)
                        this.ItemLotBin.Item.ItemStatus.moveAllocatedToProductionQuantity(qty);
                    result = true;
                }
            }
            return result;
        }

        /*
         * Quantity reserved for future production.
         */
        /// <summary>
        /// Reserves the quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        /// <returns></returns>
        public  bool reserveQuantity(decimal qty)
        {
            bool result = false;
            lock (this)
            {
                if (this.totalAvailable >= qty)
                {
                    this.reserved += qty;
                    this.totalAvailable -= qty;
                    this.totalRequired += qty;
                    if (!this.isItem && this.ItemLotBin.Item != null)
                        this.ItemLotBin.Item.ItemStatus.reserveQuantity(qty);
                    result = true;
                }
            }
            return result;
        }

        /*
         * Quantity that was reserved that is moved to allocated when
         * work order is generated.
         */
        /// <summary>
        /// Moves the reserved to allocated quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        public  void moveReservedToAllocatedQuantity(decimal qty)
        {
            lock (this)
            {
                this.reserved -= qty;
                this.allocated += qty;
                if (!this.isItem && this.ItemLotBin.Item != null)
                    this.ItemLotBin.Item.ItemStatus.moveReservedToAllocatedQuantity(qty);
            }
        }

        /*
         * Scrap before item is sent to production
         */
        /// <summary>
        /// Scraps from warehouse quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        public  void scrapFromWarehouseQuantity(decimal qty)
        {
            lock (this)
            {
                this.scrap += qty;
                this.onHand -= qty;
                this.totalAvailable -= qty;
                if (!this.isItem && this.ItemLotBin.Item != null)
                    this.ItemLotBin.Item.ItemStatus.scrapFromWarehouseQuantity(qty);
            }
        }

        /*
         * Scrap after discovering problem at produciton 
         */
        /// <summary>
        /// Scraps from production quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        public  void scrapFromProductionQuantity(decimal qty)
        {
            lock (this)
            {
                this.scrap += qty;
                this.netUsed -= qty;
                if (!this.isItem && this.ItemLotBin.Item != null)
                    this.ItemLotBin.Item.ItemStatus.scrapFromProductionQuantity(qty);
            }
        }

        /*
         * Return non-scrap item to vendor
         */
        /// <summary>
        /// Returns to vendor quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        public  void returnToVendorQuantity(decimal qty)
        {
            lock (this)
            {
                this.vendorReturn += qty;
                this.totalAvailable -= qty;
                this.onHand -= qty;
                if (!this.isItem && this.ItemLotBin.Item != null)
                    this.ItemLotBin.Item.ItemStatus.returnToVendorQuantity(qty);
            }
        }

        /*
         * Return scrap to vendor
         */
        /// <summary>
        /// Returns the scrap to vendor quantity.
        /// </summary>
        /// <param name="qty">The qty.</param>
        public  void returnScrapToVendorQuantity(decimal qty)
        {
            lock (this)
            {
                this.vendorReturn += qty;
                this.scrap -= qty;
                if (!this.isItem && this.ItemLotBin.Item != null)
                    this.ItemLotBin.Item.ItemStatus.returnScrapToVendorQuantity(qty);
            }
        }

        /*
         *  Invenory adjustment IN
         */
        /// <summary>
        /// Adjusts the quantity in.
        /// </summary>
        /// <param name="qty">The qty.</param>
        public  void adjustQuantityIn(decimal qty)
        {
            lock (this)
            {
                this.adjustmentIn += qty;
                this.totalAvailable += qty;
                this.onHand += qty;
                if (!this.isItem && this.ItemLotBin.Item != null)
                    this.ItemLotBin.Item.ItemStatus.adjustQuantityIn(qty);
            }
        }

        /*
         *  Invenory adjustment IN
         */
        /// <summary>
        /// Adjusts the quantity out.
        /// </summary>
        /// <param name="qty">The qty.</param>
        public  void adjustQuantityOut(decimal qty)
        {
            lock (this)
            {
                this.adjustmentOut += qty;
                this.totalAvailable -= qty;
                this.onHand -= qty;
                if (!this.isItem && this.ItemLotBin.Item != null)
                    this.ItemLotBin.Item.ItemStatus.adjustQuantityOut(qty);
            }
        }

        /*
         * Inventory completed in production.  Now WIP to finished goods.
         */
        /// <summary>
        /// Moves to finish goods.
        /// </summary>
        /// <param name="qty">The qty.</param>
        /// <returns></returns>
        public  bool moveToFinishGoods(decimal qty)
        {
            bool result = false;
            lock (this)
            {
                if (this.inProduction >= qty)
                {
                    this.inProduction -= qty;
                    if (!this.isItem && this.ItemLotBin.Item != null)
                        this.ItemLotBin.Item.ItemStatus.moveToFinishGoods(qty);
                    result = true;
                }
            }
            return result;
        }

        //private static String SFormat1 = "{0, 40}|{1,10}|{2,10}|{3,10}|{4,10}|{5,10}|{6,10}|{7,10}|{8,10}|{9,10}|{10,10}|{11,10}|{12,10}|{13,10}";
        /// <summary>
        /// The s format2
        /// </summary>
        private static String SFormat2 = "{0, 10}|{1,10}|<{2,10}|{3,10}|{4,10}>|<{5,10}|{6,10}|{7,10}|{8,10}>|{9,10}|{10,10}|{11,10}|{12,10}|{13,10}";



        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public  override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format(SFormat2,
                beginBalance, receive, onHand, onPurchase, netUsed, inProduction, allocated, reserved, totalAvailable, totalRequired, scrap, vendorReturn, adjustmentIn, adjustmentOut));
            return sb.ToString();
        }
    }
}
