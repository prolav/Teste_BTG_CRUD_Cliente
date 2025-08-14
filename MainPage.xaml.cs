using Teste_BTG_CRUD_Cliente.Pages;

namespace Teste_BTG_CRUD_Cliente
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
            {
                var novaJanela = new Microsoft.Maui.Controls.Window(new ClienteWindow());
                Application.Current.OpenWindow(novaJanela);
            }

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
