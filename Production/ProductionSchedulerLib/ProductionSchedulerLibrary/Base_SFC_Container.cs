using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class Base_SFC_Container<T>
    {
        /// <summary>
        /// The objs
        /// </summary>
        private readonly Dictionary<long, T> lists;
        ShopFloorModel model;
        
        public Base_SFC_Container()
        {
            lists = new Dictionary<long, T>();
        }

        public Dictionary<long, T>.KeyCollection Keys { get => lists.Keys; }

        /// <summary>
        /// Gets the lists.
        /// </summary>
        /// <value>
        /// The lists.
        /// </value>
        public Dictionary<long, T> Lists => lists;

        public long Count { get => lists.Count; }

        public long Next { get => Count + 1; }
        public ShopFloorModel Model { get => model; set => model = value; }


        /// <summary>
        /// Adds the obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Add(long id, T obj)
        {
            Lists.Add(id, obj);
        }

        public void Add(T obj)
        {
            Lists.Add(Next, obj);
        }

        /// <summary>
        /// Removes the obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Remove(long id)
        {
            Lists.Remove(id);
        }

        /// <summary>
        /// Shows the objs.
        /// </summary>
        public void Print()
        {
            foreach (long id in Lists.Keys)
            {
                Console.WriteLine(Lists[id]);
            }
        }

        public T Get(long index)
        {
            //if (Lists.TryGetValue(index, out T o))
            //{
            //    return o;
            //}
            ////if (Lists.ContainsKey(index))
            ////    return Lists[index];
            //else
            //    return default(T);

            return Lists.TryGetValue(index, out T o) ? o: default(T);
        }

        /// <summary>
        /// Gets the random obj.
        /// </summary>
        /// <returns></returns>
        public T GetRandom()
        {
            int count = Lists.Count;
            if (count == 1)
                return Lists[1];
            else if (count > 1)
            {
                int rand = TextGenerator.GetRandom().Next(1, count + 1);
                return Lists[rand];
            }
            else
            {
                return default(T);
            }
        }
    }


}
