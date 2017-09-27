using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;

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
        private DateTime targetCompletionDate;

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

        private readonly SortedList<long, SFC_WorkOrderDetails> details;

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_WorkOrder"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="targetCompletionDate">The target completion date.</param>
        /// <param name="dueDate">The due date.</param>
        /// <param name="item">The item.</param>
        /// <param name="isReadyStart">if set to <c>true</c> [is ready start].</param>
        public SFC_WorkOrder(long id, SFC_Customer customer, DateTime targetCompletionDate, DateTime dueDate, SFC_Item item, bool isReadyStart)
        {
            this.id = id;
            this.customer = customer;
            this.targetCompletionDate = targetCompletionDate;
            this.dueDate = dueDate;
            this.item = item;
            this.isReadyStart = isReadyStart;
            details = new SortedList<long, SFC_WorkOrderDetails>();
        }

        public void AddWorkOrderDetails(long key, SFC_WorkOrderDetails line)
        {
            if (!details.ContainsKey(key))
            {
                details.Add(key, line);
            } else
            {
                details[key] = line;
            }
        }

        public void RemoveWorkOrderDetails(long key)
        {
            if (details.ContainsKey(key))
            {
                details.Remove(key);
            }
        }

        public SFC_WorkOrderDetails GetWorkOrderDetails(long key)
        {
            if (details.ContainsKey(key))
            {
                return details[key];
            } else
            {
                return SFC_WorkOrderDetails.NONE;
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
        public DateTime TargetCompletionDate { get => targetCompletionDate; set => targetCompletionDate = value; }
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

        public SortedList<long, SFC_WorkOrderDetails> Details => details;
    }
}
