using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Domain.Entities
{
    public class Holiday
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        private Dictionary<string, double> _shoppingListForChild;
        public Dictionary<string, double> ShoppingListForChild
        {
            get { return _shoppingListForChild ?? (_shoppingListForChild = new Dictionary<string, double>()); }
            set { _shoppingListForChild = value; }
        }
    }
}
