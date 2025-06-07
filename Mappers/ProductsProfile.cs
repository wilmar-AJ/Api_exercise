using Api_exercise.Entities;
using Api_exercise.Models;

namespace Api_exercise.Extensions;

public static class ProsductsProfile
{
    public static ProductsEntities ToEntity(this ProductsModel obj)
    {
        return new ProductsEntities
        {
            Id = obj.Id,
            Name = obj.Name,
            Image = obj.Image
        };
    }
  
}
 