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
    public class SFC_Machine : IEquatable<SFC_Machine>, IComparable<SFC_Machine>
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;

        /// <summary>
        /// The machine type
        /// </summary>
        private readonly SFC_MachineType machineType;

        /// <summary>
        /// The machine name
        /// </summary>
        private readonly String machineName;

        /// <summary>
        /// The work center
        /// </summary>
        private SFC_WorkCenter workCenter;

        /// <summary>
        /// The none
        /// </summary>
        public readonly static SFC_Machine NONE = new SFC_Machine(0, "NONE", SFC_MachineType.NONE);

        public long Id => id;

        public SFC_MachineType MachineType => machineType;

        public string MachineName => machineName;

        public SFC_WorkCenter WorkCenter { get => workCenter; set => workCenter = value; }



        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Machine"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="machineName">Name of the machine.</param>
        /// <param name="machineTypeId">The machine type identifier.</param>
        public SFC_Machine(long id, string machineName, SFC_MachineType machineTypeId)
        {
            this.id = id;
            this.machineType = machineTypeId;
            this.machineName = machineName;
            this.workCenter = SFC_WorkCenter.NONE;
        }

        /// <summary>
        /// Sets the work center.
        /// </summary>
        /// <param name="wc">The wc.</param>
        /// <returns></returns>
        public bool setWorkCenter(SFC_WorkCenter wc)
        {
            bool result = false;
            if (wc != null)
            {
                if (!wc.isCompatible(this))
                {
                    this.WorkCenter = SFC_WorkCenter.NONE;
                    result = false;
                }
                else
                {
                    this.WorkCenter = wc;
                    result = true;
                }
            }
            return result;
        }



        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return id + " " + machineType + "." + machineName + "  [" + workCenter + "]";

        }

        public bool Equals(SFC_Machine other)
        {
            return other != null && this.machineName == other.machineName;
        }

        public int CompareTo(SFC_Machine other)
        {
            if (other == null)
                return 1;

            SFC_Machine otherItem = other as SFC_Machine;
            if (otherItem != null)
            {
                if (this.id == other.id)
                    return this.machineName.CompareTo(otherItem.machineName);
                else
                    return this.id.CompareTo(other.Id);
            }
            else
                throw new ArgumentException("Object is not a SFC_Machine");
        }
    }
}
