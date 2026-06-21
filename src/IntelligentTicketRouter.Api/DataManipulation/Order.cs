namespace IntelligentTicketRouter.Api.DataManipulation;


public class Order
{
    public int Id { get; set; }
    public string CustomerEmail { get; set; } = string.Empty;
    public string Item { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime DeliveryDate { get; set; }
}
