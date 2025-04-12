using System.Windows;
using System.Windows.Controls;
using DesktopApp.ViewModels;
using DesktopApp.Views;

namespace DesktopApp;

public partial class MainWindow : Window
{
    private readonly NavigationService _navigationService;

    public MainWindow(NavigationService navigationService)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _navigationService.OnNavigate += SetContent;

        // Navigate to the initial page
        _navigationService.NavigateTo<SignInPage, SignInViewModel>();
    }

    private void SetContent(UserControl content)
    {
        this.Content = content;
    }
}