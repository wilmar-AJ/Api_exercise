using System.Text.Json.Serialization;

namespace Api_exercise.Models;

public class ProductsModel
{
    
        [JsonPropertyName("idDrink")]
        public int Id { get; set; }

        [JsonPropertyName("strDrink")]
        public string? Name { get; set; }

        [JsonPropertyName("strDrinkThumb")]
        public string? Image { get; set; }
}
