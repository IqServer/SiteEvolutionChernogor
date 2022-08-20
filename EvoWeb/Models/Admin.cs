using System.Text.Json.Serialization;

namespace EvoWeb;

public class Admin
{
    [JsonIgnore]
    public int Id { get; init; }
    [JsonIgnore]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public string Login { get; set; }
    public string Password { get; set; }
}