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
    public class ActivityQuery :IQuery<Activity>
    {
        #region Filter properties
        public Kindergarden Kindergarden { get; set; }
        #endregion
        public Activity Get(int id)
        {
            return SessionFactoryHelper.CurrentSession.Get<Activity>(id);
        }

        public IQueryable<Activity> Get()
        {
            return SessionFactoryHelper.CurrentSession.Query<Activity>();
        }
        public IQueryable<Activity> GetByFilter()
        {
            var query = Get();

            if(Kindergarden != null)
            {
                query = query.Where(x => x.Kindergarden == Kindergarden);
            }
            return query;
        }
    }
}
