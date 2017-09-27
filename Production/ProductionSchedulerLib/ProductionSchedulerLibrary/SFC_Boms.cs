using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_Boms
    {
        /// <summary>
        /// The boms
        /// </summary>
        private readonly Dictionary<long, SFC_Bom> lists;

        public SFC_Boms()
        {
            lists = new Dictionary<long, SFC_Bom>();
        }

        /// <summary>
        /// Gets the lists.
        /// </summary>
        /// <value>
        /// The lists.
        /// </value>
        public Dictionary<long, SFC_Bom> Lists => lists;

        public long Count { get => lists.Count; }


        /// <summary>
        /// Adds the bom.
        /// </summary>
        /// <param name="bom">The bom.</param>
        public void Add(SFC_Bom bom)
        {
            Lists.Add(bom.Id, bom);
        }

        /// <summary>
        /// Removes the bom.
        /// </summary>
        /// <param name="bom">The bom.</param>
        public void Remove(SFC_Bom bom)
        {
            Lists.Remove(bom.Id);
        }

        /// <summary>
        /// Shows the boms.
        /// </summary>
        public void ShowList()
        {
            foreach (long bomId in Lists.Keys)
            {
                Console.WriteLine(Lists[bomId]);
            }
        }

        /// <summary>
        /// Gets the random bom.
        /// </summary>
        /// <returns></returns>
        public SFC_Bom GetRandom()
        {
            int rand = TextGenerator.getRandom().Next(1, Lists.Count + 1);
            return Lists[rand];
        }

    }
}
