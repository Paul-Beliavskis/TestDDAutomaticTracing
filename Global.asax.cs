using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Configuration;
using Serilog;
using System.Net;
using Serilog.Formatting.Compact;
using System.Net.Sockets;
using Serilog.Formatting.Json;

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
            string dynamicInstrumentation = ConfigurationManager.AppSettings["DD_DYNAMIC_INSTRUMENTATION_ENABLED"];

            Environment.SetEnvironmentVariable("COR_ENABLE_PROFILING", corEnableProfiling, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("COR_PROFILER", corProfiler, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("COR_PROFILER_PATH", corProfilerPath, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("DD_DOTNET_TRACER_HOME", dotnetTracerHome, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("DD_DYNAMIC_INSTRUMENTATION_ENABLED", dynamicInstrumentation, EnvironmentVariableTarget.Process);

            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
