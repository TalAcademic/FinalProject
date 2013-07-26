using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Domain.Entities;

namespace Kindergaten.EventSearchers
{
    public class BirthdaySearcher:ISearcher
    {
        public string dd { get; set; }      
        public BirthdaySearcher()
        {
            dd = "dd";
        }
    }
}
