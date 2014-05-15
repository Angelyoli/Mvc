using Microsoft.AspNet;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using MvcSample.Web.Filters;

namespace MvcSample.Web
{
    public class Startup
    {
        public void Configure(IBuilder app)
        {
            app.UseServices(services =>
            {
                services.AddMvc();
                services.AddSingleton<PassThroughAttribute>();
                services.AddSingleton<UserNameService>();

                services.AddSingleton<INestedProvider<ActionDescriptorProviderContext>, ModuleActionDescriptorProvider>();
                services.AddSingleton<INestedProvider<ActionInvokerProviderContext>, ModuleActionInvokerProvider>();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "moduleRoute",
                    "module/{modulepath}",
                    new { module = "true" });

                routes.MapRoute("areaRoute", "{area}/{controller}/{action}");

                routes.MapRoute(
                    "controllerActionRoute",
                    "{controller}/{action}",
                    new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    "controllerRoute",
                    "{controller}",
                    new { controller = "Home" });

            });
        }
    }
}
