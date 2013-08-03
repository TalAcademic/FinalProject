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

        public static T CreateType<T>()
        {
            return (T)CreateType(typeof(T));
        }

        public static object CreateType(Type type)
        {
            return CreateType(type, c => { });
        }

        public static T CreateType<T>(Action<IContainer> actionOnContainer)
        {
            return (T)CreateType(typeof(T), actionOnContainer);
        }

        public static object CreateType(Type type, Action<IContainer> actionOnContainer)
        {
            IContainer container = CreateNew();
            container.LoadDefaultPackage(type.Name).WithType(type);
            actionOnContainer(container);
            container.WithType(type);
            return container.Resolve(type);
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
