namespace Destination.Service.DTOs.MetroStations;
public class MetroStationViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int OrdinalNumberInItsLine { get; set; }
    public string LineName { get; set; }
}
