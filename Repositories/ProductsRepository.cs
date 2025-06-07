    using Api_exercise.Models;
    using Api_exercise.Repositories.Interfaces;
    using Api_exercise.Responses;
    using Api_exercise.Services.Interfaces;

    namespace Api_exercise.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly IResponseService _apiResponseService;

    public ProductsRepository()
    {
        _apiResponseService = Startup.GetService<IResponseService>();
    }
    public async Task<List<ProductsModel>> GetAllProductsAsync(int page)
    {
        var ProductsClient = _apiResponseService.GetClient<ApiResponse>();

        var response = await ProductsClient.GetAsync<ApiResponse>(
            resource: "filter.php?a=Non_Alcoholic");

        if (response != null)
        {
            return response.Drinks ?? new List<ProductsModel>();
        }
        else
        {
            throw new Exception("Error fetching Products");
        }

    // if (response?.Drinks != null)
    // {
    //     return response.Drinks.Select(drink => new ProductsModel
    //     {
    //         Id = drink.Id,
    //         Name = drink.Name,
    //         Image = drink.Image
    //     }).ToList();
    // }

            // return new List<ProductsModel>();
    }
    // public async Task<List<ProductsModel>> GetAllProductsAsync(int page)
    // {
    //     var productsClient = _apiResponseService.GetClient<ApiResponse>();

         
    //     var response = await productsClient.GetAsync<ApiResponse>(
    //         resource:"filter.php?a=Non_Alcoholic");

    //     if (response != null)
    //     {
    //         return response.Drinks ?? new List<ProductsModel>();
    //     }
    //     else
    //     {
    //         throw new Exception("Error fetching Products");
    //     }
    // }
}
    
