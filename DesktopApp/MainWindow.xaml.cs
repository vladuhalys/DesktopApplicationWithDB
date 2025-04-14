using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using DesktopApp.Services;
using DesktopApp.ViewModels;
using DesktopApp.Views;

namespace DesktopApp;

public partial class MainWindow : Window
{
    private readonly NavigationService _navigationService;
    private readonly AuthService _authService;

    public MainWindow(NavigationService navigationService, AuthService authService)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _authService = authService;
        
        _navigationService.OnNavigate += SetContent;
        _authService.PropertyChanged += OnAuthServicePropertyChanged!;
    }

    private void OnAuthServicePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(AuthService.IsLoggedIn) && _authService.IsLoggedIn)
        {
            _navigationService.NavigateTo<HomePage, HomeViewModel>();
        }
        else if (e.PropertyName == nameof(AuthService.IsLoggedIn) && !_authService.IsLoggedIn)
        {
            _navigationService.NavigateTo<SignInPage, SignInViewModel>();
        }
    }

    private void SetContent(UserControl content)
    {
        this.Content = content;
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (_authService.IsLoggedIn)
            _navigationService.NavigateTo<HomePage, HomeViewModel>();
        else
            _navigationService.NavigateTo<SignInPage, SignInViewModel>();
    }
}