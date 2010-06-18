using System.Web.Mvc;
using System.Web.Routing;
using Spark;

namespace dotlesscss.com
{
    using System;
    using dotless.Core.configuration;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  public class MvcApplication : System.Web.HttpApplication
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
        "root",
        "", new { controller = "Home", action = "Index" });

      routes.MapRoute(
        "docs",
        "docs.aspx/{chapterName}/{topicName}",
        new { controller = "Home", action = "Reference", topicName = UrlParameter.Optional });

      routes.MapRoute(
        "default",
        "{action}.aspx", new { controller = "Home", action = "Index" });
    }

    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      RegisterRoutes(RouteTable.Routes);

      DotlessConfiguration.Default.Logger = typeof(HttpContextLogger);
      DotlessConfiguration.Default.Web = true;
      DotlessConfiguration.Default.CacheEnabled = false;

      ISparkSettings settings = new SparkSettings()
        .SetStatementMarker("#>"); // change the statement marker because css lines may start with #

      var viewFactory = new Spark.Web.Mvc.SparkViewFactory(settings);

      ViewEngines.Engines.Clear();
      ViewEngines.Engines.Add(viewFactory);
    }
  }
}