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
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.BirthDay);
            Map(x => x.PhoneNum);

            DiscriminateSubClassesOnColumn("Type").Not.Nullable();
        }
    }
}
