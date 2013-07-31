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
    public class KindergardenQuery :  IQuery<Kindergarden>
    {
        #region Filter properties
        public string Name { get; set; }
        public Cities? City { get; set; }
        public int? TeacherId { get; set; }
        #endregion

        public Kindergarden Get(int id)
        {
            return SessionFactoryHelper.CurrentSession.Get<Kindergarden>(id);
        }

        public IQueryable<Kindergarden> Get()
        {
            return SessionFactoryHelper.CurrentSession.Query<Kindergarden>();
        }

        public IQueryable<Kindergarden> GetByFilter()
        {
            var query = Get();

            if (Name != null)
            {
                query = query.Where(x => x.Name.Contains(Name));
            }

            if (City != null)
            {
                query = query.Where(x => x.City == City.Value);
                
            }

            if (TeacherId != null)
            {
                query = query.Where(x => x.Teacher.Id == TeacherId);

            }

            return query;
        }
    }
}
