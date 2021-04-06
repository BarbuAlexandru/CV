using System;
using System.Collections.Generic;
using System.Text;

namespace AirWAD.Repository.Abstraction
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid Id);
        T Add(T itemToAdd);
        T Update(T itemToUpdate);
        bool Delete(T itemToDelete);
    }
}