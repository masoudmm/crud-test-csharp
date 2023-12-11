using System.Text.Json.Serialization;

namespace CustomerCrud.Client.Models;

public class ValidationProblemDetails
{
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("errors")]
    public IDictionary<string, string[]> Errors { get; set; }
}