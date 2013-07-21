using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.BL.Edit
{
    public interface IEdit<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
