using EventManager.dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.dal.Database.Configuration;

public class ParticipationConfig : IEntityTypeConfiguration<Participation>
{
    public void Configure(EntityTypeBuilder<Participation> builder)
    {
        builder.ToTable("Participation");
        
        // columns
        builder.Property(p => p.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(p => p.State)
               .IsRequired();

        builder.Property(p => p.OtherInformation);
        
        // constraints
        builder.HasKey(p => p.Id)
               .HasName("PK_Participation");
    }
}