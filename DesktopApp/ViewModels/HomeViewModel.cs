using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using DesktopApp.Services;
using Microsoft.Extensions.Logging;

namespace DesktopApp.ViewModels;

public class HomeViewModel
{
    public ICommand LogoutCommand { get; }
    private readonly ILogger<HomeViewModel> _logger;
    private readonly AuthService _authService;
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly NavigationService _navigationService;
    
    public HomeViewModel(ILogger<HomeViewModel> logger, AuthService authService, NavigationService navigationService)
    {
        _navigationService = navigationService;
        _authService = authService;
        _logger = logger;
        LogoutCommand = new AsyncRelayCommand(OnLogout);
    }
    
    private async Task OnLogout()
    {
        try
        {
            _logger.LogInformation("Logging out...");
            await _authService.Logout();
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
        }
    }
    
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}