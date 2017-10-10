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
    public class SFC_MachineType
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly int id;

        /// <summary>
        /// The name
        /// </summary>
        private String name;

        /// <summary>
        /// The type library
        /// </summary>
        private static Dictionary<SFC_MachineType, List<SFC_WorkCenter>> typeLib = new Dictionary<SFC_MachineType, List<SFC_WorkCenter>>();

        /// <summary>
        /// The none
        /// </summary>
        public readonly static SFC_MachineType NONE = new SFC_MachineType(0, "NONE");

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_MachineType"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public SFC_MachineType(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return name;
            }

            protected set
            {
                name = value;
            }
        }

        /// <summary>
        /// Adds the work center.
        /// </summary>
        /// <param name="mType">Type of the m.</param>
        /// <param name="wc">The wc.</param>
        public static void AddWorkCenter(SFC_MachineType mType, SFC_WorkCenter wc)
        {
            if (typeLib.TryGetValue(mType, out List<SFC_WorkCenter> wcs))
            {
                wcs.Add(wc);
            }
            //if(typeLib.ContainsKey(mType))
            //{
            //    if (typeLib[mType] != null)
            //        typeLib[mType].Add(wc);
            //    else
            //    {
            //        typeLib[mType] = new List<SFC_WorkCenter>();
            //        typeLib[mType].Add(wc);
            //    }
            //}
            else
            {
                List<SFC_WorkCenter> nlist = new List<SFC_WorkCenter>();
                nlist.Add(wc);
                typeLib.Add(mType, nlist);
            }
        }

        /// <summary>
        /// Removes the work center.
        /// </summary>
        /// <param name="wc">The wc.</param>
        public static void RemoveWorkCenter(SFC_WorkCenter wc)
        {
            if (typeLib.TryGetValue(wc.MachineType, out List<SFC_WorkCenter> wcs))
            {
                wcs.Remove(wc);
            }
            //SFC_MachineType mType = wc.MachineType;
            //if (typeLib.ContainsKey(mType))
            //{
            //    if (typeLib[mType] != null)
            //    if (typeLib[mType].Contains(wc))
            //    {
            //            typeLib[mType].Remove(wc);
            //    }
            //}
            else
            {
                List<SFC_WorkCenter> nlist = new List<SFC_WorkCenter>();
                nlist.Add(wc);
                typeLib.Add(wc.MachineType, nlist);
            }
        }

        /// <summary>
        /// Gets the work centers.
        /// </summary>
        /// <param name="mType">Type of the m.</param>
        /// <returns></returns>
        public static List<SFC_WorkCenter> GetWorkCenters(SFC_MachineType mType)
        {
            //if (typeLib.ContainsKey(mType))
            //{
            //    return typeLib[mType];
            //} else
            //{
            //    return new List<SFC_WorkCenter>();
            //}
            return typeLib.TryGetValue(mType, out List<SFC_WorkCenter> wcs) ? wcs : null;
        }

        /// <summary>
        /// Gets the random work center.
        /// </summary>
        /// <param name="mType">Type of the m.</param>
        /// <returns></returns>
        public static SFC_WorkCenter GetRandomWorkCenter(SFC_MachineType mType)
        {
            if (typeLib.TryGetValue(mType, out List<SFC_WorkCenter> wcs))
            {
                return wcs[TextGenerator.GetRandom().Next(0, wcs.Count)];
            }
            //if (typeLib.ContainsKey(mType))
            //{
            //    //TextGenerator.GetRandom().Next(0, typeLib[mType].Count);
            //    return typeLib[mType][TextGenerator.GetRandom().Next(0, typeLib[mType].Count)];
            //}
            else
            {
                return SFC_WorkCenter.NONE;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return name;
        }

    }
}
