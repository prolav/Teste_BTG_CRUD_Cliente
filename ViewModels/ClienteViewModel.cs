
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Teste_BTG_CRUD_Cliente.Data.Models;
using Teste_BTG_CRUD_Cliente.Services.IServices;

namespace Teste_BTG_CRUD_Cliente.ViewModels
{
    public class ClienteViewModel : BaseViewModel, INotifyPropertyChanged, IQueryAttributable
    {
        #region Fields
        private ClienteModel _cliente;
        private bool _modoDelete;
        private bool _modoEdicao;
        private string _name;
        private string _lastName;
        private int _age;
        private string _address;
        private readonly IClienteService _clienteService;
        #endregion
        
        #region Properties
        public ClienteModel Cliente { get => _cliente; set => SetProperty(ref _cliente, value); }
        public string Name
        {
            get => _name; 
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Lastname
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public bool ModoDelete 
        { get => _modoDelete;
            set 
            {
                _modoDelete = value;
                OnPropertyChanged();
            }
        }
        public bool ModoEdicao
        {
            get => _modoEdicao;
            set
            {
                _modoEdicao = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        public Command SalvarClienteCommand => new Command(async () => await SalvarClienteAsync());
        public Command DeletarClienteCommand => new Command(async () => await DeletarClienteAsync());
        #endregion

        public ClienteViewModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        private async Task CarregarDados()
        {
            try
            {
                if (Cliente != null)
                {
                    Name = Cliente.Name;
                    Lastname = Cliente.Lastname;
                    Age = Cliente.Age;
                    Address = Cliente.Address;
                }
                OnPropertyChanged();
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Atention", e.Message, "OK");
            }
        }


        private async Task SalvarClienteAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Lastname) || string.IsNullOrEmpty(Address) || Age == 0)
                {
                    var errorMessage = "";
                    throw new Exception("Check the informations");
                }
                else
                {
                    if (Cliente == null)
                        Cliente = new ClienteModel();

                    Cliente.Age = Age;
                    Cliente.Address = Address;
                    Cliente.Name = Name; 
                    Cliente.Lastname = Lastname;
                    await _clienteService.InsertReplaceCliente(Cliente);
                }
                await Application.Current.MainPage.DisplayAlert("Atention", "Recorded customer", "OK");
                FecharJanela();
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Atention", e.Message, "OK");
            }
        }

        private void FecharJanela()
        {
            var window = Application.Current.Windows.FirstOrDefault(w => w.Page.BindingContext == this);
            if (window != null)
            {
                Application.Current.CloseWindow(window);
                MessagingCenter.Send(this, "JanelaFechou");
            }
        }

        private async Task DeletarClienteAsync()
        {
            try
            {
                var resposta = await Application.Current.MainPage.DisplayAlert("Atention", $"Are you sure you want to delete the customer \"{Name}\" ?", "OK", "Cancel");
                if (resposta == true)
                {
                    if (Cliente == null)
                        throw new Exception("something wrong");
                    else
                        await _clienteService.DeleteCliente(Cliente);
                    FecharJanela();
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Atention", e.Message, "OK");
            }
        }

        #region Methods
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("id", out var idObj) && Guid.TryParse(idObj?.ToString(), out Guid id) && id != Guid.Empty)
            {
                Cliente = _clienteService.ObterClientePorId(id);
                ModoEdicao = query.ContainsKey("modoEdicao") && bool.Parse(query["modoEdicao"].ToString());
                ModoDelete = query.ContainsKey("modoDelete") && bool.Parse(query["modoDelete"].ToString());
                CarregarDados();
            }
            else
            {
                ModoEdicao = true;  
                ModoDelete = false;
            }
        }

        public void Initialize(ClienteModel cliente, bool modoEdicao, bool modoDelete)
        {
            ModoEdicao = modoEdicao;
            ModoDelete = modoDelete;
            if (cliente != null)
            {
                Cliente = cliente;
                CarregarDados();
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
