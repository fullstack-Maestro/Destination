using Destination.Domain.Commons;

namespace Destination.Domain.Entities;
public class Transaction : Auditable
{
    public long MetroId { get; set; }
    public MetroStation MetroStation { get; set; }
    public DateTime Time { get; set; }
    public long CardId { get; set; }
    public Card Card { get; set; }
}
