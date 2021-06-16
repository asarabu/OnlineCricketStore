using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using OnlineCricketStore.Controllers;
using OnlineCricketStore.Controllers.api;
using OnlineCricketStore.Models;
using OnlineCricketStore.Repositories;

namespace OnlineCricketStore
{
    public static class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
          //  builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            //var controllersAssembly = Assembly.GetAssembly(typeof(HomeController));
           // var apiControllersAssembly = Assembly.GetAssembly(typeof(CricketProductController));

            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CricketEntities>()
                .As<DbContext>()
                .InstancePerRequest();

            builder.RegisterType<DataAccessLayer>().As<IDataAccessLayer>();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

        //public static IContainer Configure()
        //{
        //    var builder = new ContainerBuilder();

            

        //    //builder.RegisterAssemblyTypes(Assembly.Load(nameof(OnlineCricketStore)))
        //    //    .Where(t => t.Namespace != null && t.Namespace.Contains("Repositories")).As(t=> t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

        //    return builder.Build();
        //}
       
    }
}