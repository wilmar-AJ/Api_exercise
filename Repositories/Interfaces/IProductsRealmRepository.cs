
using Api_exercise.Entities;

namespace Api_exercise.Repositories.Interfaces;

public interface IProductsRealmRepository
{
    void saveProducts(ProductsEntities item);

    IQueryable<ProductsEntities> GetAllProducts();
}
