using System.Windows;
using System.Windows.Controls;
using DesktopApp.ViewModels;

namespace DesktopApp.Views;
    
public partial class SignInPage : UserControl
{
    private readonly NavigationService _navigationService;
    
    public SignInPage(NavigationService navigationService, SignInViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        _navigationService = navigationService;
    }
    
    private void OnSignUpNavigationClick(object sender, RoutedEventArgs e)
    {
        _navigationService.NavigateTo<SignUpPage, SignUpViewModel>();
    }
}