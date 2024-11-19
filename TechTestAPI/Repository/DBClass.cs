namespace Repository;
using System.Text.Json.Serialization;

public class DBClass
{
    [JsonPropertyName("images")]
    public List<Image> Images { get; set; } = new();
}

public class Image
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    public string ReturnType { get; set; } = string.Empty;
}
