using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCore.MvcDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration((delegate(WebHostBuilderContext context, IConfigurationBuilder builder)
                //    {
                //        builder.AddInMemoryCollection();
                //    }))
                .UseStartup<Startup>();
    }
}
