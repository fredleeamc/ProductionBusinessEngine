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
    public class SFC_WorkOrder
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The customer
        /// </summary>
        private SFC_Customer customer;

        /// <summary>
        /// The target completion date
        /// </summary>
        private DateTime? targetCompletionDate;

        /// <summary>
        /// The due date
        /// </summary>
        private DateTime dueDate;

        /// <summary>
        /// The item
        /// </summary>
        private SFC_Item item;

        /// <summary>
        /// The is ready start
        /// </summary>
        private bool isReadyStart;

        /// <summary>
        /// The unit price
        /// </summary>
        private decimal? unitPrice;
        /// <summary>
        /// The estimated unit cost
        /// </summary>
        private decimal? estimatedUnitCost;
        /// <summary>
        /// The estimated total labor hours
        /// </summary>
        private DateTime? estimatedTotalLaborHours;
        /// <summary>
        /// The estimated total labor cost
        /// </summary>
        private decimal? estimatedTotalLaborCost;
        /// <summary>
        /// The estimated total material cost
        /// </summary>
        private decimal? estimatedTotalMaterialCost;
        /// <summary>
        /// The ordered build quantity
        /// </summary>
        private decimal? orderedBuildQuantity;
        /// <summary>
        /// The actual build quantity
        /// </summary>
        private decimal? actualBuildQuantity;
        /// <summary>
        /// The actual unit cost
        /// </summary>
        private decimal? actualUnitCost;
        /// <summary>
        /// The actual total labor hours
        /// </summary>
        private DateTime? actualTotalLaborHours;
        /// <summary>
        /// The actual total labor cost
        /// </summary>
        private decimal? actualTotalLaborCost;
        /// <summary>
        /// The actual total material cost
        /// </summary>
        private decimal? actualTotalMaterialCost;
        /// <summary>
        /// The estimated profit
        /// </summary>
        private decimal? estimatedProfit;
        /// <summary>
        /// The scheduled start date
        /// </summary>
        private DateTime? scheduledStartDate;
        /// <summary>
        /// The scheduled completion date
        /// </summary>
        private DateTime? scheduledCompletionDate;

        /// <summary>
        /// The details
        /// </summary>
        private readonly SortedList<long, SFC_WorkOrderDetail> details;

        /// <summary> Constructor
        /// Initializes a new instance of the <see cref="SFC_WorkOrder"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="targetCompletionDate">The target completion date.</param>
        /// <param name="dueDate">The due date.</param>
        /// <param name="item">The item.</param>
        /// <param name="isReadyStart">if set to <c>true</c> [is ready start].</param>
        public SFC_WorkOrder(long id, SFC_Customer customer, DateTime? targetCompletionDate, DateTime dueDate, SFC_Item item, bool isReadyStart)
        {
            this.id = id;
            this.customer = customer;
            this.targetCompletionDate = targetCompletionDate;
            this.dueDate = dueDate;
            this.item = item;
            this.isReadyStart = isReadyStart;
            details = new SortedList<long, SFC_WorkOrderDetail>();
        }

        /// <summary>
        /// Adds the work order details.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="line">The line.</param>
        public void AddWorkOrderDetails(SFC_WorkOrderDetail line)
        {
            long key = line.OperationSequence;
            if (!details.ContainsKey(key))
            {
                details.Add(key, line);
            }
            else
            {
                details[key] = line;
            }
        }

        /// <summary>
        /// Removes the work order details.
        /// </summary>
        /// <param name="operationSequence">The key.</param>
        public void RemoveWorkOrderDetails(long operationSequence)
        {
            if (details.ContainsKey(operationSequence))
            {
                details.Remove(operationSequence);
            }
        }

        /// <summary>
        /// Gets the work order details.
        /// </summary>
        /// <param name="operationSequence">The key.</param>
        /// <returns></returns>
        public SFC_WorkOrderDetail GetWorkOrderDetails(long operationSequence)
        {
            if (details.ContainsKey(operationSequence))
            {
                return details[operationSequence];
            }
            else
            {
                return SFC_WorkOrderDetail.NONE;
            }
        }


        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id => id;

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public SFC_Customer Customer { get => customer; set => customer = value; }
        /// <summary>
        /// Gets or sets the target completion date.
        /// </summary>
        /// <value>
        /// The target completion date.
        /// </value>
        public DateTime? TargetCompletionDate { get => targetCompletionDate; set => targetCompletionDate = value; }
        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public SFC_Item Item { get => item; set => item = value; }

        /// <summary>
        /// Gets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public SortedList<long, SFC_WorkOrderDetail> Details => details;

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        public decimal? UnitPrice { get => unitPrice; set => unitPrice = value; }
        /// <summary>
        /// Gets or sets the estimated unit cost.
        /// </summary>
        /// <value>
        /// The estimated unit cost.
        /// </value>
        public decimal? EstimatedUnitCost { get => estimatedUnitCost; set => estimatedUnitCost = value; }
        /// <summary>
        /// Gets or sets the estimated total labor hours.
        /// </summary>
        /// <value>
        /// The estimated total labor hours.
        /// </value>
        public DateTime? EstimatedTotalLaborHours { get => estimatedTotalLaborHours; set => estimatedTotalLaborHours = value; }
        /// <summary>
        /// Gets or sets the estimated total labor cost.
        /// </summary>
        /// <value>
        /// The estimated total labor cost.
        /// </value>
        public decimal? EstimatedTotalLaborCost { get => estimatedTotalLaborCost; set => estimatedTotalLaborCost = value; }
        /// <summary>
        /// Gets or sets the estimated total material cost.
        /// </summary>
        /// <value>
        /// The estimated total material cost.
        /// </value>
        public decimal? EstimatedTotalMaterialCost { get => estimatedTotalMaterialCost; set => estimatedTotalMaterialCost = value; }
        /// <summary>
        /// Gets or sets the ordered build quantity.
        /// </summary>
        /// <value>
        /// The ordered build quantity.
        /// </value>
        public decimal? OrderedBuildQuantity { get => orderedBuildQuantity; set => orderedBuildQuantity = value; }
        /// <summary>
        /// Gets or sets the actual build quantity.
        /// </summary>
        /// <value>
        /// The actual build quantity.
        /// </value>
        public decimal? ActualBuildQuantity { get => actualBuildQuantity; set => actualBuildQuantity = value; }
        /// <summary>
        /// Gets or sets the actual unit cost.
        /// </summary>
        /// <value>
        /// The actual unit cost.
        /// </value>
        public decimal? ActualUnitCost { get => actualUnitCost; set => actualUnitCost = value; }
        /// <summary>
        /// Gets or sets the actual total labor hours.
        /// </summary>
        /// <value>
        /// The actual total labor hours.
        /// </value>
        public DateTime? ActualTotalLaborHours { get => actualTotalLaborHours; set => actualTotalLaborHours = value; }
        /// <summary>
        /// Gets or sets the actual total labor cost.
        /// </summary>
        /// <value>
        /// The actual total labor cost.
        /// </value>
        public decimal? ActualTotalLaborCost { get => actualTotalLaborCost; set => actualTotalLaborCost = value; }
        /// <summary>
        /// Gets or sets the actual total material cost.
        /// </summary>
        /// <value>
        /// The actual total material cost.
        /// </value>
        public decimal? ActualTotalMaterialCost { get => actualTotalMaterialCost; set => actualTotalMaterialCost = value; }
        /// <summary>
        /// Gets or sets the estimated profit.
        /// </summary>
        /// <value>
        /// The estimated profit.
        /// </value>
        public decimal? EstimatedProfit { get => estimatedProfit; set => estimatedProfit = value; }
        /// <summary>
        /// Gets or sets the scheduled start date.
        /// </summary>
        /// <value>
        /// The scheduled start date.
        /// </value>
        public DateTime? ScheduledStartDate { get => scheduledStartDate; set => scheduledStartDate = value; }
        /// <summary>
        /// Gets or sets the scheduled completion date.
        /// </summary>
        /// <value>
        /// The scheduled completion date.
        /// </value>
        public DateTime? ScheduledCompletionDate { get => scheduledCompletionDate; set => scheduledCompletionDate = value; }
    }
}
