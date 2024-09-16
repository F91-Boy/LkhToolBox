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
