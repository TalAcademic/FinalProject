using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.BL.Query
{
    public interface IQuery<T>
    {
        T Get(int id);
        IQueryable<T> Get();
    }
}
