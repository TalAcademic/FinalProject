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

        public static IContainer WithMessanger(this IContainer container)
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new DBMessagesManager()).As<IMessanger>();
            return container.UpdatedBy(builder);
        }
        public static IContainer WithSearcherFactory(this IContainer container)
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new EventSearcherFactory()).As<ISearcherFactory>();
            return container.UpdatedBy(builder);
        }
    }
}
