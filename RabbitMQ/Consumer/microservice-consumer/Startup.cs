using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace microservice_producer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            /// <summary>
            /// Register exhange handler 
            /// </summary>
            /// <value></value>
            services.AddSingleton<IMessageHandler>(a =>
            {
                /// <summary>
                /// _exchange = exchange name
                /// </summary>
                /// <returns></returns>
                var obj = new MessageHandler(a.GetRequiredService<ILogger<MessageHandler>>(), "_exchange");
                return obj;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            /// <summary>
            /// Register all handlers
            /// </summary>
            /// <typeparam name="IMessageHandler"></typeparam>
            /// <returns></returns>
            var handlers = app.ApplicationServices.GetServices<IMessageHandler>();
            foreach(var handler in handlers)
            {
                handler.Register();
            }
        }
    }
}
