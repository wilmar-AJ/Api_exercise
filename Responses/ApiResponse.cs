using System.Text.Json.Serialization;
using Api_exercise.Models;

namespace Api_exercise.Responses;

public class ApiResponse
{
     [JsonPropertyName("items")]
    public List<ProductsModel>? Items { get; set; }
}
