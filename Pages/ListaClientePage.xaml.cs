using Microsoft.Maui.Controls;
using Teste_BTG_CRUD_Cliente.ViewModels;

namespace Teste_BTG_CRUD_Cliente.Pages;

public partial class ListaClientePage : ContentPage
{
	public ListaClientePage()
	{
		InitializeComponent();
        BindingContext = new ListaClienteViewModel();
    }
}