using System;
using Assignments.Business;
using Microsoft.Extensions.DependencyInjection;
namespace Assignments
{
    public class Program
    {
        static void Main(string[] args)
        {
            Startup startUp = new Startup();
            ServiceProvider serviceProvider = startUp.InitialiseServices();
            var subscribeUsers = serviceProvider.GetService<IArticleLogic>();
            subscribeUsers.GetViewCount().GetAwaiter().GetResult();
        }
    }
}