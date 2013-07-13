using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.BL.Utils
{
    public static class EnumUtils
    {
        public static IEnumerable<string> GetDescriptions(Type type)
        {
            var descs = new List<string>();
            var names = Enum.GetNames(type);
            foreach (var name in names)
            {
                var field = type.GetField(name);
                var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                descs.AddRange(from DescriptionAttribute fd in fds select fd.Description);
            }
            return descs;
        }
    }
}
