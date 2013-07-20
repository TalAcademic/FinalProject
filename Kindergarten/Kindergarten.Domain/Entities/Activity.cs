using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public class Activity
    {
        public string Name { get; set; }
        public Kindergarden Kindergarden { get; set; }
        public ActivityTypes Type { get; set; }
        public DateTime Date { get; set; }
        public string Info { get; set; }
    }
}
