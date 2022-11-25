using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


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
                .ConfigureServices(  services => {
                    // IServiceCollection
                    services.AddMvc() ; // from reference Microsoft.Extensions.DependencyInjection 
                })
                .Configure(app => {
                    // IApplicationbuilder app
                    // use static "wwwroot" files
                    app.UseStaticFiles();
                    app.UseDeveloperExceptionPage();
                    app.UseMvc();
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