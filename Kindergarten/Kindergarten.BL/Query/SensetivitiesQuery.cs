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
    public class SensetivitiesQuery : SingletoneClass<SensetivitiesQuery>
    {

        public IQueryable<Sensitivity> Get()
        {
          return   SessionFactoryHelper.CurrentSession.Query<Sensitivity>();

        }

        public IQueryable<Sensitivity> Get(List<int> codes)
        {
            return SessionFactoryHelper.CurrentSession.Query<Sensitivity>().Where(x=>codes.Contains(x.Id));
        }
    }
}
