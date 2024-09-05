namespace VerstaIOAppliance.Models;

public class OrderModel
{
    public long Id { get; set; }
    public string SenderCity { get; set; }
    public string SenderAddress { get; set; }
    public string RecipientCity { get; set; }
    public string RecipientAddress { get; set; }
    public string Weight { get; set; }
    public string DeliveryDate { get; set; }
}