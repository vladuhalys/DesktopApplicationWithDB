using System.Windows.Controls;
using DesktopApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public class NavigationService
{
    public event Action<UserControl>? OnNavigate;

    public void NavigateTo(UserControl view)
    {
        OnNavigate?.Invoke(view);
    }
}