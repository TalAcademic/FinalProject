using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten.Domain.Entities
{
    public class Event
    {
        public string SpecificType { get; set; }
        public string Title { get; set; }
        private Dictionary<string, double> _shoppingListForChild;
        public Dictionary<string, double> ShoppingListForChild
        {
            get
            {
                if (_shoppingListForChild == null)
                    _shoppingListForChild = new Dictionary<string, double>();
                return _shoppingListForChild;
            }
            set { _shoppingListForChild = value; }
        }
    }
}
