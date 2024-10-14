namespace EventManager.dal.Entities;

public class User
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? Address_Street { get; set; }
    public string? Address_Number { get; set; }
    public string? Address_Zip { get; set; }
    public string? Address_City { get; set; }
    public string? Address_Country { get; set; }
    public bool IsAdmin { get; set; } = false;
    public List<Comment> Comment { get; set; }
    public List<Participation> Participation { get; set; }
}