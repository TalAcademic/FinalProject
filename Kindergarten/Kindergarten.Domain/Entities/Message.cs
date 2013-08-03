using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iesi.Collections.Generic;

namespace Kindergarten.Domain.Entities
{
    public class Message
    {
        public virtual int Id{ get; set; }
        public virtual Person Sender { get; set; }
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual DateTime SendTime { get; set; }
        public virtual ICollection<Person> Recipients { get; set; }

        public Message()
        {
            Recipients = new HashedSet<Person>();
        }

        public override string ToString()
        {
            return SendTime + " " + Title;
        }
    }
}
