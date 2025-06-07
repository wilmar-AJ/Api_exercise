namespace Api_exercise.Validators;

using Api_exercise.Entities;

public static class ProductsValidator
{
    public static bool IsValid(ProductsEntities product)
    {
        
        return !string.IsNullOrWhiteSpace(product.Id)
            && !string.IsNullOrWhiteSpace(product.Name)
            && !string.IsNullOrWhiteSpace(product.Image);
    }
}
