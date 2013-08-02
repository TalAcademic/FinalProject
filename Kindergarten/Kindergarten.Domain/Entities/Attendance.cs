using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public class Attendance
    {
        public virtual Child Child { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual bool Arrived { get; set; }

        protected bool Equals(Attendance other)
        {
            return Equals(Child, other.Child) && Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Attendance) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Child != null ? Child.GetHashCode() : 0)*397) ^ Date.GetHashCode();
            }
        }
    }
}
