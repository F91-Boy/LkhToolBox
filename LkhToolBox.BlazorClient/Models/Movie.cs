using System.Text.RegularExpressions;

namespace LkhToolBox.BlazorClient.Models;

public partial class Movie
{
    public Guid Id { get; init; }

    public string Title { get; set; }

    public  int YearOfRelease { get; set; }

    public string Slug => GenerateSlug();

    public  List<string> Genres { get; init; } = [];

    //评分相关
    public float? Rating { get; set; }
    public int? UserRating { get; set; }



    private string GenerateSlug()
    {
        var sluggedTitle = SlugRegex().Replace(Title, string.Empty).ToLower().Replace(" ","-");

        return $"{sluggedTitle}-{YearOfRelease}";
    }

    [GeneratedRegex("[^0-9A-Za-z _-]",RegexOptions.NonBacktracking,5)]
    private static partial Regex SlugRegex();


}