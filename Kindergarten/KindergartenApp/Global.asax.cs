using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Kindergarten.BL;
using Kindergarten.Data;
using Kindergarten.Domain.Entities;
using KindergartenApp;
using NHibernate;
using Autofac;
using Kindergarten.Bootstrap;
using Autofac.Integration.Web;
using NHibernate.Linq;


namespace KindergartenApp
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            SessionFactoryHelper.CreateSessionFactory();

            _containerProvider = new ContainerProvider(ContainerCreationExtentions.CreateNew().LoadDefaultPackage("KindergartenApp"));

            using (var session = SessionFactoryHelper.SessionFactory.OpenSession())
            {

                var exist = session.Query<Sensitivity>().Any();

                if (!exist)
                {
                    var s1 = new Sensitivity { Description = "לקטוז" };
                    var s2 = new Sensitivity { Description = "גלוטן" };
                    var s3 = new Sensitivity { Description = "בוטנים" };
                    var s4 = new Sensitivity { Description = "אגוזים" };
                    var s5 = new Sensitivity { Description = "ביצים" };
                    session.Save(s1);
                    session.Save(s2);
                    session.Save(s3);
                    session.Save(s4);
                    session.Save(s5);
                }
            }
        }


        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var session = SessionFactoryHelper.SessionFactory.OpenSession();
            NHibernate.Context.CurrentSessionContext.Bind(session);

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {

            var session = NHibernate.Context.CurrentSessionContext.Unbind(SessionFactoryHelper.SessionFactory);
            session.Flush();
            session.Dispose();
        }
        static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
    }
}
