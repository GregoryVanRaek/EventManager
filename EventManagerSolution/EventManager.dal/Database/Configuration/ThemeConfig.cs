using EventManager.dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.dal.Database.Configuration;

public class ThemeConfig : IEntityTypeConfiguration<Theme>
{
    public void Configure(EntityTypeBuilder<Theme> builder)
    {
        // table
        builder.ToTable("Theme");
        
        // columns
        builder.Property(t => t.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(t => t.Name)
               .IsRequired();
            
        
        // constraints
        builder.HasKey(t => t.Id)
            .HasName("PK_Theme");

        builder.HasIndex(t => t.Name)
               .IsUnique();

        builder.HasMany(t => t.Days)
               .WithOne(d => d.Theme)
               .HasForeignKey(d => d.ThemeId);

    }
}