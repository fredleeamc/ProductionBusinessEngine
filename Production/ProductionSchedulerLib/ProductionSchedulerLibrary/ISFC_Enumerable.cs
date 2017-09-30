using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public interface ISFC_Enumerable<T>
    {
        void Add(T item);
        void Remove(T item);
        void Show();
        T GetRandom();
    }
}
