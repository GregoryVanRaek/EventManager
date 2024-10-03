using EventManager.dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.dal.Database.Configuration;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment");
        
        // columns
        builder.Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Message)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(c => c.MessageDate)
               .IsRequired();

        // constraints
        builder.HasKey(c => c.Id)
               .HasName("PK_Comment");

    }
}