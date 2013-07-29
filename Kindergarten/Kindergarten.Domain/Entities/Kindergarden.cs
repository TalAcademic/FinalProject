using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    [Serializable]
    public class Kindergarden
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Cities City { get; set; }
        public virtual int ChildQty { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual IList<Child> Children { get; set; }
    }
}
