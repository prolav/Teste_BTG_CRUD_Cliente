using SQLite;
using Teste_BTG_CRUD_Cliente.Data.Repository.Interfaces;
using Teste_BTG_CRUD_Cliente.Data.DataContext;

namespace Teste_BTG_CRUD_Cliente.Data.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : new()
    {
        private SQLiteConnection _conn;
        public BaseRepository()
        {
            _conn = DataContext.DataContext.Current.Connection;
        }

        public void Delete(T obj)
        {
            try
            {
                if (obj is null)
                    throw new Exception("Object null - Delete");
                _conn.Delete(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteAll()
        {
            try
            {
                _conn.DeleteAll<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert(T obj)
        {
            try
            {
                if (obj is null)
                    throw new Exception("Object null - Insert");
                _conn.Insert(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(T obj)
        {
            try
            {
                if (obj is null)
                    throw new Exception("Object null - Update");
                _conn.Update(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new Exception("Guid null or empty");

                return _conn.Find<T>(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                return _conn.Table<T>().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertOrReplace(T obj)
        {
            try
            {
                if (obj == null)
                    throw new Exception("Object null - InsertOrReplace");
                _conn.InsertOrReplace(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}