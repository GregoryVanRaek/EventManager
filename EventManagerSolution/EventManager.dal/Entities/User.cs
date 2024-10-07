namespace EventManager.dal.Entities;

public class User
{
    public required int Id { get; set; }
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public required string Email { get; set; }
    public required byte[] PasswordHash { get; set; } 
    public required byte[] PasswordSalt { get; set; } 
    public string Address_Street { get; set; }
    public string Address_Number { get; set; }
    public string Address_Zip { get; set; }
    public string Address_City { get; set; }
    public string Address_Country { get; set; }
    
    public List<Role> Role { get; set; }
    public List<Comment> Comment { get; set; }
    public List<Participation> Participation { get; set; }
}