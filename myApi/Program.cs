using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace myApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try
            {
                logger.Info("Initializing application...");

                var webHost = CreateWebHostBuilder(args).Build();

                //using (var scope = webHost.Services.CreateScope())
                //{
                //    try
                //    {
                //        var context = scope.ServiceProvider.GetService<PersonContext>();

                //        // Demo Purposes: Delete database & migrate on startup to sanitize while building API
                //        // context.Database.EnsureDeleted();
                //        // context.Database.Migrate();

                //    }
                //    catch (Exception ex)
                //    {
                //        logger.Error(ex, "An error occurred while migrating the database");
                //    }
                //}

                webHost.Run();      // Run the web app!!
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Application stopped because of exception.");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog();
    }
}
