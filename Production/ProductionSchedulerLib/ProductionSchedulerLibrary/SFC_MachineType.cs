using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_MachineType
    {
        private readonly int id;

        private String name;

        private static Dictionary<SFC_MachineType, List<SFC_WorkCenter>> typeLib = new Dictionary<SFC_MachineType, List<SFC_WorkCenter>>();

        public readonly static SFC_MachineType NONE = new SFC_MachineType(0, "NONE");

        public SFC_MachineType(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

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

        public static void AddWorkCenter(SFC_MachineType mType, SFC_WorkCenter wc)
        {
            if(typeLib.ContainsKey(mType))
            {
                if (typeLib[mType] != null)
                    typeLib[mType].Add(wc);
                else
                {
                    typeLib[mType] = new List<SFC_WorkCenter>();
                    typeLib[mType].Add(wc);
                }
            } else
            {
                List<SFC_WorkCenter> nlist = new List<SFC_WorkCenter>();
                nlist.Add(wc);
                typeLib.Add(mType, nlist);
            }
        }

        public static void RemoveWorkCenter(SFC_WorkCenter wc)
        {
            SFC_MachineType mType = wc.MachineType;
            if (typeLib.ContainsKey(mType))
            {
                if (typeLib[mType] != null)
                if (typeLib[mType].Contains(wc))
                {
                        typeLib[mType].Remove(wc);
                }
            }
            else
            {
                List<SFC_WorkCenter> nlist = new List<SFC_WorkCenter>();
                nlist.Add(wc);
                typeLib.Add(mType, nlist);
            }
        }

        public static List<SFC_WorkCenter> GetWorkCenters(SFC_MachineType mType)
        {
            if (typeLib.ContainsKey(mType))
            {
                return typeLib[mType];
            } else
            {
                return new List<SFC_WorkCenter>();
            }
        }

        public static SFC_WorkCenter GetRandomWorkCenter(SFC_MachineType mType)
        {
            if (typeLib.ContainsKey(mType))
            {
                TextGenerator.getRandom().Next(0, typeLib[mType].Count);
                return typeLib[mType][TextGenerator.getRandom().Next(0, typeLib[mType].Count)];
            }
            else
            {
                return SFC_WorkCenter.NONE;
            }
        }

        public override string ToString()
        {
            return name;
        }

    }
}
