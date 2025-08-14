using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Teste_BTG_CRUD_Cliente.Data.DataContext;
using Teste_BTG_CRUD_Cliente.Data.Repository.Interfaces;
using Teste_BTG_CRUD_Cliente.Data.Repository.Repositories;
using Teste_BTG_CRUD_Cliente.Pages;
using Teste_BTG_CRUD_Cliente.Services.IServices;
using Teste_BTG_CRUD_Cliente.Services.Services;
using Teste_BTG_CRUD_Cliente.ViewModels;
#if WINDOWS
    using Microsoft.UI;
    using Microsoft.UI.Windowing;
    using Microsoft.UI.Xaml;
#endif
namespace Teste_BTG_CRUD_Cliente
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            #region Data
            builder.Services.AddSingleton<DataContext>();
            builder.Services.AddSingleton<IClienteRepository, ClienteRespository>();
            builder.Services.AddSingleton<IClienteService, ClienteService>();
            #endregion
            #region Pages
            builder.Services.AddSingleton<ListaClientePage>();
            builder.Services.AddSingleton<ClientePage>();
            #endregion
            #region ViewModels
            builder.Services.AddViewModel<ListaClienteViewModel, ListaClientePage>();
            builder.Services.AddViewModel<ClienteViewModel, ClientePage>();
            #endregion

            return builder.Build();
        }

        private static void AddViewModel<TViewModel, TView>(this IServiceCollection services)
            where TView : ContentPage, new()
            where TViewModel : class
        {
            services.AddTransient<TViewModel>();
            services.AddTransient<TView>(s => new TView() { BindingContext = s.GetRequiredService<TViewModel>() });
        }
    }
}
