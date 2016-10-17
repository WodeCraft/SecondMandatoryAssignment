using MbmStore.Infrastructure.Binders;
using MbmStore.ViewModels;
using System.Web.Mvc;
using System.Web.Routing;

namespace MbmStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Add custom model binder
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
