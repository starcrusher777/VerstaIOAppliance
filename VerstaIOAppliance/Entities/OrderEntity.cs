using System.ComponentModel.DataAnnotations;

namespace VerstaIOAppliance.Entities;

public class OrderEntity
{
    [Key]
    public long Id { get; set; }
    public string SenderCity { get; set; }
    public string SenderAddress { get; set; }
    public string RecipientCity { get; set; }
    public string RecipientAddress { get; set; }
    public double Weight { get; set; }
    public DateTime DeliveryDate { get; set; }
}