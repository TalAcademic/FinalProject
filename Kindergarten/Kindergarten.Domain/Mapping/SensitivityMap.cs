using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Domain.Mapping
{
    public class SensitivityMap : ClassMap<Sensitivity>
    {
        public SensitivityMap()
        {
            Id(x => x.Code).GeneratedBy.Assigned();
            Map(x => x.Description);
        }
    }
}
