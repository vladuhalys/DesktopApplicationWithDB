namespace GutenbergApi.Models;

public class Person(string name, int? birthYear = null, int? deathYear = null)
{
    public int ? BirthYear { get; set; } = birthYear;
    public int ? DeathYear { get; set; } = deathYear;
    public string Name { get; set; } = name;
}