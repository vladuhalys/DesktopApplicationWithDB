using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using DesktopApp.Services;
using Microsoft.Extensions.Logging;

namespace DesktopApp.ViewModels;

public class SignInViewModel
{
    public ICommand SignInCommand { get; }
    private readonly ILogger<SignInViewModel> _logger;
    private readonly AuthService _authService;
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly NavigationService _navigationService;
    
    private string _username;
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }

    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }
    
    public SignInViewModel(ILogger<SignInViewModel> logger, AuthService authService, NavigationService navigationService)
    {
        _navigationService = navigationService;
        _username = string.Empty;
        _password = string.Empty;
        _authService = authService;
        _logger = logger;
        SignInCommand = new RelayCommand(OnSignIn);
    }
    
    private void OnSignIn()
    {
        _authService.Login(Username, Password);
    }
    
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}