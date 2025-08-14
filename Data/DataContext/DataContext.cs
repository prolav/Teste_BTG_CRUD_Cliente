using SQLite;
using Teste_BTG_CRUD_Cliente.Data.Models;

namespace Teste_BTG_CRUD_Cliente.Data.DataContext
{
    public class DataContext
    {
        private static DataContext _lazy;
        private static SQLiteConnection _sqlConnection;
        private const string _dbName = "ClienteBTG.db3";

        public static DataContext Current
        {
            get
            {
                if (_lazy == null)
                    _lazy = new DataContext();

                return _lazy;
            }
        }

        private DataContext()
        {
            _sqlConnection = new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, _dbName));
            _sqlConnection.CreateTable<ClienteModel>();
        }

        public SQLiteConnection Connection
        {
            get { return _sqlConnection; }
            set { _sqlConnection = value; }
        }
    }
}