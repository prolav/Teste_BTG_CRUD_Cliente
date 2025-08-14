using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Teste_BTG_CRUD_Cliente.ViewModels
{
    public class ClienteViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Fields


        #endregion

        #region Properties


        #endregion

        #region Commands

        #endregion



        public ClienteViewModel()
        {
            
        }


        #region Methods

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}
