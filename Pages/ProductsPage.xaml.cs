using Api_exercise.ViewModels;

namespace Api_exercise.Pages;

public partial class ProductsPage : ContentPage
{
    public ProductsPage(ProductsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
     protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = BindingContext as ProductsViewModel;
        if (viewModel != null && viewModel.Products.Count == 0)
        {
            viewModel.LoadDataProductsCommand.Execute(null);
        }
    }

}