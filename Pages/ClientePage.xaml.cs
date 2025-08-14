using Teste_BTG_CRUD_Cliente.ViewModels;

namespace Teste_BTG_CRUD_Cliente.Pages;

public partial class ClienteWindow : ContentPage
{
	public ClienteWindow()
	{
		InitializeComponent();
        BindingContext = new ClienteViewModel();
    }
}