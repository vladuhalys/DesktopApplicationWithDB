using System.Windows;
using System.Windows.Controls;
using DesktopApp.ViewModels;

namespace DesktopApp.Views;

public partial class SignUpPage : UserControl
{
    private readonly NavigationService _navigationService;
    
    public SignUpPage(NavigationService navigationService, SignUpViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        _navigationService = navigationService;
    }
    
    private void OnSignInNavigationClick(object sender, RoutedEventArgs e)
    {
        _navigationService.NavigateTo<SignInPage, SignInViewModel>();
    }
}