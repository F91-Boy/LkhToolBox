using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Contracts.Movies.Responses
{
    public class PageResponse<TResponse>
    {
        public required IEnumerable<TResponse> Items { get; init; } = [];

        public required int Page { get; init; }
        public required int PageSize { get; init; }

        public required int Total { get; init; }

        public bool HasNextPage => Total > (Page * PageSize);


    }
}
