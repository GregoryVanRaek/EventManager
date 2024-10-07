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

        builder.HasData(new List<Days>()
        {
               new Days()
               {
                      Id = 1,
                      Name = "Manga Days",
                      StartDate = new DateOnly(2020, 05, 01),
                      EventId = 9,
                      ThemeId = 3
               },
               new Days()
               {
                      Id = 2,
                      Name = "Cosplay Days",
                      StartDate = new DateOnly(2020, 05, 02),
                      EventId = 9,
                      ThemeId = 2
               }
        });

    }
}