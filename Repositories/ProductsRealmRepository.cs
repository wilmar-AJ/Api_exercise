using Api_exercise.Entities;
using Api_exercise.Repositories.Interfaces;
using Api_exercise.Validators;
using FluentValidation;

namespace Api_exercise.Repositories;

public class ProductsRealmRepository : IProductsRealmRepository
{
    private readonly IContexDataBase _contextRealm;

    public ProductsRealmRepository()
    {
        _contextRealm = Startup.ServicesProvider.GetService<IContexDataBase>();
    }

    public void saveProducts(ProductsEntities item)
    {
        var validator = new ProductsEntitiesValidator();
        var result = validator.Validate(item);

        if (!result.IsValid)
        {
            var errors = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException(errors); // 👈 Así como el de tu amigo
        }

        var realm = _contextRealm.GetRealm();
        realm.Write(() =>
        {
            realm.Add(item, update: true);
        });
    }

    public IQueryable<ProductsEntities> GetAllProducts()
    {
        var realm = _contextRealm.GetRealm();
        return realm.All<ProductsEntities>();
    }
}
