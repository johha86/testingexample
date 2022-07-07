using Contoso.Payment.API.DataAccess;
using Contoso.Payment.API.Logic;

namespace Contoso.Payment.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //  Setup DI
            services.AddSingleton(typeof(IPaymentProcessor), typeof(PaymentProcessor));
            services.AddSingleton(typeof(IPaymentRepository), typeof(PaymentRepository));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
