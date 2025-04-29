using Api_exercise.Services.Interfaces;

namespace Api_exercise.Services;

public class ResponseService : IResponseService
{
     public ApiServices<T> GetClient<T>()
    {
        return new ApiServices<T>("https://www.thecocktaildb.com/api/json/v1/1/filter.php?a=Non_Alcoholic");
    }
}
