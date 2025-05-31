using System.Text.Json.Serialization;
using Api_exercise.Models;

namespace Api_exercise.Responses;

public class ApiResponse
{
     [JsonPropertyName("drinks")]
    public List<ProductsResponse>? Drinks { get; set; }
}
