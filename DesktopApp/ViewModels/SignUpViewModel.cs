using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using DesktopApp.Services;
using DesktopApp.Views;
using Microsoft.Extensions.Logging;

namespace DesktopApp.ViewModels;

public class SignUpViewModel
{
    public ICommand SignUpCommand { get; }
    private readonly ILogger<SignUpViewModel> _logger;
    private readonly AuthService _authService;
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly NavigationService _navigationService;
    
    private string _email;
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged("Email");
        }
    }
    
    private string _username;
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged("Username");
        }
    }

    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged("Password");
        }
    }
    
    public SignUpViewModel(ILogger<SignUpViewModel> logger, AuthService authService, NavigationService navigationService)
    {
        _navigationService = navigationService;
        _username = string.Empty;
        _password = string.Empty;
        _email = string.Empty;
        _authService = authService;
        _logger = logger;
        SignUpCommand = new AsyncRelayCommand(OnSignUp);
    }
    
    private async Task OnSignUp()
    {
        try
        {
            await _authService.Register(Email, Password);
            _logger.LogInformation("User registered with username: {Username}", Username);  
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