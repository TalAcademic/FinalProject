using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Domain.Mapping
{
    public class SupervisorMap : SubclassMap<Supervisor>
    {
        public SupervisorMap()
        {
            DiscriminatorValue("3");

            Map(x => x.City).CustomType<Cities>();
        }
    }
}
