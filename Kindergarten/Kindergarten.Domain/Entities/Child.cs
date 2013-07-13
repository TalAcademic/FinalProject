using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public class Child : Person
    {
        public virtual IList<Sensitivity> Sensitivitieses { get; set; }
    }
}
