namespace GutenbergApi.Services;

public abstract class UrlService
{
    public static readonly string BaseUrl = "https://gutendex.com";
    public static string ListOfBooksByPage(int page) => $"/books/?page={page}";
}