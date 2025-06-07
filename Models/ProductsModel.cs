using System.Text.Json.Serialization;
using Api_exercise.Entities;
using Api_exercise.Repositories.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Api_exercise.Models;

public partial class ProductsModel : ObservableObject
{
    [JsonPropertyName("idDrink")]
    public string? Id { get; set; }

    [JsonPropertyName("strDrink")]
    public string? Name { get; set; }
    [JsonPropertyName("strDrinkThumb")]
    public string? Image { get; set; }

    public ImageSource ImageSource => Image != null ? ImageSource.FromUri(new Uri(Image)) : null;

    // [ObservableProperty]
    // [property: JsonInclude] 
    // private bool _isSaved;

    [ObservableProperty]
    private bool isSaved;


    [RelayCommand]
    private async Task Save()
    {
        var entity = new ProductsEntities
        {
            Id = Id,
            Name = Name,
            Image = Image
        };

        var repo = Startup.ServicesProvider.GetService<IProductsRealmRepository>();

        if (repo != null)
        {
            repo.saveProducts(entity);
            IsSaved = true;

            await App.Current.MainPage.DisplayAlert("Éxito", "Producto guardado correctamente.", "OK");
        }
    }



}
