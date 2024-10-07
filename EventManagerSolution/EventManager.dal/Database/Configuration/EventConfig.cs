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
      /* builder.HasData(new List<Event>
       {
           new Event
           {
               Id = 1,
               Name = "Conférence Tech",
               StartDate = new DateTime(2024, 1, 15, 9, 0, 0),
               EndDate = new DateTime(2024, 1, 15, 17, 0, 0),
               State = EventStatus.Confirmed
           },
           new Event
           {
               Id = 2,
               Name = "Atelier de développement web",
               StartDate = new DateTime(2024, 2, 10, 10, 0, 0),
               EndDate = new DateTime(2024, 2, 10, 13, 0, 0),
               State = EventStatus.Pending
           },
           new Event
           {
               Id = 3,
               Name = "Formation Cybersécurité",
               StartDate = new DateTime(2024, 3, 5, 14, 0, 0),
               EndDate = new DateTime(2024, 3, 5, 18, 0, 0),
               State = EventStatus.Confirmed
           },
           new Event
           {
               Id = 4,
               Name = "Séminaire d'entreprise",
               StartDate = new DateTime(2024, 4, 20, 8, 30, 0),
               EndDate = new DateTime(2024, 4, 20, 12, 0, 0),
               State = EventStatus.Pending
           },
           new Event
           {
               Id = 5,
               Name = "Webinaire sur l'IA",
               StartDate = new DateTime(2024, 5, 10, 16, 0, 0),
               EndDate = new DateTime(2024, 5, 10, 17, 30, 0),
               State = EventStatus.Confirmed
           },
           new Event
           {
               Id = 6,
               Name = "Hackathon 2024",
               StartDate = new DateTime(2024, 6, 18, 9, 0, 0),
               EndDate = new DateTime(2024, 6, 19, 18, 0, 0),
               State = EventStatus.Pending
           },
           new Event
           {
               Id = 7,
               Name = "Meetup DevOps",
               StartDate = new DateTime(2023, 10, 8, 14, 0, 0),
               EndDate = new DateTime(2023, 10, 8, 18, 0, 0),
               State = EventStatus.Passed
           },
           new Event
           {
               Id = 8,
               Name = "Formation Docker",
               StartDate = new DateTime(2024, 7, 2, 9, 0, 0),
               EndDate = new DateTime(2024, 7, 2, 12, 30, 0),
               State = EventStatus.Confirmed
           },
           new Event
           {
               Id = 9,
               Name = "Conférence sur le cloud",
               StartDate = new DateTime(2024, 9, 15, 11, 0, 0),
               EndDate = new DateTime(2024, 9, 15, 15, 0, 0),
               State = EventStatus.Pending
           },
           new Event
           {
               Id = 10,
               Name = "Workshop sur les API REST",
               StartDate = new DateTime(2023, 8, 22, 10, 0, 0),
               EndDate = new DateTime(2023, 8, 22, 12, 0, 0),
               State = EventStatus.Passed
           }
       });*/

    }
}