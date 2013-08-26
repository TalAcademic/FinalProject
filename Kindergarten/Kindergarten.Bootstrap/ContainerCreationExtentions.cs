using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Kindergarten.Bootstrap
{
    public static class ContainerCreationExtentions
    {
        public static IContainer CreateNew()
        {
            return new ContainerBuilder().Build();
        }

        public static IContainer LoadDefaultPackage(this IContainer container, string name)
        {
            container
                .WithMessanger()
                .WithSearcherFactory();
                
            return container;
        }

        


    }
}
