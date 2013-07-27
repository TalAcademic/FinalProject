using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iesi.Collections.Generic;

namespace Kindergarten.Domain.Entities
{
    [Serializable]
    public class Child : Person
    {
        public virtual ICollection<Sensitivity> Sensitivitieses { get; set; }

        public  Child()
        {
            Sensitivitieses = new HashedSet<Sensitivity>();
        }
    }
}
