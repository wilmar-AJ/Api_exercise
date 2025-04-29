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
            _apiResponseService = Startup.GetService<IResponseService>()
            ?? throw new ArgumentNullException(nameof(_apiResponseService), "IResponseService no está configurado.");;
        }

        public async Task<List<ProductsModel>> GetAllProductsAsync(int page)
        {
            var productsClient = _apiResponseService.GetClient<ApiResponse>();

            var response = await productsClient.GetAsync<ApiResponse>(resource: $"products?page={page}&limit=10");

            if (response != null)
            {
                return response.Items ?? new List<ProductsModel>();
            }
            else
            {
                throw new Exception("Error fetching characters");
            }
        }
    }
