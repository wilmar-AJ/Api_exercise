using MongoDB.Bson;
using Realms;

namespace Api_exercise.Entities;

public class ProductsEntities : RealmObject
{
    [PrimaryKey]
    [MapTo("_id")]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [MapTo("strDrink")]
    public string? Name { get; set; }

    [MapTo("strDrinkThumb")]
    public string? Image { get; set; }
    
   
}
