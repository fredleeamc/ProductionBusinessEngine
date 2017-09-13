using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_WorkOrder
    {
        private readonly long id;

        private SFC_Customer customer;

        private DateTime targetCompletionDate;

        private DateTime dueDate;

        private SFC_Item item;

        private bool isReadyStart;

        public SFC_WorkOrder(long id, SFC_Customer customer, DateTime targetCompletionDate, DateTime dueDate, SFC_Item item, bool isReadyStart)
        {
            this.id = id;
            this.customer = customer;
            this.targetCompletionDate = targetCompletionDate;
            this.dueDate = dueDate;
            this.item = item;
            this.isReadyStart = isReadyStart;
        }

        public long Id => id;

        public SFC_Customer Customer { get => customer; set => customer = value; }
        public DateTime TargetCompletionDate { get => targetCompletionDate; set => targetCompletionDate = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public SFC_Item Item { get => item; set => item = value; }
    }
}
