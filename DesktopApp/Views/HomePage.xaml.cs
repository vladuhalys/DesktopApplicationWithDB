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
        Loaded += HomePage_OnLoaded;
    }
    
    private async Task UpdateListView()
    {
        var viewModel = DataContext as HomeViewModel;
        if (viewModel == null)
        {
            return;
        }
        await viewModel.GetListOfBooks();
        BooksListView.Items.Clear();
        BooksListView.ItemsSource = null;
        BooksListView.ItemsSource = viewModel.ListOfBookModels;
        BooksListView.Items.Refresh();
        BooksListView.UpdateLayout();
    }

    private async void HomePage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await UpdateListView();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
}