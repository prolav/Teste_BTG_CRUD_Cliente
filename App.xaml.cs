namespace Teste_BTG_CRUD_Cliente
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());
            //window.
            //window.TryMaximize();
            //window.Height = 1080;
            //window.Width = 1920;
            return window;
        }
    }
}