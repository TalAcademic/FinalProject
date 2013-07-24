using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public class Supervisor :Person
    {
        public virtual Cities City { get; set; }
    }
}
