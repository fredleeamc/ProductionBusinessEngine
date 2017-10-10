using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public  class SFC_Currency
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly long id;
        /// <summary>
        /// The name
        /// </summary>
        private readonly string name;
        /// <summary>
        /// The symbol
        /// </summary>
        private readonly string symbol;

        private List<SFC_CurrencyExchange> exchanges;


        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Currency"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="symbol">The symbol.</param>
        public  SFC_Currency(long id, string name, string symbol)
        {
            this.id = id;
            this.name = name;
            this.symbol = symbol;
            exchanges = new List<SFC_CurrencyExchange>();        
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public  long Id => id;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public  string Name => name;

        /// <summary>
        /// Gets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        public  string Symbol => symbol;

        public List<SFC_CurrencyExchange> Exchanges { get => exchanges; }

        public override string ToString()
        {
            return this.symbol + " " + this.name;
        }

        public SFC_CurrencyExchange GetLatestExchange(SFC_Currency targetCurrency)
        {
            var eList = from f in Exchanges
                        where f.TargetCurrency == targetCurrency                 
                        select f;
            var s = from e in eList
                    where e.EffectiveDate == eList.Max(x => x.EffectiveDate)
                    select e;
            return s.First();
        }

        public SFC_CurrencyExchange GetExchange(SFC_Currency targetCurrency, DateTime refDate)
        {
            var eList = from f in Exchanges
                        where f.TargetCurrency == targetCurrency &&
                        f.EffectiveDate == refDate
                        select f;

            return eList.First();
        }

        public void AddExchange(SFC_CurrencyExchange currencyExchange)
        {
            Exchanges.Add(currencyExchange);
        }

        public void RemoveExchange(SFC_CurrencyExchange currencyExchange)
        {
            Exchanges.Remove(currencyExchange);
        }
    }
}
