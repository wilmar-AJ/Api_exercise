
using Api_exercise.Entities;
using Api_exercise.Repositories.Interfaces;

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
        var realm = _contextRealm.GetRealm();
        realm.Write(() =>
       {
           realm.Add(item);
       });
    }

    public IQueryable<ProductsEntities> GetAllProducts()
    {
        var realm = _contextRealm.GetRealm();
        return realm.All<ProductsEntities>();
    }
}
