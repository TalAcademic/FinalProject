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
    public class KindergardenQuery : SingletoneClass<KindergardenQuery>, IQuery<Kindergarden>
    {
        public Kindergarden Get(int id)
        {
            return SessionFactoryHelper.CurrentSession.Get<Kindergarden>(id);
        }

        public IQueryable<Kindergarden> Get()
        {
            return SessionFactoryHelper.CurrentSession.Query<Kindergarden>();
        }
    }
}
