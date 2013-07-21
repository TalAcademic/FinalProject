using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Domain.Entities;
using NHibernate.Linq;

namespace Kindergarten.BL.Query
{
    public class TeachersQuery :IQuery<Teacher>
    {
        public Teacher Get(int id)
        {
            return SessionFactoryHelper.CurrentSession.Get<Teacher>(id);
        }

        public IQueryable<Teacher> Get()
        {
            return SessionFactoryHelper.CurrentSession.Query<Teacher>();
        }
    }
}
