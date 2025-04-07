using System.Windows;
using DesktopApp.Pages;

namespace DesktopApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //TODO: Rework this to DI MVVM
        //Example: https://medium.com/@shalahuddinshanto/dependency-injection-in-wpf-a-complete-implementation-guide-468abcf95337
        this.Content = new SignInPage();
    }
}