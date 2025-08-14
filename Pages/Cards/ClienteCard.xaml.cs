using System.Windows.Input;

namespace Teste_BTG_CRUD_Cliente.Pages.Cards;

public partial class ClienteCard : ContentView
{
    public static readonly BindableProperty EditarClienteCommandProperty =
    BindableProperty.Create(
        nameof(EditarClienteCommand),
        typeof(ICommand),
        typeof(ClienteCard),
        defaultBindingMode: BindingMode.OneWay);

    public ICommand EditarClienteCommand
    {
        get => (ICommand)GetValue(EditarClienteCommandProperty);
        set => SetValue(EditarClienteCommandProperty, value);
    }

    public static readonly BindableProperty ExcluirClienteCommandProperty =
        BindableProperty.Create(
            nameof(ExcluirClienteCommand),
            typeof(ICommand),
        typeof(ClienteCard),
            defaultBindingMode: BindingMode.OneWay);

    public ICommand ExcluirClienteCommand
    {
        get => (ICommand)GetValue(ExcluirClienteCommandProperty);
        set => SetValue(ExcluirClienteCommandProperty, value);
    }

    public ClienteCard()
	{
		InitializeComponent();
	}
}