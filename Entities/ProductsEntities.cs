using Api_exercise.Models;
using MongoDB.Bson;
using Realms;

namespace Api_exercise.Entities;

public class ProductsEntities : RealmObject
{
    [PrimaryKey]
    [MapTo("_id")]
    public string? Id { get; set; }

    [MapTo("strDrink")]
    public string? Name { get; set; }

    [MapTo("strDrinkThumb")]
    public string? Image { get; set; }

    // Este método convierte de entidad Realm a modelo de UI
    public ProductsModel ToModel()
    {
        return new ProductsModel
        {
            Id = this.Id,
            Name = this.Name,
            Image = this.Image,
            IsSaved = true
        };
    }
}
