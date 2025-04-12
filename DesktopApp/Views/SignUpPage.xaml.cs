using System.Windows;
using System.Windows.Controls;
using DesktopApp.ViewModels;

namespace DesktopApp.Views;

public partial class SignUpPage : UserControl
{
    private readonly NavigationService _navigationService;
    
    public SignUpPage(NavigationService navigationService)
    {
        InitializeComponent();
        _navigationService = navigationService;
    }
    
    private void OnSignInNavigationClick(object sender, RoutedEventArgs e)
    {
        var signInPage = new SignInPage(_navigationService);
        _navigationService.NavigateTo(signInPage);
    }
}