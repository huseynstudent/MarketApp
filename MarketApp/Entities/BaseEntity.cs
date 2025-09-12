using System.ComponentModel.DataAnnotations;

namespace MarketApp.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; } 
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
