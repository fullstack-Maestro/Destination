namespace Destination.Service.DTOs.Transactions;
public class TransactionCreationModel
{
    public long UserId { get; set; }
    public long MetroId { get; set; }
    public DateTime Time { get; set; }
    public long CardId { get; set; }
    public decimal Amount { get; set; } = 2000;
}
