using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Svinx.Libraries.Queues;
using Svinx.Libraries.Queues.RabbitMQ;
using Svinx.FindMe.Libraries.Search;

namespace Svinx.FindMe.Services.Search
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
            services.AddMvc(); 
            services.AddOptions();
            services.Configure<Queue>(Configuration.GetSection("Queue"));
            services.AddSingleton<IRPCClient, Svinx.Libraries.Queues.RabbitMQ.RPCClient>(); 
            services.AddSingleton<IClient, Svinx.FindMe.Libraries.Search.Client>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
