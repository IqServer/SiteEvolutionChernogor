using System.Text.Json.Serialization;

namespace EvoWeb;

public class Project
{
    public int Id { get; init; }
    [JsonIgnore]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string AdvertLink { get; set; }
    public string IconLink { get; set; }
    public uint Price { get; set; }
    public string DownLink { get; set; }
}