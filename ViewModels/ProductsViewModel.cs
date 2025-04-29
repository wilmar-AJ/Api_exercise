
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Api_exercise.Models;
using Api_exercise.Repositories.Interfaces;


//CARRO 

namespace Api_exercise.ViewModels;

public partial class ProductsViewModel : ObservableObject
{
    [ObservableProperty]
    public ObservableCollection<ProductsModel> _products;

    [ObservableProperty]
    private bool _isBusy;

    private IProductsRepository _productsRepository;

    public ProductsViewModel()
    {
        _productsRepository = Startup.GetService<IProductsRepository>();
    }


    [RelayCommand]
    public async virtual Task LoadDataProducts()
    {
        IsBusy = true;

        var products = await _productsRepository.GetAllProductsAsync(1);

        Products = new ObservableCollection<ProductsModel>(products);

        await Task.Delay(TimeSpan.FromSeconds(3));
        
        IsBusy = false;
    }
}
