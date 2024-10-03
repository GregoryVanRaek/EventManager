namespace EventManager.dal.Entities;

public class Address
{
    public required int Id { get; set; }
    public required string Street { get; set; }
    public required int Number { get; set; }
    public required int Zip { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public required string Continent { get; set; }
    
    public required int UserId { get; set; }
    public User User { get; set; }
    
    public int EventId { get; set; }
    public List<Event> Events { get; set; }
    
}