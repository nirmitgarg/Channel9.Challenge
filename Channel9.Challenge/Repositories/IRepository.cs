using System.Collections.Generic;

namespace Channel9.Challenge.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();       
    }
}
