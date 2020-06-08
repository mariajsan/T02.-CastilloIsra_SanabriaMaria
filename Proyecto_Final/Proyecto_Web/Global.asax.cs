using Proyecto_Web.Class;
using Proyecto_Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Proyecto_Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            /*this.CheckRoles();
            Utilities.CheckSuperUser();
            Utilities.CheckClientDefault();*/
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }

        private void CheckRoles()
        {
            Utilities.CheckRoles("Admin");
            Utilities.CheckRoles("Author");
            Utilities.CheckRoles("Reader");
        }
    }
}
