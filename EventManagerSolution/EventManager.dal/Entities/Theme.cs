namespace EventManager.dal.Entities;

public class Theme
{
    public int? Id { get; set; }
    public required string Name { get; set; }
    
    public List<Days> Days { get; set; }
}