using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    [Serializable]
    public class Teacher :Person
    {
        public virtual int Seniority { get; set; }
        public virtual Teacher Substitute { get; set; }

    }
}
