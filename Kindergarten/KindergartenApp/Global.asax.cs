using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Kindergarten.BL;
using KindergartenApp;
using NHibernate;
using Autofac;
using Kindergarten.Bootstrap;
using Autofac.Integration.Web;


namespace KindergartenApp
{
    public class Global : HttpApplication,IContainerProviderAccessor
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            SessionFactoryHelper.CreateSessionFactoryWithDB();
            
            _containerProvider = new ContainerProvider(ContainerCreationExtentions.CreateNew().LoadDefaultPackage("KindergartenApp"));
            
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
            session.Dispose();
        }
        static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
    }
}
