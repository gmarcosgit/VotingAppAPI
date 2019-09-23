using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using VotingAPI.DataAccessObjects;

[assembly: OwinStartup(typeof(VotingAPI.Startup))]

namespace VotingAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var container = new Container(); // Initialise container

            container.Register<DataObjects>(Lifestyle.Transient);
            container.Register<DBHelper>(Lifestyle.Transient);
            container.Register<PostObjects>(Lifestyle.Transient);


            HttpConfiguration config = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
            };

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
