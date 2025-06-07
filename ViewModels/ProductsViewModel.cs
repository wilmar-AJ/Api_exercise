using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Api_exercise.Models;
using Api_exercise.Repositories.Interfaces;
using System.Text.Json;
using Api_exercise.Repositories;

namespace Api_exercise.ViewModels;

public partial class ProductsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ProductsModel> _products;

    [ObservableProperty]
    private bool _isBusy;

    // private const string SavedProductsKey = "saved_products";
    private readonly IProductsRepository _productsRepository;

        public ProductsViewModel()
    {
        _productsRepository = Startup.GetService<IProductsRepository>();
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
                var products = await _productsRepository.GetAllProductsAsync(1);
                Products = new ObservableCollection<ProductsModel>(products);
                exito = true;
            }
            catch (TimeoutException)
            {
                intento++;
                if (intento >= maxIntentos)
                    await Shell.Current.DisplayAlert("Error", "La solicitud tardó demasiado. Revisa tu conexión a internet.", "OK");
                else
                    await Task.Delay(1000); // Espera 1 segundo antes de reintentar
            }
            catch (HttpRequestException)
            {
                intento = maxIntentos; // No seguir intentando si no hay conexión
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
    // [RelayCommand]
    // public async Task save()
    // {
    //     if (Products == null)
    //     {
    //         await App.Current.MainPage.DisplayAlert("Error", "No hay detalles para guardar", "OK");
    //         return;
    //     }
    //     var item = Products.ToEntity();
    //     ProductsRealmRepository.saveProducts(item);
    // }
}

   

