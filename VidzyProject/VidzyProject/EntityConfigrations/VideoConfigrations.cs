using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using System.Data.Entity.ModelConfiguration;

namespace VidzyProject.Configrations
{
    public class VideoConfigrations: EntityTypeConfiguration<Video>
    {
        public VideoConfigrations()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(c=>c.Genre)
                .WithMany(g=>g.Videos)
                .HasForeignKey( g => g.GenreId);

            Property(c => c.GenreId)
              .IsRequired();

            Property(c => c.Classification)
                .HasColumnType("tinyint");

          


        }
    }
}
