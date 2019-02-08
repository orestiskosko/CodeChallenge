using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repos.Interfaces
{
    public interface IGenericRepo<T1, T2> where T1:class
    {
        IEnumerable<T1> GetAll(bool joinAll = false);
        T1 GetById(T2 id, bool joinAll = false);
        void Insert(T1 obj);
        void Update(T1 obj);
        void Delete(T1 obj);
        void DeleteMultiple(IEnumerable<T1> obj);
    }
}
