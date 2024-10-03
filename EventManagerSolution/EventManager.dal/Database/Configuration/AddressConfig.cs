using EventManager.dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.dal.Database.Configuration;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address");
        
        // columns
        builder.Property(a => a.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(a => a.Street)
               .IsRequired();
        builder.Property(a => a.Number)
               .IsRequired();
        builder.Property(a => a.Zip)
               .IsRequired();
        builder.Property(a => a.City)
               .IsRequired();
        builder.Property(a => a.Country)
               .IsRequired();
        builder.Property(a => a.Continent)
               .IsRequired();
        
        // constraint
        builder.HasKey(x => x.Id)
            .HasName("PK_Address");

        // a same place can have multiple events
        builder.HasMany(a => a.Events)
               .WithOne(e => e.Address)
               .HasForeignKey(e => e.AddressId);
    }
}