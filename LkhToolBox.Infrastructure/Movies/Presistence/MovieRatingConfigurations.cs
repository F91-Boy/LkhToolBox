using LkhToolBox.Domain.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Infrastructure.Movies.Presistence
{
    public class MovieRatingConfigurations : IEntityTypeConfiguration<MovieRating>
    {
        public void Configure(EntityTypeBuilder<MovieRating> builder)
        {
           
        }
    }
}
