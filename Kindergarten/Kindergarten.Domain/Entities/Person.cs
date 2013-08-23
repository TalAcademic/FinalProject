using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace Kindergarten.Domain.Entities
{
    [Serializable]
    public abstract class Person
    {
        public virtual int Id { get; set; }
        public virtual string IdNum { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNum { get; set; }

        public virtual DateTime BirthDay { get; set; }

        public virtual string Password { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        protected Person()
        {
            Messages = new HashedSet<Message>();
        }

        protected bool Equals(Person other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
