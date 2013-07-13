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

namespace KindergartenApp
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            SessionFactoryHelper.CreateSessionFactoryWithDB();
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
    }
}
