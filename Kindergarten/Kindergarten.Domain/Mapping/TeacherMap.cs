using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Domain.Mapping
{
    public class TeacherMap :SubclassMap<Teacher>
    {
        public TeacherMap()
        {
            DiscriminatorValue("2");
            Map(x => x.Seniority);
            References(x => x.Substitute);
            References(x => x.Kindergarden).Not.LazyLoad();
        }
    }
}
