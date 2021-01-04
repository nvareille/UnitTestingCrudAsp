using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CICDAPI
{
    public interface IRepository<T>
    {
        List<T> GetEntities();
        IEnumerable<T> Filter(Func<T, bool> fct);

    }
}
