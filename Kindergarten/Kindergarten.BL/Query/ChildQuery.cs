using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace Kindergarten.BL.Query
{
    public class ChildQuery :IQuery<Child>
    {
        public Child Get(int id)
        {
            return SessionFactoryHelper.CurrentSession.Get<Child>(id);
        }

        public IQueryable<Child> Get()
        {
            return SessionFactoryHelper.CurrentSession.Query<Child>();
        }
    }
}
