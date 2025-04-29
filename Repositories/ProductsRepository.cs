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
        var productsClient = _apiResponseService.GetClient<ApiResponse>();

        // Solicitar todos los productos no alcohólicos desde la API
        var response = await productsClient.GetAsync<ApiResponse>(
            resource:"filter.php?a=Non_Alcoholic");

        if (response != null)
        {
            return response.Drinks ?? new List<ProductsModel>();
        }
        else
        {
            throw new Exception("Error fetching Products");
        }
    }
}
    
