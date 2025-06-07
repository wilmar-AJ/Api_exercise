using Api_exercise.Entities;
using Api_exercise.Repositories.Interfaces;
using Api_exercise.Validators; // 👈 importante

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
        if (!ProductsValidator.IsValid(item))
            return; // 👈 Si no es válido, no hace nada

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
