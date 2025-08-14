using System.Runtime.InteropServices;

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
#if WINDOWS
            window.Created += (s, e) =>
            {
                var mauiWinUIWindow = (MauiWinUIWindow)window.Handler.PlatformView;
                var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(mauiWinUIWindow);

                ShowWindow(hwnd, SW_MAXIMIZE);
            };
#endif
            return window;
        }
#if WINDOWS
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_MAXIMIZE = 3;
#endif
    }
}