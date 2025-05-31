using System.Text.Json.Serialization;

namespace Api_exercise.Responses;

public class ProductsResponse
{
    [JsonPropertyName("idDrink")]
    public string? Id { get; set; }

    [JsonPropertyName("strDrink")]
    public string? Name { get; set; }

    [JsonPropertyName("strDrinkThumb")]
    public string? Image { get; set; }


    
}
