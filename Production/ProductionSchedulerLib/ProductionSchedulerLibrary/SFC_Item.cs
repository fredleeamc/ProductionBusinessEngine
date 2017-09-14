using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_Item : IEquatable<SFC_Item>, IComparable<SFC_Item>
    {
        private readonly long id;

        private readonly String itemCode;

        private readonly SFC_ItemStatus itemStatus;

        private readonly List<SFC_ItemLotBin> bins;

        private bool isBom;

        private SFC_BomComposite bom;


        public bool IsBom { get => isBom; }

        public SFC_BomComposite Bom { get => bom; }

        public long Id => id;

        public string ItemCode => itemCode;

        public SFC_ItemStatus ItemStatus => itemStatus;

        public List<SFC_ItemLotBin> Bins => bins;

        public SFC_Item(long id, string itemCode)
        {
            this.id = id;
            this.itemCode = itemCode;
            this.itemStatus = new SFC_ItemStatus(this);
            this.bins = new List<SFC_ItemLotBin>();
            this.isBom = false;
            this.bom = null;
        }

        public void SetBom(SFC_BomComposite bom)
        {
            this.isBom = true;
            this.bom = bom;
        }

        public bool addLotBin(SFC_ItemLotBin bin)
        {
            if (!bins.Contains(bin))
            {
                bins.Add(bin);
                return true;
            }
            else
                return false;
        }




        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id + "," + itemCode + ":");
            //sb.Append(String.Format("{0, 40}|{1,10}|<{2,10}|{3,10}|{4,10}>|<{5,10}|{6,10}|{7, 10}|{8,10}>|{9,10}|{10,10}|{11,10}|{12,10}|{13,10}\n",
            //    "Begin","Receive", "On Hand", "PO", "Used", "Production", "Allocated", "Reserved", "Available", "Required", "Scrap", "Returns", "Adjust In", "Adjust Out"));
            //sb.Append(String.Format("{0,29}:", "Total") + itemStatus +"\n");
            //foreach (SFC_ItemLotBin bin in this.bins)
            //{
            //    sb.Append(String.Format("{0,29}:",bin) + bin.ItemStatus+"\n");
            //}
            return sb.ToString();
        }

        public string PrintStatus()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id + "," + itemCode + ":\n");
            sb.Append(String.Format("{0, 40}|{1,10}|<{2,10}|{3,10}|{4,10}>|<{5,10}|{6,10}|{7, 10}|{8,10}>|{9,10}|{10,10}|{11,10}|{12,10}|{13,10}\n",
                "Begin", "Receive", "On Hand", "PO", "Used", "Production", "Allocated", "Reserved", "Available", "Required", "Scrap", "Returns", "Adjust In", "Adjust Out"));
            sb.Append(String.Format("{0,29}:", "Total") + itemStatus + "\n");
            foreach (SFC_ItemLotBin bin in this.bins)
            {
                sb.Append(String.Format("{0,29}:", bin) + bin.ItemStatus + "\n");
            }
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SFC_Item);
        }

        public bool Equals(SFC_Item other)
        {
            return other != null &&
                   itemCode == other.itemCode;
        }

        public override int GetHashCode()
        {
            var hashCode = 1763693883;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(itemCode);
            return hashCode;
        }

        int IComparable<SFC_Item>.CompareTo(SFC_Item other)
        {
            return this.CompareTo(other);

        }

        public int CompareTo(SFC_Item other)
        {

            if (other == null)
                return 1;

            SFC_Item otherItem = other as SFC_Item;
            if (otherItem != null)
            {
                if (this.id == other.id)
                    return this.itemCode.CompareTo(otherItem.itemCode);
                else
                    return this.id.CompareTo(other.Id);
            }
            else
                throw new ArgumentException("Object is not a SFC_Item");
        }

        public static bool operator ==(SFC_Item item1, SFC_Item item2)
        {
            return EqualityComparer<SFC_Item>.Default.Equals(item1, item2);
        }

        public static bool operator !=(SFC_Item item1, SFC_Item item2)
        {
            return !(item1 == item2);
        }

        // Define the is greater than operator.
        public static bool operator >(SFC_Item operand1, SFC_Item operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }

        // Define the is less than operator.
        public static bool operator <(SFC_Item operand1, SFC_Item operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }

        // Define the is greater than or equal to operator.
        public static bool operator >=(SFC_Item operand1, SFC_Item operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        // Define the is less than or equal to operator.
        public static bool operator <=(SFC_Item operand1, SFC_Item operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

    }
}
