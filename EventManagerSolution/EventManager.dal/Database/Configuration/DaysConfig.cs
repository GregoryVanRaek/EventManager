using EventManager.dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.dal.Database.Configuration;

public class DaysConfig : IEntityTypeConfiguration<Days>
{
    public void Configure(EntityTypeBuilder<Days> builder)
    {
        builder.ToTable("Days");
        
        // columns
        builder.Property(d => d.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(d => d.Name)
               .IsRequired();

        builder.Property(d => d.StartDate)
               .IsRequired();
        
        // constraints
        builder.HasKey(d => d.Id)
               .HasName("PK_Days");

        builder.HasMany(d => d.Participations)
               .WithOne(p => p.Days)
               .HasForeignKey(p => p.DaysId);
    }
}