using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public class Message
    {
        public virtual int Id{ get; set; }
        public virtual Person Sender { get; set; }
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual DateTime SendTime { get; set; }
        public virtual List<Person> Recipients { get; set; }

    }
}
