using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Contracts.Movies.Requests
{
    public class UpdateMovieRequest
    {
        public required string Title { get; init; }

        public required int YearOfRelease { get; init; }

        public required IEnumerable<string> Genres { get; init; } = [];
    }
}
