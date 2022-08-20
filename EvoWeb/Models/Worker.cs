using System.Text.Json.Serialization;

namespace EvoWeb;

public class Worker
{
    [JsonIgnore]
    public int Id { get; init; }
    [JsonIgnore]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FathersName { get; set; }
    public string Post { get; set; }
    public string Description { get; set; }
    public string PhotoLink { get; set; } // на класс заменить
}