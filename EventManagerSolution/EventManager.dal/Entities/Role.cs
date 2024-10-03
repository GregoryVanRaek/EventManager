namespace EventManager.dal.Entities;

public class Role
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public List<User> Users { get; set; }
}