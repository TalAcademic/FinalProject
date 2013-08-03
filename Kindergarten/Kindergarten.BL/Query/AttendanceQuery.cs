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
    public class AttendanceQuery :IQuery<Attendance>
    {
        #region Filter properties
        public Kindergarden Kindergarden { get; set; }
        public DateTime? Date { get; set; }
        #endregion

        public Attendance Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Attendance> Get()
        {
           return  SessionFactoryHelper.CurrentSession.Query<Attendance>();
        }

        public IQueryable<Attendance> GetByFilter ()
        {
            var query = Get();

            if (Kindergarden != null)
            {
                query = query.Where(x => x.Child.Kindergarden == Kindergarden);
            }

            if(Date != null)
            {
                query = query.Where(x => x.Date == Date);
            }
            return query;
        }
    }

 
}
