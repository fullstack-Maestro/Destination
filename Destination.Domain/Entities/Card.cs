using Destination.Domain.Commons;

namespace Destination.Domain.Entities;
public class Card : Auditable
{
    public string Number { get; set; }
    public string Type { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public decimal Balance { get; set; }
}
