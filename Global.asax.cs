using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Configuration;

namespace SimpleFrameworkApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string corEnableProfiling = ConfigurationManager.AppSettings["COR_ENABLE_PROFILING"];
            string corProfiler = ConfigurationManager.AppSettings["COR_PROFILER"];
            string corProfilerPath = ConfigurationManager.AppSettings["COR_PROFILER_PATH"];
            string dotnetTracerHome = ConfigurationManager.AppSettings["DD_DOTNET_TRACER_HOME"];

            Environment.SetEnvironmentVariable("COR_ENABLE_PROFILING", corEnableProfiling, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("COR_PROFILER", corProfiler, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("COR_PROFILER_PATH", corProfilerPath, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("DD_DOTNET_TRACER_HOME", dotnetTracerHome, EnvironmentVariableTarget.Process);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
