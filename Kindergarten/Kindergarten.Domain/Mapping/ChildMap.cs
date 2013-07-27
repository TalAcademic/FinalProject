using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Domain.Mapping
{
    public class ChildMap :SubclassMap<Child>
    {
        public ChildMap()
        {
            DiscriminatorValue("1");
            HasManyToMany(x => x.Sensitivitieses).AsSet().Cascade.None();
        }
    }
}
