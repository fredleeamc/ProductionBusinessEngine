using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_CompanySettings
    {
        SFC_Currency defaultCurrency;
        bool isMultiCurrency;

        public SFC_CompanySettings()
        {
           
        }

        public bool IsMultiCurrency { get => isMultiCurrency; set => isMultiCurrency = value; }
        public SFC_Currency DefaultCurrency { get => defaultCurrency; set => defaultCurrency = value; }
    }
}
