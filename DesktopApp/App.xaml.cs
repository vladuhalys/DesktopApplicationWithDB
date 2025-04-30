using System.Net.Http;
using System.Windows;
using DesktopApp.Services;
using DesktopApp.ViewModels;
using DesktopApp.Views;
using GutenbergApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DesktopApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider? _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        _serviceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        
        // Configure Logging
        services.AddLogging();
        
        // Register NavigationService
        services.AddSingleton<NavigationService>();
        
        // Register SupabaseService
        services.AddSingleton<SupabaseService>();
        services.AddSingleton<AuthService>(sp =>
        {
            var supabaseService = sp.GetRequiredService<SupabaseService>();
            return new AuthService(supabaseService.SupabaseRepository);
        });
        // Register HttpClient
        services.AddSingleton<ApiService>(sp => new ApiService(new HttpClient()));
        

        // Register ViewModels
        services.AddSingleton<SignInViewModel>(
            sp => new SignInViewModel(
                authService: sp.GetRequiredService<AuthService>(),
                navigationService: sp.GetRequiredService<NavigationService>(),
                logger: sp.GetRequiredService<ILogger<SignInViewModel>>()
                ));
            
            
        services.AddSingleton<SignUpViewModel>();
        services.AddSingleton<HomeViewModel>(
            sp => new HomeViewModel(
                authService: sp.GetRequiredService<AuthService>(),
                navigationService: sp.GetRequiredService<NavigationService>(),
                logger: sp.GetRequiredService<ILogger<HomeViewModel>>(),
                apiService: sp.GetRequiredService<ApiService>()
            ));

        // Register Views
        services.AddSingleton<SignInPage>(
            sp => new SignInPage(
                navigationService: sp.GetRequiredService<NavigationService>(),
                viewModel: sp.GetRequiredService<SignInViewModel>()
                ));
        services.AddSingleton<SignUpPage>();
        services.AddSingleton<HomePage>(
            sp => new HomePage(
                navigationService: sp.GetRequiredService<NavigationService>(),
                viewModel: sp.GetRequiredService<HomeViewModel>()
                ));

        // Register MainWindow
        services.AddSingleton<MainWindow>(sp =>
        {
            var navigationService = sp.GetRequiredService<NavigationService>();
            var authService = sp.GetRequiredService<AuthService>();
            return new MainWindow(navigationService, authService);
        });
    }

    private void OnExit(object sender, ExitEventArgs e)
    {
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}