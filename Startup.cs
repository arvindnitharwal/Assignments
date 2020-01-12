using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Assignments.Business;
namespace Assignments
{
    public class Startup
    {
        public ServiceProvider InitialiseServices()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            return services.BuildServiceProvider();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IArticleLogic, ArticleLogic>();
        }
    }
}