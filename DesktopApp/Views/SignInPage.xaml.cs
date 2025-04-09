using System.Windows;
using System.Windows.Controls;
using DesktopApp.Interfaces;
using DesktopApp.ViewModels;

namespace DesktopApp.Views;

public partial class SignInPage : UserControl
{
    private readonly INavigationService _navigationService;
    public SignInPage(SignInViewModel viewModel, INavigationService navigationService)
    {
        InitializeComponent();
        DataContext = viewModel;
        _navigationService = navigationService;
    }

    private void OnSignUpNavigationClick(object sender, RoutedEventArgs e)
    {
        _navigationService.NavigateTo<SignUpPage>();
    }
}