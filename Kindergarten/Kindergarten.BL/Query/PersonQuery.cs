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
    public class PersonQuery : IQuery<Person>
    {
        #region Filter properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNum { get; set; }
        public DateTime? BirthDate { get; set; }
        #endregion

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
            return SessionFactoryHelper.CurrentSession.Query<Person>().Where(x => x.IdNum == idNum);
        }

        public IQueryable<Person> GetByFilter()
        {
            var query = Get();

            if (FirstName != null)
            {
                query = query.Where(x => x.FirstName.Contains(FirstName));
            }

            if (LastName != null)
            {
                query = query.Where(x => x.LastName.Contains(LastName));
            }

            if (IdNum != null)
            {
                query = query.Where(x => x.IdNum.Contains(IdNum));
            }

            if (BirthDate != null)
            {
                query = query.Where(x => x.BirthDay == BirthDate);
            }
            return query;
        }
    }
}
