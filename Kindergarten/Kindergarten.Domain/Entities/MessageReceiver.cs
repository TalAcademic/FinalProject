using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public class MessageRecipient
    {
        public Person Recipient { get; set; }
        public Message Message { get; set; }
    }
}
