using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Api_exercise.Models;
using Api_exercise.Repositories.Interfaces;
using Api_exercise.Repositories;
using System.Text.Json;

namespace Api_exercise.ViewModels;

public partial class ProductsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ProductsModel> _products;

    [ObservableProperty]
    private bool _isBusy;

    private readonly IProductsRepository _productsRepository;
    private readonly IProductsRealmRepository _productsRealmRepository;

    public ProductsViewModel()
    {
        _productsRepository = Startup.GetService<IProductsRepository>();
        _productsRealmRepository = Startup.GetService<IProductsRealmRepository>();
        Products = new ObservableCollection<ProductsModel>();
    }

    [RelayCommand]
    public async Task LoadDataProducts()
    {
        IsBusy = true;

        int maxIntentos = 3;
        int intento = 0;
        bool exito = false;

        while (intento < maxIntentos && !exito)
        {
            try
            {
                // 🔄 Trae los productos desde la API
                var apiProducts = await _productsRepository.GetAllProductsAsync(1);

                // 🔍 Trae los productos guardados en Realm
                var savedItems = _productsRealmRepository.GetAllProducts().ToList();

                // 🔄 Compara y marca los guardados
                var result = apiProducts.Select(p =>
                {
                    var isAlreadySaved = savedItems.Any(s => s.Id == p.Id);
                    return new ProductsModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Image = p.Image,
                        IsSaved = isAlreadySaved
                    };
                }).ToList();

                Products = new ObservableCollection<ProductsModel>(result);
                exito = true;
            }
            catch (TimeoutException)
            {
                intento++;
                if (intento >= maxIntentos)
                    await Shell.Current.DisplayAlert("Error", "La solicitud tardó demasiado. Revisa tu conexión a internet.", "OK");
                else
                    await Task.Delay(1000);
            }
            catch (HttpRequestException)
            {
                intento = maxIntentos;
                await Shell.Current.DisplayAlert("Error", "No se pudo conectar al servidor. ¿Estás conectado a internet?", "OK");
            }
            catch (Exception ex)
            {
                intento = maxIntentos;
                await Shell.Current.DisplayAlert("Error inesperado", ex.Message, "OK");
            }
        }

        await Task.Delay(500);
        IsBusy = false;
    }
}
