using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_BTG_CRUD_Cliente.Data.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Update(T obj);
        void Insert(T obj);
        void InsertOrReplace(T obj);
        void Delete(T obj);
        T GetById(Guid id);
        List<T> GetAll();
        void DeleteAll();
    }
}
