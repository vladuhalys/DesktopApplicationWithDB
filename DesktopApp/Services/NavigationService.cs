using System.Windows.Controls;
using DesktopApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopApp.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly MainWindow _mainWindow;

    public NavigationService(IServiceProvider serviceProvider, MainWindow mainWindow)
    {
        _serviceProvider = serviceProvider;
        _mainWindow = mainWindow;
    }

    public void NavigateTo<TView>() where TView : UserControl
    {
        var view = _serviceProvider.GetRequiredService<TView>();
        _mainWindow.Content = view;
    }
}