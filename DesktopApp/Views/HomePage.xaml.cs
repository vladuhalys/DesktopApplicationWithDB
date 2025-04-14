using System.Windows;
using System.Windows.Controls;
using DesktopApp.ViewModels;

namespace DesktopApp.Views;

public partial class HomePage : UserControl
{
    private readonly NavigationService _navigationService;
    public HomePage(NavigationService navigationService, HomeViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        _navigationService = navigationService;
    }
}