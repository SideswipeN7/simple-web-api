using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using NLog.Web;

namespace SimpleApp
{
    public class Program
    {
        public static void Main(string[] args) => CreateWebHostBuilder(args).Run();

        public static IWebHost CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args)
                                                                             .UseContentRoot(Directory.GetCurrentDirectory())
                                                                             .UseIISIntegration()
                                                                             .UseStartup<Startup>()
                                                                             .UseNLog()
                                                                             .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                                                                             .ConfigureServices(services => services.AddAutofac())
                                                                             .Build();
    }
}