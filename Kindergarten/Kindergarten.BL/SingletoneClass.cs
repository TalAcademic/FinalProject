using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.BL
{
    public abstract class SingletoneClass<T> where T : new()
    {

        private static T _instance = new T();

        public static T Instance
        {
            get
            {
                if (Equals(_instance, default(T)))
                    _instance = new T();

                return _instance;
            }
        }

        protected SingletoneClass()
        {
        }
    }
}
