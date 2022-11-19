using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {

           // minimal implementation of a host

            var host = new WebHostBuilder()
                .UseKestrel()
                // Configuring the minimal app ( always return simple "hello world" without http header)
                .Configure(app => {
                    app.Run(context => context.Response.WriteAsync("Hello World!"));
                }) ;
            
            Console.WriteLine("Host running");
            
            host.Build().Run();
            

        }

    }

}