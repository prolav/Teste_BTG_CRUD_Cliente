using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_BTG_CRUD_Cliente.Data.Models;
using Teste_BTG_CRUD_Cliente.Pages;
using Teste_BTG_CRUD_Cliente.ViewModels;
#if WINDOWS
using System.Runtime.InteropServices;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

namespace Teste_BTG_CRUD_Cliente.Helpers
{
    public static class WindowNavigationHelper
    {
        public static void AbrirClienteEmNovaJanela(IServiceProvider serviceProvider, ClienteModel cliente, bool modoEdicao, bool modoDelete)
        {
            // Resolve ViewModel via DI
            var vm = serviceProvider.GetRequiredService<ClienteViewModel>();
            vm.Initialize(cliente, modoEdicao, modoDelete);
            vm.Cliente = cliente ?? new ClienteModel();
            vm.ModoEdicao = modoEdicao;
            vm.ModoDelete = modoDelete;

            // Cria a página usando apenas o construtor padrão
            var clientePage = new ClientePage();
            clientePage.BindingContext = vm;

            var window = new Window(clientePage);

#if WINDOWS
        window.Created += (s, e) =>
        {
            var mauiWinUIWindow = (MauiWinUIWindow)window.Handler.PlatformView;
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(mauiWinUIWindow);

            var displayArea = Microsoft.UI.Windowing.DisplayArea.Primary;
            int width = 600, height = 400;
            int x = (displayArea.WorkArea.Width - width) / 2;
            int y = (displayArea.WorkArea.Height - height) / 2;

            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow?.MoveAndResize(new Windows.Graphics.RectInt32(x, y, width, height));
        };
#endif

            Application.Current.OpenWindow(window);
        }

        public static async Task<bool> ShowAlertAsync(string title, string message, string accept, string cancel = null)
        {
            bool result;

            if (string.IsNullOrEmpty(cancel))
            {
                await Application.Current.MainPage.DisplayAlert(title, message, accept);
                result = true; // Só OK
            }
            else
            {
                result = await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
            }

#if WINDOWS
        // Pega a janela que contém a MainPage
        var window = Application.Current.Windows.LastOrDefault();
        if (window != null)
        {
            // Pega o HWND da janela
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window.Handler.PlatformView as Microsoft.UI.Xaml.Window);

            // Restaura e traz para frente
            ShowWindow(hwnd, SW_RESTORE);
            SetForegroundWindow(hwnd);
        }
#endif

            return result;
        }

#if WINDOWS
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    private const int SW_RESTORE = 9;
#endif
    }
}
