using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using log4net.Config;

[assembly: XmlConfigurator(Watch = true)]
namespace PSR
{
    public class MvcApplication : System.Web.HttpApplication
    {
        ILog ErrorLog = LogManager.GetLogger("DBLogger");
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();

            ErrorLog.Error("Application started");

            // In any action, below code can be written to write in log file
            try
            {
                ErrorLog.Info("Database connection details: " + ConfigurationManager.ConnectionStrings["PSREntities"].ConnectionString);

            }

            catch (SqlException ex)
            {
                ErrorLog.Error("SQL Database Error: " + ex.ToString());
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.Message);
            }


    }
}
}
