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
        
        // Register NavigationService
        services.AddSingleton<NavigationService>();

        // Register ViewModels
        services.AddSingleton<SignInViewModel>();
        services.AddSingleton<SignUpViewModel>();
        services.AddSingleton<HomeViewModel>();

        // Register Views
        services.AddSingleton<SignInPage>();
        services.AddSingleton<SignUpPage>();
        services.AddSingleton<HomePage>();

        // Register MainWindow
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