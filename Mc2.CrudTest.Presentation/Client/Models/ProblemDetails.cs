﻿using System.Text.Json.Serialization;

namespace Mc2.CrudTest.Presentation.Client.Models;

public class ProblemDetails
{
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("detail")]
    public string Detail { get; set; }
}