using System.ComponentModel.DataAnnotations;

namespace VA.Domain.Entities;

public class OrderEntity
{
    [Key]
    public long Id { get; set; }
    
    [Required]
    public string SenderCity { get; set; }
    public string SenderAddress { get; set; }
    public string RecipientCity { get; set; }
    public string RecipientAddress { get; set; }
    public double Weight { get; set; }
    public DateTime DeliveryDate { get; set; }
    public DateTime CreatedAt { get; set; }
}