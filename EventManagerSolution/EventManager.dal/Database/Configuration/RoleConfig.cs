using EventManager.dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.dal.Database.Configuration;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        
        // Column
        builder.Property(r => r.Id)
               .IsRequired()
               .ValueGeneratedOnAdd();

        builder.Property(r => r.Name)
               .IsRequired();
        
        // Constraints
        builder.HasKey(r => r.Id)
               .HasName("PK_Role");

        builder.HasIndex(r => r.Name)
               .IsUnique();

    }
}