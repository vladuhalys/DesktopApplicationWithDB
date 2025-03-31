using System.Windows;
using System.Windows.Controls;

namespace DesktopApp.Pages;

public partial class SignInPage : UserControl
{
    public SignInPage()
    {
        InitializeComponent();
    }

    private void OnSignUpNavigationClick(object sender, RoutedEventArgs e)
    {
        var signUpPage = new SignUpPage();
        var mainWindow = Window.GetWindow(this);
        if (mainWindow != null)
        {
            var currentPage = mainWindow.Content as UserControl;
            if (currentPage != null)
            {
                currentPage.Content = null;
            }
            mainWindow.Content = signUpPage;
        }
    }
}