using System.Text.Json.Serialization;

namespace EvoWeb;

public class Request
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FathersName { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public bool IsCustom { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}