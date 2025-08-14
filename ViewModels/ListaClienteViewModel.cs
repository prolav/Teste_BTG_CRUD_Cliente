using System.ComponentModel;
using System.Runtime.CompilerServices;
using Teste_BTG_CRUD_Cliente.Data.Models;
using Teste_BTG_CRUD_Cliente.Helpers;
using Teste_BTG_CRUD_Cliente.Pages;
using Teste_BTG_CRUD_Cliente.Services.IServices;


namespace Teste_BTG_CRUD_Cliente.ViewModels
{
    public  class ListaClienteViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Fields
        private bool _isEmpty;
        private readonly IClienteService _clienteService;
        private ClienteModel _clienteSelecionado;

        #endregion

        #region Properties
        public List<ClienteModel> ListaClientes { get; set; } = new List<ClienteModel>();
        public ClienteModel ClienteSelecionado
        {
            get => _clienteSelecionado;
            set
            {
                if (_clienteSelecionado != value)
                {
                    _clienteSelecionado = value;
                    OnPropertyChanged();

                    if (_clienteSelecionado != null)
                        AbrirTelaClienteAsync(_clienteSelecionado, true, true);
                }
            }
        }
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
        public Command RefreshCommand => new Command(async () => await CarregarDados());
        public Command AdicionarClienteCommand => new Command(async () => await AbrirTelaClienteAsync(null, true, false));
        public Command EditarClienteCommand => new Command<ClienteModel>(async (cliente) => await AbrirTelaClienteAsync(cliente,true,false));
        public Command ExcluirClienteCommand => new Command<ClienteModel>(async (cliente) => await AbrirTelaClienteAsync(cliente,false,true));
        
        #endregion
        public ListaClienteViewModel(IClienteService clienteService) 
        {
            MessagingCenter.Subscribe<ClienteViewModel>(this, "JanelaFechou", (sender) =>
            {
                CarregarDados();
            });
            _clienteService = clienteService;
            CarregarDados();
        }
        #region Methods
        public async Task CarregarDados()
        {
            try
            {
                ListaClientes = new List<ClienteModel>();
                ClienteSelecionado = null;
                ListaClientes = await _clienteService.ObterClienteOrderByAscAsync();
                IsEmpty = !ListaClientes.Any();
                OnPropertyChanged(nameof(ListaClientes));
                await Task.Delay(1000);            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Atention", e.Message, "OK");
            }          
        }
        private async Task AbrirTelaClienteAsync(ClienteModel cliente, bool modoEdicao, bool modoDelete)
        {
            try
            {
                //string rota = nameof(ClientePage);
                var serviceProvider = Application.Current.Handler.MauiContext.Services;
                if (cliente != null)
                {
                    WindowNavigationHelper.AbrirClienteEmNovaJanela(serviceProvider, cliente, modoEdicao, modoDelete);
                }
                else
                {
                    WindowNavigationHelper.AbrirClienteEmNovaJanela(serviceProvider, cliente, modoEdicao, modoDelete); 
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Atention", e.Message, "OK");
            }
        } 
        
       
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion
    }
}
