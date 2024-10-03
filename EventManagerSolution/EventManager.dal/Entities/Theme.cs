namespace EventManager.dal.Entities;

public class Theme
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    
    public List<Days> Days { get; set; }
}