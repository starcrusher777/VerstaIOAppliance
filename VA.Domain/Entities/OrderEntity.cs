using System.ComponentModel.DataAnnotations;

namespace VA.Domain.Entities;

public class OrderEntity
{
    [Key]
    public long Id { get; set; }
    
    [Required]
    public string SenderCity { get; set; } = null!;
    public string SenderAddress { get; set; } = null!;
    public string RecipientCity { get; set; } = null!;
    public string RecipientAddress { get; set; } = null!;
    public double Weight { get; set; }
    public DateTime DeliveryDate { get; set; }
    public DateTime CreatedAt { get; set; }
}