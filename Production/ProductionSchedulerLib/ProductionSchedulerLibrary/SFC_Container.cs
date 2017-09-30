using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class SFC_Container<T>
    {
        /// <summary>
        /// The boms
        /// </summary>
        private readonly Dictionary<long, T> lists;

        public SFC_Container()
        {
            lists = new Dictionary<long, T>();           
        }

        private Dictionary<long, T>.KeyCollection keys;

        public Dictionary<long, T>.KeyCollection Keys { get => keys; }

        /// <summary>
        /// Gets the lists.
        /// </summary>
        /// <value>
        /// The lists.
        /// </value>
        public Dictionary<long, T> Lists => lists;

        public long Count { get => lists.Count; }

        public long Next { get => Count + 1; }

        /// <summary>
        /// Adds the bom.
        /// </summary>
        /// <param name="bom">The bom.</param>
        public void Add(long id, T bom)
        {

            Lists.Add(id, bom);
        }


        public void Add(T bom)
        {
            Lists.Add(Next, bom);
        }

        /// <summary>
        /// Removes the bom.
        /// </summary>
        /// <param name="bom">The bom.</param>
        public void Remove(long id)
        {
            Lists.Remove(id);
        }

        /// <summary>
        /// Shows the boms.
        /// </summary>
        public void Print()
        {
            foreach (long id in Lists.Keys)
            {
                Console.WriteLine(Lists[id]);
            }
        }

        /// <summary>
        /// Gets the random bom.
        /// </summary>
        /// <returns></returns>
        public T GetRandom()
        {
            long count = Lists.Count;
            if (count == 1)
                return Lists[1];
            else if (count > 1)
            {
                int rand = TextGenerator.GetRandom().Next(1, Lists.Count + 1);
                return Lists[rand];
            } else
            {
                return default(T);
            }
        }
    }


}
