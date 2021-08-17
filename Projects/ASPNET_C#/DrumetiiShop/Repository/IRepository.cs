using System;
using System.Collections.Generic;
using System.Text;

namespace DrumetiiShop.Repository
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