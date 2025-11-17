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
            MvcHandler.DisableMvcResponseHeader = true;


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
        
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("Server");
        }
        protected void Application_EndRequest()
        {
            var context = HttpContext.Current;
            if (context.Response.StatusCode == 404 || context.Response.StatusCode == 500)
            {
                // handle if needed
            }

            // Detect large request rejection
            if (context.Response.StatusCode == 404 && context.Request.ContentLength > 0)
            {
                context.Response.Redirect("~/Error/FileTooLarge");
            }
        }
        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;

            if (httpException != null && httpException.GetHttpCode() == 404)
            {
                Response.Clear();
                Server.ClearError();
                Response.Redirect("~/Error/NotFound");
            }
        }

        protected void Application_PreSendRequestHeaders()
        {
            try
            {
                Response.Headers.Remove("X-AspNet-Version");
                HttpContext.Current.Response.Headers.Remove("Server");
            }
            catch (Exception ex)
            {
                // Optional: Log error
            }
        }
    }
}
