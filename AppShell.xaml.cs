using Teste_BTG_CRUD_Cliente.Pages;

namespace Teste_BTG_CRUD_Cliente
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("listaClientePage", typeof(ListaClientePage));
            Routing.RegisterRoute(nameof(ClientePage), typeof(ClientePage));
        }
    }
}
