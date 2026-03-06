namespace VA.Infrastructure.Models;

public class OrderModel
{
    public long Id { get; set; }
    public string SenderCity { get; set; } = null!;
    public string SenderAddress { get; set; } = null!;
    public string RecipientCity { get; set; } = null!;
    public string RecipientAddress { get; set; } = null!;
    public string Weight { get; set; } = null!;
    public string DeliveryDate { get; set; } = null!;
    public string CreatedAt { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
}