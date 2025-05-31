
using Api_exercise.Repositories.Interfaces;

namespace Api_exercise.Repositories;

public class ContexDataBase : IContexDataBase
{
    public Realms.Realm GetRealm()
    {
        return Realms.Realm.GetInstance();
    }
}
