using ProdutoStore.Web.Extensoes;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ProdutoStore.Web.App_Start
{
    public class SimpleInjectorInitializer
    {
        public static Container Initialize(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = Lifestyle.CreateHybrid(
                defaultLifestyle: new WebRequestLifestyle(),
                fallbackLifestyle: new AsyncScopedLifestyle());
            container.RegistrarDependencias();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            return container;
        }


    }
}