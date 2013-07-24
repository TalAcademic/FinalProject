using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public class Activity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Kindergarden Kindergarden { get; set; }
        public virtual ActivityTypes Type { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Info { get; set; }
    }
}
