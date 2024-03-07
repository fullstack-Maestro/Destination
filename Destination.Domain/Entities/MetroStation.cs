using Destination.Domain.Commons;

namespace Destination.Domain.Entities;
public class MetroStation : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string LineName { get; set; }
    public long OrdinalNumber { get; set; }
}
