
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Kindergarten.Domain.Mapping;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;


namespace Kindergarten.Data
{
    public static class SessionFactoryHelper
    {
        public static ISession CurrentSession { get { return SessionFactory.GetCurrentSession(); } }

        public static ISessionFactory SessionFactory { get; set; }
        public static void CreateSessionFactory()
        {


            SessionFactory =  Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.
                                                   ConnectionString(
                                                    @"Data Source=(localdb)\Projects;Initial Catalog=Kinder;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
                                                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PersonMap>())
                                                  .ExposeConfiguration(cfg => cfg.SetProperty("current_session_context_class", "web"))
                                                  .BuildSessionFactory();

        }


        public static void CreateSessionFactoryWithDB()
        {


            Configuration configuration = Fluently.Configure()
              .Database(
               MsSqlConfiguration.MsSql2008.ConnectionString(
                                                         @"Data Source=(localdb)\Projects;Initial Catalog=Kinder;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
              .Mappings(m =>
                m.FluentMappings.AddFromAssemblyOf<PersonMap>())
                 .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                 .Create(true, true))
                 .ExposeConfiguration(cfg => cfg.SetProperty("current_session_context_class", "web"))

              .BuildConfiguration();


            SessionFactory= configuration.BuildSessionFactory();
        }
      
    }
}
