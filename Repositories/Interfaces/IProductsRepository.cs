using Api_exercise.Models;

namespace Api_exercise.Repositories.Interfaces;

public interface IProductsRepository
{
    Task<List<ProductsModel>> GetAllProductsAsync(int page);
}
