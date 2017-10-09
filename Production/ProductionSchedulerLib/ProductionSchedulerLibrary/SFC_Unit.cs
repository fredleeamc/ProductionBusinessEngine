using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public  class SFC_Unit : IEquatable<SFC_Unit>
    {
        private readonly long id;
        private readonly string unitCategory;
        private readonly string unitVal;
        private readonly string description;


        public  SFC_Unit(long id, string unitCategory, string unitVal, string description)
        {
            this.id = id;
            this.unitCategory = unitCategory;
            this.unitVal = unitVal;
            this.description = description;
        }


        public  long Id => id;

        public  String UnitCategory => unitCategory;

        public  string UnitVal => unitVal;

        public  string Description => description;

        bool IEquatable<SFC_Unit>.Equals(SFC_Unit other)
        {
            return this.Equals(other);
        }

        public  bool Equals(SFC_Unit other)
        {
            return other != null && this.UnitCategory.Equals(other.UnitCategory) && this.UnitVal.Equals(other.UnitVal);
        }

        public  bool Convertible(SFC_Unit other)
        {
            return other != null && this.UnitCategory.Equals(other.UnitCategory);
        }
    }


}
