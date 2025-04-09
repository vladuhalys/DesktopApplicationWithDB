using System.Windows;
using DesktopApp.Interfaces;
using DesktopApp.Services;
using DesktopApp.ViewModels;
using DesktopApp.Views;
using Microsoft.Extensions.DependencyInjection;

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

        // Register Services
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<ISupabaseService, SupabaseService>();
        services.AddSingleton<IAuthService, AuthService>();
        
        // Register ViewModels
        services.AddSingleton<SignInViewModel>();
        services.AddSingleton<SignUpViewModel>();
        services.AddSingleton<HomeViewModel>();

        // Register Views
        //TODO: Fix the issue with the NavigationService
        services.AddSingleton<SignInPage>(provider =>
            new SignInPage(
                provider.GetRequiredService<SignInViewModel>(),
                provider.GetRequiredService<NavigationService>()));

        services.AddSingleton<SignUpPage>(provider =>
            new SignUpPage(
                provider.GetRequiredService<SignUpViewModel>(),
                provider.GetRequiredService<NavigationService>()));
        
        services.AddSingleton<HomePage>();
        services.AddSingleton<MainWindow>();
    }

    private void OnExit(object sender, ExitEventArgs e)
    {
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}