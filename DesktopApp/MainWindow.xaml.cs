using System.Windows;
using DesktopApp.Views;

namespace DesktopApp;

public partial class MainWindow : Window
{
    public MainWindow(SignInPage signInPage)
    {
        InitializeComponent();
        this.Content = signInPage;
    }
}