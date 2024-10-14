namespace EventManager.Models;

public class UserViewModel
{
    public string Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string? Address_Street { get; set; }
    public string? Address_Number { get; set; }
    public string? Address_Zip { get; set; }
    public string? Address_City { get; set; }
    public string? Address_Country { get; set; }
    public bool IsAdmin { get; set; }
}