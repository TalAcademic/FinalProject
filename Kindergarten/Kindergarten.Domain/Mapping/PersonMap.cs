using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Domain.Mapping
{
    public class PersonMap :ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id);
            Map(x => x.IdNum);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.BirthDay);
            Map(x => x.PhoneNum);
            HasManyToMany(x => x.Messages).Cascade.All();
            Map(x => x.Password);

            DiscriminateSubClassesOnColumn("Type").Not.Nullable();
        }
    }
}
