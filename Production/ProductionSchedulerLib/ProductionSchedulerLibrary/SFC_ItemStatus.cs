using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{

    public class SFC_ItemStatus
    {
        private SFC_Item item;
        private SFC_ItemLotBin itemLotBin;
        private bool isItem;
        private decimal beginBalance;
        private decimal receive;
        private decimal onHand;
        private decimal onPurchase;
        private decimal inProduction;
        private decimal allocated;
        private decimal reserved;
        private decimal totalAvailable;
        private decimal totalRequired;
        private decimal scrap;
        private decimal netUsed;
        private decimal vendorReturn;
        private decimal adjustmentIn;
        private decimal adjustmentOut;
        private decimal minAutoOrder;
        private decimal reorderPoint;

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

        public decimal OnHand
        {
            get
            {
                return onHand;
            }

            protected set
            {
                onHand = value;
            }
        }

        public decimal OnPurchase
        {
            get
            {
                return onPurchase;
            }

            protected set
            {
                onPurchase = value;
            }
        }

        public decimal InProduction
        {
            get
            {
                return inProduction;
            }

            protected set
            {
                inProduction = value;
            }
        }

        public decimal Allocated
        {
            get
            {
                return allocated;
            }

            protected set
            {
                allocated = value;
            }
        }

        public decimal Reserved
        {
            get
            {
                return reserved;
            }

            protected set
            {
                reserved = value;
            }
        }

        public decimal TotalAvailable
        {
            get
            {
                return totalAvailable;
            }

            protected set
            {
                totalAvailable = value;
            }
        }

        public decimal TotalRequired
        {
            get
            {
                return totalRequired;
            }

            protected set
            {
                totalRequired = value;
            }
        }

        public decimal Scrap
        {
            get
            {
                return scrap;
            }

            protected set
            {
                scrap = value;
            }
        }

        public SFC_ItemLotBin ItemLotBin
        {
            get
            {
                return itemLotBin;
            }

            protected set
            {
                itemLotBin = value;
            }
        }

        private bool IsItem
        {
            get
            {
                return isItem;
            }

            set
            {
                isItem = value;
            }
        }

        public decimal Used
        {
            get
            {
                return netUsed;
            }

            protected set
            {
                netUsed = value;
            }
        }

        public decimal AdjustmentIn
        {
            get
            {
                return adjustmentIn;
            }

            protected set
            {
                adjustmentIn = value;
            }
        }

        public decimal AdjustmentOut
        {
            get
            {
                return adjustmentOut;
            }

            protected set
            {
                adjustmentOut = value;
            }
        }

        public decimal BeginQty
        {
            get
            {
                return beginBalance;
            }

            protected set
            {
                beginBalance = value;
            }
        }

        public decimal Receive
        {
            get
            {
                return receive;
            }

            protected set
            {
                receive = value;
            }
        }

        /**
         * 
         */
        public SFC_ItemStatus(SFC_Item thisItem)
        {
            this.item = thisItem;
            this.isItem = true;
        }

        public SFC_ItemStatus(SFC_ItemLotBin itemLotBin)
        {
            this.itemLotBin = itemLotBin;
            this.isItem = false;
        }

        /*
         * 
         */
        public bool splitLotBin(SFC_ItemLotBin newLotBin, decimal qtyToTransfer)
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
        public void beginQuantity(decimal qty)
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
        public void addBeginQuantity(decimal qty)
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
        public void receiveQuantity(decimal qty)
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
        public bool useQuantity(decimal qty)
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
        public void purchaseOrderQuantity(decimal qty)
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
        public bool movePurchaseOrderToReceiveQuantity(decimal qty)
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
        public bool allocateToWorkOrderQuantity(decimal qty)
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
        public bool moveAllocatedToProductionQuantity(decimal qty)
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
        public bool reserveQuantity(decimal qty)
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
        public void moveReservedToAllocatedQuantity(decimal qty)
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
        public void scrapFromWarehouseQuantity(decimal qty)
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
        public void scrapFromProductionQuantity(decimal qty)
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
        public void returnToVendorQuantity(decimal qty)
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
        public void returnScrapToVendorQuantity(decimal qty)
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
        public void adjustQuantityIn(decimal qty)
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
        public void adjustQuantityOut(decimal qty)
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
        public bool moveToFinishGoods(decimal qty)
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
         private static String SFormat2 = "{0, 10}|{1,10}|<{2,10}|{3,10}|{4,10}>|<{5,10}|{6,10}|{7,10}|{8,10}>|{9,10}|{10,10}|{11,10}|{12,10}|{13,10}";

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format(SFormat2,
                beginBalance, receive, onHand, onPurchase, netUsed, inProduction, allocated, reserved, totalAvailable, totalRequired, scrap, vendorReturn, adjustmentIn, adjustmentOut));
            return sb.ToString();
        }
    }
}
