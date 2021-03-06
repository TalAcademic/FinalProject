﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Domain.Mapping
{
    public class KindergardenMap : ClassMap<Kindergarden>
    {
        public KindergardenMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.ChildQty);
            Map(x => x.City).CustomType<Cities>();
            References(x => x.Teacher).Not.LazyLoad();
            HasMany(x => x.Children).Cascade.None();
        }
    }
}
