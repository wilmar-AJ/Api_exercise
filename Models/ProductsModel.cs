using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Api_exercise.Models;

public partial class ProductsModel : ObservableObject
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public ImageSource ImageSource => Image != null ? ImageSource.FromUri(new Uri(Image)) : null;

    [ObservableProperty]
    [property: JsonInclude] 
    private bool _isSaved;
}
