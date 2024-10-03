using System.ComponentModel.DataAnnotations;

namespace EventManager.Models;

public class AddressFormModel
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Street { get; set; }
    
    [Required]
    public required int Number { get; set; }
    
    [Required]
    [DataType(DataType.PostalCode)]
    public required int Zip { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string City { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string Country { get; set; }
    
    [Required]
    [MaxLength(20)]
    public required string Continent { get; set; }
}