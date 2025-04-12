using System.Windows;
    using System.Windows.Controls;
    using DesktopApp.Services;
    
    namespace DesktopApp.Views;
    
    public partial class SignInPage : UserControl
    {
        private readonly NavigationService _navigationService;
    
        public SignInPage(NavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
        }
    
        private void OnSignUpNavigationClick(object sender, RoutedEventArgs e)
        {
            var signUpPage = new SignUpPage(_navigationService);
            _navigationService.NavigateTo(signUpPage);
        }
    }