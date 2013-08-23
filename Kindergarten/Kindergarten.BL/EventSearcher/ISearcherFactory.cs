using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Domain.Entities;

namespace Kindergarten.BL.EventSearcher
{
    public interface ISearcherFactory
    {
        ISearcher GetSearcher(string name);
        List<ISearcher> GetAllSearchers();
    }
}
