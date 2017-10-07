using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_CurrencyExchanges : SFC_Container<SFC_CurrencyExchange>
    {
        public SFC_CurrencyExchanges() : base()
        {
        }

        public decimal GetSellingRate(DateTime referenceDate, SFC_Currency targetCurrency)
        {
            double timeDiff = Double.MaxValue;
            SFC_CurrencyExchange exchange = null;
            foreach (long k in Lists.Keys)
            {
                SFC_CurrencyExchange x1 = this.Lists[k];
                TimeSpan sp1 = x1.EffectiveDate.Subtract(referenceDate).Duration();
                if (sp1.TotalSeconds <= timeDiff)
                {
                    timeDiff = sp1.TotalSeconds;
                    exchange = x1;
                }
            }

            if (exchange != null)
                return exchange.SellingRate;
            else
                throw new ArgumentNullException("Exchange rate not found.");
        }

    }
}
