using Teste_BTG_CRUD_Cliente.ViewModels;

namespace Teste_BTG_CRUD_Cliente.Pages;

public partial class ClientePage : ContentPage
{
	public ClientePage()
	{
		InitializeComponent();
    }

    private void EntryOnlyNumbers_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            // Remove tudo que não for número
            string somenteNumeros = new string(e.NewTextValue?.Where(char.IsDigit).ToArray());

            if (entry.Text != somenteNumeros)
                entry.Text = somenteNumeros;
        }
    }
}