using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    [Serializable]
    public class Sensitivity 
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
    }
}
