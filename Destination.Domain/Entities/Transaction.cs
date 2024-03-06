using Destination.Domain.Commons;

namespace Destination.Domain.Entities;
public class Transaction : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long MetroId { get; set; }
    public MetroStation MetroStation { get; set; }
    public DateTime Time { get; set; }
    public long CardId { get; set; }
    public Card Card { get; set; }
    public decimal Amount { get; set; } = 2000;
}
