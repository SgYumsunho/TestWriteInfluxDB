using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;


namespace S9000C
{
    class Program
    {
        static void Main(string[] args)
        {
            // appsettings handling
            IConfigurationBuilder builder = new ConfigurationBuilder();
            BuildConfig(builder);

           
            // creating logger object
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("log.txt")
                .CreateLogger();
            Log.Logger.Information("");
            Log.Logger.Information("------------------------------------------------------");
            Log.Logger.Information("S9000C Program Started");
            Log.Logger.Information("------------------------------------------------------");


            // registering service objects with default configuration
            Log.Logger.Information("[MAIN]\tRegistering service objects");
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IServiceMainTest, ServiceMainTest>();
                    services.AddTransient<IServiceSubTest, ServiceSubTest>();
                })
                .UseSerilog()
                .Build();


            // creating and running service objects
            Log.Logger.Information("[MAIN]\tCreating and running service objects");

            // decide which service objects are created and runned after reading JSON configuration file.
            IConfiguration tempConfig = builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            bool isCreateMainTest = tempConfig.GetValue<bool>("IsCreateMainTest");
            bool isCreateSubTest = tempConfig.GetValue<bool>("IsCreateSubTest");
            
            bool isRunMainTest = tempConfig.GetValue<bool>("IsRunMainTest");
            bool isRunSubTest = tempConfig.GetValue<bool>("IsRunSubTest");


            // running service objects
            Log.Logger.Information("[MAIN]\tRunning service objects");

            if (isCreateMainTest)
            {
                var serviceMainTest = ActivatorUtilities.CreateInstance<ServiceMainTest>(host.Services);
                if (isRunMainTest)
                {
                    serviceMainTest.ShowMenu();
                }
            }

            if (isCreateSubTest)
            {
                var serviceSubTest = ActivatorUtilities.CreateInstance<ServiceSubTest>(host.Services);
                if (isRunMainTest)
                {
                    serviceSubTest.Run();
                }
            }


            // running host object and entering wait status
            host.Run();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            // EXE가 위치한 폴더에서 appsettings.json 파일을 찾을 후 읽
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
