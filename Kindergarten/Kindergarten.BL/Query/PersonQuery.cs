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
    public class PersonQuery :SingletoneClass<PersonQuery>,IQuery<Person>
    {
        public Person Get(int id)
        {
            return SessionFactoryHelper.CurrentSession.Get<Person>(id);
        }

        public IQueryable<Person> Get()
        {
            return SessionFactoryHelper.CurrentSession.Query<Person>();
        }

        public IQueryable<Person> GetByIdNum(string idNum)
        {
            return SessionFactoryHelper.CurrentSession.Query<Person>().Where(x=>x.IdNum == idNum);
        }
    }
}
