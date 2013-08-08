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
    public class SupervisorQuery :IQuery<Supervisor>
    {
        #region Filter Properties
        public Cities? City { get; set; }
        #endregion
        public Supervisor Get(int id)
        {
            return SessionFactoryHelper.CurrentSession.Get<Supervisor>(id);
        }

        public IQueryable<Supervisor> Get()
        {
            return SessionFactoryHelper.CurrentSession.Query<Supervisor>();
        }

        public IQueryable<Supervisor> GetByFilter()
        {
            var query = Get();

            if (City != null)
            {
                query = query.Where(x => x.City == City);
            }
            return query;
        }
    }
}
