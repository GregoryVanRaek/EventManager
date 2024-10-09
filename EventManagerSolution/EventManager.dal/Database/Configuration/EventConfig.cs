using EventManager.dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.dal.Database.Configuration;

public class EventConfig : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Event");
        
        // columns
        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(e => e.Name)
               .IsRequired();

        builder.Property(e => e.StartDate)
               .IsRequired();

        builder.Property(e => e.EndDate)
               .IsRequired();

        builder.Property(e => e.State)
               .IsRequired();
        
        builder.Property(u => u.Address_Street)
            .IsRequired();
        
        builder.Property(u => u.Address_Number)
            .IsRequired();
        
        builder.Property(u => u.Address_Zip)
            .IsRequired();
        
        builder.Property(u => u.Address_City)
            .IsRequired();
        
        builder.Property(u => u.Address_Country)
            .IsRequired();

        // constraints 
       builder.HasKey(e => e.Id)
              .HasName("PK_Event");

       builder.HasMany(e => e.Comments)
              .WithOne(c => c.Event)
              .HasForeignKey(c => c.EventId);

       builder.HasMany(e => e.Days)
              .WithOne(d => d.Event)
              .HasForeignKey(d => d.EventId);
       
       
       // data
      builder.HasData(new List<Event>
       {
           new Event
           {
               Id = 1,
               Name = "Fake Festival",
               StartDate = new DateTime(2024, 12, 20, 9, 0, 0),
               EndDate = new DateTime(2024, 12, 23, 17, 0, 0),
               State = EventStatus.Pending,
               Address_Street = "festivallaan",
               Address_Number = "47",
               Address_Zip = "2500",
               Address_City = "Amsterdam",
               Address_Country = "Netherlands"
           },
           new Event
           {
               Id = 2,
               Name = "Gamescom",
               StartDate = new DateTime(2024, 11, 10, 9, 0, 0),
               EndDate = new DateTime(2024, 11, 13, 17, 0, 0),
               State = EventStatus.Pending,
               Address_Street = "rue du jeu video",
               Address_Number = "123",
               Address_Zip = "95000",
               Address_City = "Paris",
               Address_Country = "France"
           },
           new Event
           {
               Id = 3,
               Name = "Job Days",
               StartDate = new DateTime(2024, 11, 21, 9, 0, 0),
               EndDate = new DateTime(2024, 11, 22, 17, 0, 0),
               State = EventStatus.Pending,
               Address_Street = "rue du boulot",
               Address_Number = "50",
               Address_Zip = "4000",
               Address_City = "Liege",
               Address_Country = "Belgique"
           },
       });

    }
}