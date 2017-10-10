using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_CurrencyExchanges
    {
        ShopFloorModel model;

        public SFC_CurrencyExchanges()
        {

        }

        public ShopFloorModel Model { get => model; set => model = value; }

        public void Add(long currencyId, SFC_CurrencyExchange exchange)
        {
            SFC_Currency currency = Model.Currencies.Get(currencyId);
            currency.AddExchange(exchange);
        }

        public void Remove(long currencyId, SFC_CurrencyExchange exchange)
        {
            SFC_Currency currency = Model.Currencies.Get(currencyId);
            currency.RemoveExchange(exchange);
        }

        public List<SFC_CurrencyExchange> Get(long currencyId)
        {
            return Model.Currencies.Get(currencyId).Exchanges;
        }

        public SFC_CurrencyExchange GetRandom(SFC_Currency sourceCurrency, SFC_Currency targetCurrency)
        {
            SFC_Currency currency = Model.Currencies.Get(sourceCurrency.Id);
            int count = currency.Exchanges.Count;
            if (count == 1)
                return currency.Exchanges[1];
            else if (count > 1)
            {
                var eList = from f in currency.Exchanges
                            where f.TargetCurrency == targetCurrency
                            select f;
                int rand = TextGenerator.GetRandom().Next(1, eList.Count() + 1);

                SFC_CurrencyExchange[] a = eList.ToArray<SFC_CurrencyExchange>();
                return a[rand];
            }
            else
            {
                return default(SFC_CurrencyExchange);
            }

        }


    }
}
