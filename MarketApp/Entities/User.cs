using System.ComponentModel.DataAnnotations;

namespace MarketApp.Entities;

public class User: BaseEntity
{
    [MaxLength(100)]
    public string? FirstName { get; set; }
    [MaxLength(100)]
    public string? LastName { get; set; }
    public string? Email { get; set; }
    [Required]
    public string? PasswordHash { get; set; }
    public List<Order>? Orders { get; set; } // Navigation Property
}
