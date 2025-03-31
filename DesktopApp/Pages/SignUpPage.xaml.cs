using System.Windows;
using System.Windows.Controls;

namespace DesktopApp.Pages;

public partial class SignUpPage : UserControl
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private void OnSignInNavigationClick(object sender, RoutedEventArgs e)
    {
        var signInPage = new SignInPage();
        var mainWindow = Window.GetWindow(this);
        if (mainWindow != null)
        {
            var currentPage = mainWindow.Content as UserControl;
            if (currentPage != null)
            {
                currentPage.Content = null;
            }
            mainWindow.Content = signInPage;
        }
    }

    ~SignUpPage()
    {
        
    }
}