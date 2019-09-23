using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using VotingAppAPI.DataAccessObjects;

[assembly: OwinStartup(typeof(VotingAppAPI.Startup))]

namespace VotingAppAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //ConfigureAuth(app);

            //var container = new Container(); // Initialise container

            //container.Register<DataObjects>(Lifestyle.Transient);
            //container.Register<DBHelper>(Lifestyle.Transient);
            ////container.Register<PostObjects>(Lifestyle.Transient);


            //HttpConfiguration config = new HttpConfiguration
            //{
            //    DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
            //};

            //WebApiConfig.Register(config);
            //app.UseWebApi(config);
        }
    }
}
