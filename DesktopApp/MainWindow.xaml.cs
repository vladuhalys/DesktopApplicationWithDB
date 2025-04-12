using System.Windows;
using System.Windows.Controls;
using DesktopApp.Interfaces;
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
        _navigationService.NavigateTo(new SignInPage(_navigationService));
    }

    private void SetContent(UserControl content)
    {
        this.Content = content;
    }
}