using LkhToolBox.Domain.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LkhToolBox.Infrastructure.Movies.Presistence
{
    public class MovieRatingConfigurations : IEntityTypeConfiguration<MovieRating>
    {
        public void Configure(EntityTypeBuilder<MovieRating> builder)
        {
           
        }
    }
}
