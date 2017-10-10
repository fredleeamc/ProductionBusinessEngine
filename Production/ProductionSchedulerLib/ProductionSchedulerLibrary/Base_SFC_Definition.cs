using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class Base_SFC_Definition<T>
    {
        /// <summary>
        /// The objs
        /// </summary>
        private readonly Dictionary<string, T> lists;
        ShopFloorModel model;


        public Base_SFC_Definition()
        {
            lists = new Dictionary<string, T>();
        }

        public Dictionary<string, T>.KeyCollection Keys { get => lists.Keys; }

        /// <summary>
        /// Gets the lists.
        /// </summary>
        /// <value>
        /// The lists.
        /// </value>
        public Dictionary<string, T> Lists => lists;

        public long Count { get => lists.Count; }

        public long Next { get => Count + 1; }
        public ShopFloorModel Model { get => model; set => model = value; }


        /// <summary>
        /// Adds the obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Add(string id, T obj)
        {

            Lists.Add(id, obj);
        }

        /// <summary>
        /// Removes the obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Remove(string id)
        {
            Lists.Remove(id);
        }

        /// <summary>
        /// Shows the objs.
        /// </summary>
        public void Print()
        {
            foreach (string id in Lists.Keys)
            {
                Console.WriteLine(Lists[id]);
            }
        }

        public T Get(string index)
        {
            //if (Lists.ContainsKey(index))
            //    return Lists[index];
            //else
            //    return default(T);
            return Lists.TryGetValue(index, out T o) ? o : default(T);
        }

        /// <summary>
        /// Gets the random obj.
        /// </summary>
        /// <returns></returns>
        public T GetRandom()
        {
            T[] values = new T[Lists.Count];
            Lists.Values.CopyTo(values, 0);

            int count = values.Length;
            if (count == 1)
                return values[1];
            else if (count > 1)
            {
                int rand = TextGenerator.GetRandom().Next(1, count + 1);
                return values[rand];
            }
            else
            {
                return default(T);
            }
        }
    }


}



