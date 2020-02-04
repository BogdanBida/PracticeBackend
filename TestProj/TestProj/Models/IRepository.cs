using System.Collections.Generic;

namespace TestProj.Models
{
    interface IRepository<T>
        where T : class
    {
        T GetItem(int id);
        IEnumerable<T> GetItemList();
        T Create(T item); 
        T Update(T item);
        T Delete(int id);
    }
}
