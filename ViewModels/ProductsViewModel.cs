using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Api_exercise.Models;
using Api_exercise.Repositories.Interfaces;
using System.Text.Json;

namespace Api_exercise.ViewModels;

public partial class ProductsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ProductsModel> _products = new();

    [ObservableProperty]
    private bool _isBusy;

    private const string SavedProductsKey = "saved_products";
    private readonly IProductsRepository _productsRepository;

        public ProductsViewModel(IProductsRepository productsRepository)
    {
        
        _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        LoadInitialProducts();
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

    private void LoadInitialProducts()
    {
        var savedJson = Preferences.Get(SavedProductsKey, string.Empty);
        if (!string.IsNullOrEmpty(savedJson))
        {
            try
            {
                var savedProducts = JsonSerializer.Deserialize<List<ProductsModel>>(savedJson);
                if (savedProducts != null && savedProducts.Count > 0)
                {
                    foreach (var product in savedProducts)
                    {
                        var existing = Products.FirstOrDefault(p => p.Id == product.Id);
                        if (existing != null) existing.IsSaved = true;
                    }
                }
            }
            catch
            {
                Preferences.Remove(SavedProductsKey);
            }
        }
    }

    private void MarkSavedProducts()
    {
        var savedJson = Preferences.Get(SavedProductsKey, string.Empty);
        if (string.IsNullOrEmpty(savedJson)) return;

        try
        {
            var savedProducts = JsonSerializer.Deserialize<List<ProductsModel>>(savedJson);
            if (savedProducts == null) return;

            foreach (var product in Products)
            {
                product.IsSaved = savedProducts.Any(sp => sp.Id == product.Id);
            }
        }
        catch
        {
            Preferences.Remove(SavedProductsKey);
        }
    }

    [RelayCommand]
    public void ToggleSaveProduct(ProductsModel product)
    {
        if (product == null) return;
        product.IsSaved = !product.IsSaved;
        SaveCurrentSelection();
    }

    private void SaveCurrentSelection()
    {
        var savedProducts = Products.Where(p => p.IsSaved).ToList();
        var json = JsonSerializer.Serialize(savedProducts);
        Preferences.Set(SavedProductsKey, json);
    }
}
