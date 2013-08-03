using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Kindergarten.BL.EventSearcher;
using Kindergarten.BL.Messages;

namespace Kindergarten.Bootstrap
{
    public static class ContainerExtetions
    {
        public static IContainer UpdatedBy(this IContainer container, ContainerBuilder builder)
        {
            builder.Update(container);
            return container;
        }

        public static IContainer WithBuilder(this IContainer container, Action<ContainerBuilder> actionOnBuilder)
        {
            ContainerBuilder builder = new ContainerBuilder();
            actionOnBuilder(builder);
            return container.UpdatedBy(builder);
        }

        public static IContainer WithType(this IContainer container, Type type)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType(type);
            return container.UpdatedBy(builder);
        }

        public static IContainer WithType<T>(this IContainer container)
        {
            return container.WithType(typeof(T));
        }

        public static IContainer WithLogger(this IContainer container, string logName)
        {
            ContainerBuilder builder = new ContainerBuilder();
            //builder.Register(c => new Log(logName)).As<ILogger>();
            return container.UpdatedBy(builder);
        }
        public static IContainer WithMessanger(this IContainer container)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(c => new DBMessagesManager()).As<IMessanger>();
            return container.UpdatedBy(builder);
        }
        public static IContainer WithSearcherFactory(this IContainer container)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(c => new EventSearcherFactory()).As<ISearcherFactory>();
            return container.UpdatedBy(builder);
        }
    }
}
