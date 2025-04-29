using RestSharp;
using Api_exercise.Services.Interfaces;

namespace Api_exercise.Services;

public class ApiServices<T>
{
    private readonly RestClient _client;

    public ApiServices(string baseUrl)
    {
        if (string.IsNullOrWhiteSpace(baseUrl))
        {
            throw new ArgumentException("La URL base no puede estar vacía", nameof(baseUrl));
        }

        var options = new RestClientOptions(baseUrl)
        {
            ThrowOnAnyError = true,
            Timeout = TimeSpan.FromSeconds(15) // 30 segundos de timeout
        };

        _client = new RestClient(options);

    }

    /// <summary>
    /// Realiza una petición GET con parámetros
    /// </summary>
    /// <param name="resource">Endpoint del recurso</param>
    /// <param name="parameters">Diccionario de parámetros (nombre, valor)</param>
    /// <returns>Respuesta deserializada</returns>
    public async Task<T> GetAsync<Y>(string resource, Dictionary<string, object> parameters = null)
    {
        if (string.IsNullOrWhiteSpace(resource))
        {
            throw new ArgumentException("El recurso no puede estar vacío", nameof(resource));
        }
        var request = new RestRequest(resource, Method.Get);

        if (parameters != null)
        {
            foreach (var param in parameters)
            {
                // Versión actual de RestSharp requiere especificar el tipo de parámetro
                request.AddParameter(param.Key, param.Value, ParameterType.QueryString);
            }
        }

        var response = await _client.ExecuteAsync<T>(request).ConfigureAwait(false);

        if (!response.IsSuccessful)
        {
            throw new HttpRequestException($"Error en la petición: {response.StatusCode} - {response.ErrorMessage}");
        }

        return response.Data;
    }
}
