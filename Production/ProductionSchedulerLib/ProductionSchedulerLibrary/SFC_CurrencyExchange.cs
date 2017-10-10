using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_CurrencyExchange
    {
        private readonly long id;
        private readonly SFC_Currency sourceCurrency;
        private readonly SFC_Currency targetCurrency;
        private decimal sellingRate;
        private decimal buyingRate;
        private System.DateTime effectiveDate;

        public SFC_CurrencyExchange(long id, SFC_Currency sourceCurrency, SFC_Currency targetCurrency, DateTime effectiveDate, decimal buyingRate, decimal sellingRate)
        {
            this.id = id;
            this.sourceCurrency = sourceCurrency;
            this.targetCurrency = targetCurrency;
            this.effectiveDate = effectiveDate;
            this.buyingRate = buyingRate;
            this.sellingRate = sellingRate;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id => id;

        /// <summary>
        /// Gets the source currency.
        /// </summary>
        /// <value>
        /// The source currency.
        /// </value>
        public SFC_Currency SourceCurrency => sourceCurrency;

        /// <summary>
        /// Gets the target currency.
        /// </summary>
        /// <value>
        /// The target currency.
        /// </value>
        public SFC_Currency TargetCurrency => targetCurrency;

        /// <summary>
        /// Gets or sets the selling rate.
        /// </summary>
        /// <value>
        /// The bank selling rate.
        /// </value>
        public decimal SellingRate { get => sellingRate; set => sellingRate = value; }
        /// <summary>
        /// Gets or sets the buying rate.
        /// </summary>
        /// <value>
        /// The bank buying rate.
        /// </value>
        public decimal BuyingRate { get => buyingRate; set => buyingRate = value; }
        /// <summary>
        /// Gets or sets the effective date.
        /// </summary>
        /// <value>
        /// The effective date.
        /// </value>
        public DateTime EffectiveDate { get => effectiveDate; set => effectiveDate = value; }

        public override string ToString()
        {
            return sourceCurrency + "->" + "(" + sellingRate + ":" + buyingRate + ")" + "->" + targetCurrency;
        }
    }
}
