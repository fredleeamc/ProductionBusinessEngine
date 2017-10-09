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
    /// <seealso cref="System.IEquatable{ProductionSchedulerLibrary.SFC_Item}" />
    /// <seealso cref="System.IComparable{ProductionSchedulerLibrary.SFC_Item}" />
    public   class SFC_Item : IEquatable<SFC_Item>, IComparable<SFC_Item>
    {

        private readonly long id;
        private readonly String itemCode;
        private readonly SFC_ItemStatus itemStatus;
        private readonly List<SFC_ItemLotBin> bins;
        private bool isBom;
        private SFC_BomComposite bom;
        private string revision;
        private decimal? actualCost;
        private decimal? lastCost;
        private decimal? materialCost;
        private decimal? laborCost;
        private decimal? overheadCost;
        private bool inactive;
        private long stockingUnitId;
        private bool isSold;
        private bool isBought;
        private bool isMfgComponent;
        private bool isMfgConsumable;
        private bool isObsolete;
        private string shortDescription;
        private bool isService;
        private SFC_Currency currency;
        private SFC_CurrencyExchange currencyExchange;


        /// <summary>
        /// Gets a value indicating whether this instance is bom.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is bom; otherwise, <c>false</c>.
        /// </value>
        public  bool IsBom { get => isBom; }

        /// <summary>
        /// Gets the bom.
        /// </summary>
        /// <value>
        /// The bom.
        /// </value>
        public  SFC_BomComposite Bom { get => bom; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public  long Id => id;

        /// <summary>
        /// Gets the item code.
        /// </summary>
        /// <value>
        /// The item code.
        /// </value>
        public  string ItemCode => itemCode;

        /// <summary>
        /// Gets the item status.
        /// </summary>
        /// <value>
        /// The item status.
        /// </value>
        public  SFC_ItemStatus ItemStatus => itemStatus;

        /// <summary>
        /// Gets the bins.
        /// </summary>
        /// <value>
        /// The bins.
        /// </value>
        public  List<SFC_ItemLotBin> Bins => bins;


        public  string Revision { get => revision; set => revision = value; }
        public  decimal? ActualCost { get => actualCost; set => actualCost = value; }
        public  decimal? LastCost { get => lastCost; set => lastCost = value; }
        public  decimal? MaterialCost { get => materialCost; set => materialCost = value; }
        public  decimal? LaborCost { get => laborCost; set => laborCost = value; }
        public  decimal? OverheadCost { get => overheadCost; set => overheadCost = value; }
        public  bool Inactive { get => inactive; set => inactive = value; }
        public  long StockingUnitId { get => stockingUnitId; set => stockingUnitId = value; }
        public  bool IsSold { get => isSold; set => isSold = value; }
        public  bool IsBought { get => isBought; set => isBought = value; }
        public  bool IsMfgComponent { get => isMfgComponent; set => isMfgComponent = value; }
        public  bool IsMfgConsumable { get => isMfgConsumable; set => isMfgConsumable = value; }
        public  bool IsObsolete { get => isObsolete; set => isObsolete = value; }
        public  string ShortDescription { get => shortDescription; set => shortDescription = value; }
        public  bool IsService { get => isService; set => isService = value; }
        public SFC_Currency Currency { get => currency; set => currency = value; }
        public SFC_CurrencyExchange CurrencyExchange { get => currencyExchange; set => currencyExchange = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Item"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="itemCode">The item code.</param>
        public  SFC_Item(long id, string itemCode)
        {
            this.id = id;
            this.itemCode = itemCode;
            this.itemStatus = new SFC_ItemStatus(this);
            this.bins = new List<SFC_ItemLotBin>();
            this.isBom = false;
            this.bom = null;
        }

        /// <summary>
        /// Sets the bom.
        /// </summary>
        /// <param name="bom">The bom.</param>
        public  void SetBom(SFC_BomComposite bom)
        {
            this.isBom = true;
            this.bom = bom;
        }

        /// <summary>
        /// Adds the lot bin.
        /// </summary>
        /// <param name="bin">The bin.</param>
        /// <returns></returns>
        public  bool addLotBin(SFC_ItemLotBin bin)
        {
            if (!bins.Contains(bin))
            {
                bins.Add(bin);
                return true;
            }
            else
                return false;
        }




        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public  override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(id + "," + itemCode);
            //sb.Append(String.Format("{0, 40}|{1,10}|<{2,10}|{3,10}|{4,10}>|<{5,10}|{6,10}|{7, 10}|{8,10}>|{9,10}|{10,10}|{11,10}|{12,10}|{13,10}\n",
            //    "Begin","Receive", "On Hand", "PO", "Used", "Production", "Allocated", "Reserved", "Available", "Required", "Scrap", "Returns", "Adjust In", "Adjust Out"));
            //sb.Append(String.Format("{0,29}:", "Total") + itemStatus +"\n");
            //foreach (SFC_ItemLotBin bin in this.bins)
            //{
            //    sb.Append(String.Format("{0,29}:",bin) + bin.ItemStatus+"\n");
            //}
            return sb.ToString();
        }

        /// <summary>
        /// Prints the status.
        /// </summary>
        /// <returns></returns>
        public  string PrintStatus()
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

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public  override bool Equals(object obj)
        {
            return Equals(obj as SFC_Item);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public  bool Equals(SFC_Item other)
        {
            return other != null &&
                   itemCode == other.itemCode;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public  override int GetHashCode()
        {
            var hashCode = 1763693883;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(itemCode);
            return hashCode;
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other" /> parameter.Zero This object is equal to <paramref name="other" />. Greater than zero This object is greater than <paramref name="other" />.
        /// </returns>
        int IComparable<SFC_Item>.CompareTo(SFC_Item other)
        {
            return this.CompareTo(other);

        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other" /> parameter.Zero This object is equal to <paramref name="other" />. Greater than zero This object is greater than <paramref name="other" />.
        /// </returns>
        /// <exception cref="ArgumentException">Object is not a SFC_Item</exception>
        public  int CompareTo(SFC_Item other)
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

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public  static bool operator ==(SFC_Item item1, SFC_Item item2)
        {
            return EqualityComparer<SFC_Item>.Default.Equals(item1, item2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public  static bool operator !=(SFC_Item item1, SFC_Item item2)
        {
            return !(item1 == item2);
        }

        // Define the is greater than operator.
        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="operand1">The operand1.</param>
        /// <param name="operand2">The operand2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public  static bool operator >(SFC_Item operand1, SFC_Item operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }

        // Define the is less than operator.
        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="operand1">The operand1.</param>
        /// <param name="operand2">The operand2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public  static bool operator <(SFC_Item operand1, SFC_Item operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }

        // Define the is greater than or equal to operator.
        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="operand1">The operand1.</param>
        /// <param name="operand2">The operand2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public  static bool operator >=(SFC_Item operand1, SFC_Item operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        // Define the is less than or equal to operator.
        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="operand1">The operand1.</param>
        /// <param name="operand2">The operand2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public  static bool operator <=(SFC_Item operand1, SFC_Item operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

    }
}
