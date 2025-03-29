using System.Windows;
using DesktopApp.Pages;

namespace DesktopApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Content = new SignInPage();
    }
}