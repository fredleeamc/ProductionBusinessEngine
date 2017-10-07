using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_Currency
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

        /// <summary>
        /// Initializes a new instance of the <see cref="SFC_Currency"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="symbol">The symbol.</param>
        public SFC_Currency(long id, string name, string symbol)
        {
            this.id = id;
            this.name = name;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id => id;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => name;

        /// <summary>
        /// Gets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        public string Symbol => symbol;
    }
}
