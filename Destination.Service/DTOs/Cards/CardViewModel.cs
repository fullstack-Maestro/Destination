namespace Destination.Service.DTOs.Cards;
public class CardViewModel
{
    public long Id { get; set; }
    public string Number { get; set; }
    public string Type { get; set; }
    public long UserId { get; set; }
    public decimal Balance { get; set; }
}
