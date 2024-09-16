using LkhToolBox.Domain.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LkhToolBox.Infrastructure.Movies.Presistence
{
    public class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasIndex(x => x.Slug).IsUnique();
            builder.Property(x => x.Slug).HasMaxLength(50);
            builder.Property(x => x.Title).HasMaxLength(50);
        }
    }
}
