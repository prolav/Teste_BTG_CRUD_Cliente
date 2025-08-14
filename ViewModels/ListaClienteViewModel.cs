using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Teste_BTG_CRUD_Cliente.Data.Models;

namespace Teste_BTG_CRUD_Cliente.ViewModels
{
    public  class ListaClienteViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Fields
        private bool _isEmpty;
        #endregion

        #region Properties
        public List<ClienteModel> ListaClientes { get; set; } = new List<ClienteModel>();
        public ClienteModel ClienteSelecionado { get; set; }
        public bool IsRefreshing { get; set; } = false;
        public bool IsEmpty
        {
            get => _isEmpty;
            set
            {
                if (_isEmpty != value)
                {
                    _isEmpty = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsNotEmpty)); 
                }
            }
        }

        public bool IsNotEmpty => !_isEmpty;
        #endregion

        #region Commands
        public Command RefreshCommand => new Command(async () => await RefreshClientesAsync());
        public Command AdicionarClienteCommand => new Command(async () => await AdicionarClienteAsync());
        public Command EditarClienteCommand => new Command<ClienteModel>(async (cliente) => await EditarClienteAsync(cliente));
        public Command ExcluirClienteCommand => new Command<ClienteModel>(async (cliente) => await ExcluirClienteAsync(cliente));
        
        #endregion
        public ListaClienteViewModel() 
        {
            CarregarDadosIniciais();
        }
        #region Methods
        private void CarregarDadosIniciais()
        {
            try
            {
                // Aqui você pode carregar dados iniciais ou configurar o ViewModel
                // Por exemplo, adicionar alguns clientes de exemplo
                ListaClientes.Add(new ClienteModel {Name = "Customer1",Lastname = "LastName", Age = 11, Address = "Casa" });
                OnPropertyChanged(nameof(ListaClientes));
                IsEmpty = !ListaClientes.Any();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task RefreshClientesAsync()
        {
            try
            {
                IsRefreshing = true;
                // Simula uma chamada assíncrona para buscar os clientes
                await Task.Delay(1000);
                // Aqui você deve implementar a lógica para buscar os clientes do seu serviço ou banco de dados
                IsRefreshing = false;
            }
            catch (Exception)
            {
                throw;
            }          
        }
        private async Task AdicionarClienteAsync()
        {
            try
            {
                // Lógica para adicionar um novo cliente
                await Task.Delay(500); // Simula uma operação assíncrona
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task EditarClienteAsync(ClienteModel cliente)
        {
            try
            {
                if (cliente == null) return;
                // Lógica para editar o cliente selecionado
                await Task.Delay(500); // Simula uma operação assíncrona

            }
            catch (Exception)
            {
                throw;
            }     
        }
        private async Task ExcluirClienteAsync(ClienteModel cliente)
        {
            try
            {
                if (cliente == null) return;
                // Lógica para excluir o cliente selecionado
                await Task.Delay(500); // Simula uma operação assíncrona
                ListaClientes.Remove(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion

        //#region INotifyPropertyChanged Implementation  
        //public void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        //{
        //    if (EqualityComparer<T>.Default.Equals(field, value)) return;
        //    field = value;
        //    OnPropertyChanged(propertyName);
        //}
        //#endregion
    }
}
