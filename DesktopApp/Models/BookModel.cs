using System.Windows.Media.Imaging;
using GutenbergApi.Models;

namespace DesktopApp.Models;

public class BookModel
{
    public string Title { get; set; }
    public BitmapImage CoverImage { get; set; }
    public Book Book { get; set; }
    
    public BookModel(string title, BitmapImage coverImage, Book book)
    {
        Title = title;
        CoverImage = coverImage;
        Book = book;
    }
}