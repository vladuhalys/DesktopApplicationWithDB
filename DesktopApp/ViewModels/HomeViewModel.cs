using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using DesktopApp.Models;
using DesktopApp.Services;
using GutenbergApi.Models;
using GutenbergApi.Services;
using Microsoft.Extensions.Logging;

namespace DesktopApp.ViewModels;

public class HomeViewModel
{
    public ICommand LogoutCommand { get; }
    private readonly ILogger<HomeViewModel> _logger;
    private readonly AuthService _authService;
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly NavigationService _navigationService;
    private readonly ApiService _apiService;
    private int _page = 1;
    public List<Book> _listOfBooks;
    public List<BookModel> _listOfBookModels;
    
    public List<BookModel> ListOfBookModels
    {
        get => _listOfBookModels;
        set
        {
            _listOfBookModels = value;
            OnPropertyChanged("ListOfBookModels");
        }
    }
    public List<Book> ListOfBooks
    {
        get => _listOfBooks;
        set
        {
            _listOfBooks = value;
            OnPropertyChanged("ListOfBooks");
        }
    }
    
    public int Page
    {
        get => _page;
        set
        {
            _page = value;
            OnPropertyChanged("Page");
        }
    }
    
    private async Task NextPage()
    {
        Page++;
        await GetListOfBooks();
    }
    
    private async Task PreviousPage()
    {
        if (Page > 1)
        {
            Page--;
            await GetListOfBooks();
        }
    }
    
    
    public HomeViewModel(ILogger<HomeViewModel> logger, AuthService authService, NavigationService navigationService, ApiService apiService)
    {
        _navigationService = navigationService;
        _authService = authService;
        _logger = logger;
        LogoutCommand = new AsyncRelayCommand(OnLogout);
        _apiService = apiService;
        ListOfBooks = new List<Book>();
        ListOfBookModels = new List<BookModel>();
    }
    
    private async Task OnLogout()
    {
        try
        {
            _logger.LogInformation("Logging out...");
            await _authService.Logout();
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
        }
    }
    
    public async Task GetListOfBooks()
    {
        try
        {
            var listOfBooks = await _apiService.GetAllBooks(Page);
            if (listOfBooks == null || listOfBooks.Results == null)
            {
                throw new Exception("Api error: No data");
            }
            ListOfBooks.Clear();
            ListOfBookModels.Clear();
            ListOfBooks = listOfBooks.Results;
            var temp = new List<BookModel>();
            foreach (Book book in ListOfBooks)
            {
                BitmapImage coverImage = new BitmapImage();
                if (book.Formats.ContainsKey("image/jpeg"))
                {
                    coverImage.BeginInit();
                    coverImage.UriSource = new Uri(book.Formats["image/jpeg"]);
                    coverImage.EndInit();
                }
                else
                {
                    coverImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/PlaceholderBook.png"));
                }
                var bookModel = new BookModel(book.Title, coverImage, book);
                temp.Add(bookModel);
            }
            ListOfBookModels = temp;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw new Exception(e.Message);
        }
    }
    
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}