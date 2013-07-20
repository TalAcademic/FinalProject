using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public class Message
    {
        public Person Sender { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime SendTime { get; set; }
    }
}
