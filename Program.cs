using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {

           // minimal implementation of a host

            var host = new WebHostBuilder()
                .UseContentRoot(System.IO.Directory.GetCurrentDirectory()) // use the local wwwroot
                .UseKestrel()
                .Configure(app => {
                    // IApplicationbuilder app
                    // use static "wwwroot" files with default.html routing 
                    app.UseDefaultFiles();
                    app.UseStaticFiles();
                    // in case nothing is found in static files folder, then
                    // Configuring the minimal app ( always return simple "hello world" without http header)
                    app.Run(context => context.Response.WriteAsync("Hello World!"));
                })
                .ConfigureLogging(logging =>
                {   //IloggingBuilder logging
                    logging.ClearProviders();
                    logging.AddConsole();
                }) ;
            
            Console.WriteLine("Host running");
            
            host.Build().Run();
            

        }

    }

}