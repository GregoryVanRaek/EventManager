using EventManager.dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.dal.Database.Configuration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table
        builder.ToTable("User");
        
        // Column
        builder.Property(u => u.Id)
               .IsRequired();
        
        builder.Property(u => u.Email)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(u => u.LastName)
               .HasMaxLength(25);

        builder.Property(u => u.FirstName)
               .HasMaxLength(25);
        
        builder.Property(u => u.Address_Street);
        
        builder.Property(u => u.Address_Number);
        
        builder.Property(u => u.Address_Zip);

        builder.Property(u => u.Address_City);
        
        builder.Property(u => u.Address_Country);

        builder.Property(u => u.IsAdmin);
        
        // Constraints
        builder.HasKey(u => u.Id)
               .HasName("PK_User");

        builder.HasIndex(u => u.Email) // 2 users can't have the same email
               .IsUnique();
        
        builder.HasMany(u => u.Comment)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId);

        builder.HasMany(u => u.Participation)
               .WithOne(p => p.User)
               .HasForeignKey(p => p.UserId);
    }
}