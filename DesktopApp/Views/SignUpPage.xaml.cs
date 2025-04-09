using System.Windows;
using System.Windows.Controls;
using DesktopApp.Interfaces;
using DesktopApp.ViewModels;

namespace DesktopApp.Views;

public partial class SignUpPage
{
    private readonly INavigationService _navigationService;

    public SignUpPage(SignUpViewModel viewModel, INavigationService navigationService)
    {
        this.DataContext = viewModel;
        _navigationService = navigationService;
    }

    private void OnSignInNavigationClick(object sender, RoutedEventArgs e)
    {
        _navigationService.NavigateTo<SignInPage>();
    }
}