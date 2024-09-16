using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LkhToolBox.Domain.Movies
{

    public partial class Movie
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = default!;

        public int YearOfRelease { get; set; }

        public string Slug { get; set; } = default!;

        public List<string> Genres { get; init; } = [];

        //评分相关
        public float? Rating { get; set; }
        public int? UserRating { get; set; }


        public string GenerateSlug()
        {
            var sluggedTitle = SlugRegex().Replace(Title, string.Empty).ToLower().Replace(" ", "-");

            return $"{sluggedTitle}-{YearOfRelease}";
                //Slug =  $"{sluggedTitle}-{YearOfRelease}";; 

        }

        [GeneratedRegex("[^0-9A-Za-z _-]", RegexOptions.NonBacktracking, 5)]
        private static partial Regex SlugRegex();


    }
}
