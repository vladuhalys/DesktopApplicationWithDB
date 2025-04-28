namespace GutenbergApi.Models;

public class ListOfBooks
{
    public int Count { get; set; }
    public int? Next { get; set; }
    public int? Previous { get; set; }
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
    
    public ListOfBooks(int count, int? next) : this(count)
    {
        Next = next;
    }
    
    public ListOfBooks(int count, int? next, int? previous) : this(count, next)
    {
        Previous = previous;
    }
    
    public ListOfBooks(int count, int? next, int? previous, List<Book> results) : this(count, next, previous)
    {
        Results = results;
    }
}