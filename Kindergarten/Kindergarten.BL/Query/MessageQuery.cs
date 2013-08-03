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
    public class MessageQuery : IQuery<Message>
    {
        #region filter properties
        public Person Person { get; set; }
        #endregion

        public Message Get(int id)
        {
            return SessionFactoryHelper.CurrentSession.Get<Message>(id);
        }

        public IQueryable<Message> Get()
        {
            return SessionFactoryHelper.CurrentSession.Query<Message>();
        }

        public IQueryable<Message> GetByFilter()
        {
            var query = Get();

            if(Person != null)
            {
                query = query.Where(x => x.Recipients.Contains(Person));
            }
            return query;
        }
    }
}
