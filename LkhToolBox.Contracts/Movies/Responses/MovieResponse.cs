﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Contracts.Movies.Responses
{
    public class MovieResponse
    {
        public required Guid Id { get; init; }

        public required string Title { get; init; }

        public required string Slug { get; init; }

        public required int YearOfRelease { get; init; }

        public required IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();

        //评分相关
        public float? Rating { get; init; }
        public int? UserRating { get; init; }
    }
}
