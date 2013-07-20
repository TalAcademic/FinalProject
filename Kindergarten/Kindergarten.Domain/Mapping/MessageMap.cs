using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Domain.Mapping
{
    public class MessageMap : SubclassMap<Message>
    {
        public MessageMap()
        {
            Map(x=>x.Title);
            Map(x => x.Body);
            Map(x => x.SendTime);
            References(x => x.Sender);
            HasManyToMany(x => x.Recipients).Cascade.All();
        }
    }
}
