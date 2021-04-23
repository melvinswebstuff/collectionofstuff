using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore;

namespace NET5Play
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger();
            }

            app.UseRouting()
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
                .UseSwaggerUI(s =>
                {
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Net5Play");
                });
        }
    }
}
