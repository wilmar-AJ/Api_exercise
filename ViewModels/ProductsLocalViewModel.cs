using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Api_exercise.Models;
using Api_exercise.Repositories;
using Api_exercise.Repositories.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Api_exercise.ViewModels;

public partial class ProductsLocalViewModel : ObservableObject
{
    [ObservableProperty]
    public ObservableCollection<ProductsModel> products;

    [ObservableProperty]
    private bool isBusy;

    private readonly IProductsRealmRepository _productsRealmRepository;

    public ProductsLocalViewModel()
    {
        _productsRealmRepository = Startup.GetService<IProductsRealmRepository>();
        Products = new ObservableCollection<ProductsModel>();
    }

    [RelayCommand]
    public async Task LoadDataProducts()
    {
       if (IsBusy)
            return;

      

        try
        {
            IsBusy = true;
            await Task.Delay(500); // Simulate some delay if needed

            var productsList = _productsRealmRepository.GetAllProducts().ToList();
            Products = new ObservableCollection<ProductsModel>(productsList.Select(p => new ProductsModel
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                IsSaved = true // Assuming all loaded products are saved
            }));
        }
        finally
        {
            IsBusy = false;
        }
    }

}
