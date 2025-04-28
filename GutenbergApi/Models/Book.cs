namespace GutenbergApi.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<string> Subjects { get; set; }
    public List<Person> Authors { get; set; }
    public List<string> Summaries { get; set; }
    public List<Person> Translators { get; set; }
    public List<string> Bookshelves { get; set; }
    public List<string> Languages { get; set; }
    public bool ? Copyright { get; set; }
    public string MediaType { get; set; }
    public Dictionary<string, string> Formats { get; set; }
    public int DownloadCount { get; set; }

    public Book()
    {
        Id = 0;
        Title = string.Empty;
        Subjects = new List<string>();
        Authors = new List<Person>();
        Summaries = new List<string>();
        Translators = new List<Person>();
        Bookshelves = new List<string>();
        Languages = new List<string>();
        Copyright = null;
        MediaType = string.Empty;
        Formats = new Dictionary<string, string>();
        DownloadCount = 0;
    }

    public Book(int id) : this()
    {
        Id = id;
    }
    public Book(int id, string title) : this(id)
    {
        Title = title;
    }
    public Book(int id, string title, List<string> subjects) : this(id, title)
    {
        Subjects = subjects;
    }
    public Book(int id, string title, List<string> subjects, List<Person> authors) : this(id, title, subjects)
    {
        Authors = authors;
    }
    public Book(int id, string title, List<string> subjects, List<Person> authors, List<string> summaries) : this(id, title, subjects, authors)
    {
        Summaries = summaries;
    }
    public Book(int id, string title, List<string> subjects, List<Person> authors, List<string> summaries, List<Person> translators) : this(id, title, subjects, authors, summaries)
    {
        Translators = translators;
    }
    public Book(int id, string title, List<string> subjects, List<Person> authors, List<string> summaries, List<Person> translators, List<string> bookshelves) : this(id, title, subjects, authors, summaries, translators)
    {
        Bookshelves = bookshelves;
    }
    public Book(int id, string title, List<string> subjects, List<Person> authors, List<string> summaries, List<Person> translators, List<string> bookshelves, List<string> languages) : this(id, title, subjects, authors, summaries, translators, bookshelves)
    {
        Languages = languages;
    }

    public Book(int id, string title, List<string> subjects, List<Person> authors, List<string> summaries,
        List<Person> translators, List<string> bookshelves, List<string> languages, bool copyright) : this(id, title,
        subjects, authors, summaries, translators, bookshelves, languages)
    {
        Copyright = copyright;
    }
    
    public Book(int id, string title, List<string> subjects, List<Person> authors, List<string> summaries,
        List<Person> translators, List<string> bookshelves, List<string> languages, bool copyright, string mediaType) : this(id, title,
        subjects, authors, summaries, translators, bookshelves, languages, copyright)
    {
        MediaType = mediaType;
    }
    
    public Book(int id, string title, List<string> subjects, List<Person> authors, List<string> summaries,
        List<Person> translators, List<string> bookshelves, List<string> languages, bool copyright, string mediaType,
        Dictionary<string, string> formats) : this(id, title,
        subjects, authors, summaries, translators, bookshelves, languages, copyright, mediaType)
    {
        Formats = formats;
    }
    
    public Book(int id, string title, List<string> subjects, List<Person> authors, List<string> summaries,
        List<Person> translators, List<string> bookshelves, List<string> languages, bool copyright, string mediaType,
        Dictionary<string, string> formats, int downloadCount) : this(id, title,
        subjects, authors, summaries, translators, bookshelves, languages, copyright, mediaType, formats)
    {
        DownloadCount = downloadCount;
    }

}