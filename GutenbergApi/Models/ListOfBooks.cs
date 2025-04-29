namespace GutenbergApi.Models;

public class ListOfBooks
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public List<Book> Results { get; set; }
    
    public ListOfBooks()
    {
        Count = 0;
        Next = null;
        Previous = null;
        Results = new List<Book>();
    }
    
    public ListOfBooks(int count) : this()
    {
        Count = count;
    }
    
    public ListOfBooks(int count, string? next) : this(count)
    {
        Next = next;
    }
    
    public ListOfBooks(int count, string? next, string? previous) : this(count, next)
    {
        Previous = previous;
    }
    
    public ListOfBooks(int count, string? next, string? previous, List<Book> results) : this(count, next, previous)
    {
        Results = results;
    }
}