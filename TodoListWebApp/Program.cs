using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using System.Net;
using Microsoft.Extensions.Configuration;
using System;

namespace WebApp_OpenIDConnect_DotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(options=>
            {
                options.Listen(IPAddress.Any, 443, listenOptions =>
                {
                    listenOptions.UseHttps("localhost_cert.pfx", "8F4TZBFdYKYOBXUU");
                    
                });
                options.Listen(IPAddress.Any, 80);
            })
            .ConfigureAppConfiguration(SetupConfiguration)
            //.UseUrls("https://*:433")
                .UseStartup<Startup>()
            
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {

            builder.Sources.Clear();
            builder.AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();
        }
    }
}
