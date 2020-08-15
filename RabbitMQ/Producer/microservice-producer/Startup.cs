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
using BrokerProxy = Producer.BrokerProxy;
using RabbitMQ.Client;
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
            /// In case of multiple message type - inject the producer accordingly
            /// Exchange type added as enum to build and configure exchange for each producer (optional)
            /// </summary>
            /// <typeparam name="BrokerProxy.Message"></typeparam>
            /// <typeparam name="BrokerProxy.ExchangeType"></typeparam>
            /// <returns></returns>
            services.AddSingleton<BrokerProxy.IProducer<BrokerProxy.Message, BrokerProxy.ExchangeType>>
            (sp => 
                new BrokerProxy.BaseProducer<BrokerProxy.Message,BrokerProxy.ExchangeType>
                (
                    sp.GetRequiredService<ILogger<BrokerProxy.BaseProducer<BrokerProxy.Message,BrokerProxy.ExchangeType>>>(),
                    BrokerProxy.ExchangeType.SampleExchange,
                    new ConnectionFactory()
                )
            );
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
        }
    }
}
