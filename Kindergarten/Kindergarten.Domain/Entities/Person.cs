﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNum { get; set; }

        public virtual DateTime BirthDay { get; set; }

        public virtual string FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }
}
