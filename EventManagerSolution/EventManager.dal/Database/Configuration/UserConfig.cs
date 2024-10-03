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
               .ValueGeneratedOnAdd()
               .IsRequired();
        
        builder.Property(u => u.LastName)
               .HasMaxLength(25)
               .IsRequired();
        
        builder.Property(u => u.FirstName)
               .HasMaxLength(25)
               .IsRequired();

        builder.Property(u => u.Email)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(u => u.PasswordHash)
               .IsRequired();
        
        builder.Property(u => u.PasswordSalt)
               .IsRequired();
        
        // Constraints
        builder.HasKey(u => u.Id)
               .HasName("PK_User");

        builder.HasIndex(u => u.Email) // 2 users can't have the same email
               .IsUnique();

        builder.HasMany(u => u.Role)
               .WithMany(r => r.Users);

        builder.HasMany(u => u.Address)
               .WithOne(a => a.User)
               .HasForeignKey(a => a.UserId);

        builder.HasMany(u => u.Comment)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId);

        builder.HasMany(u => u.Participation)
               .WithOne(p => p.User)
               .HasForeignKey(p => p.UserId);
    }
}