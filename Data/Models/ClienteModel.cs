using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Teste_BTG_CRUD_Cliente.Data.Models
{
    public class ClienteModel : BaseModel, INotifyPropertyChanged
    {
        [Column("Name")]
        public string Name { get; set; }

        [Column("Lastname")]
        public string Lastname { get; set; }

        [Column("Age")]
        public int? Age { get; set; }

        [Column("Address")]
        public string Address { get; set; }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
