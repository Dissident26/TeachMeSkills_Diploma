using Services.Extentions;

namespace WebApi
{
    public class StartUp
    {
        public IConfiguration Configuration { get; }
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbServices();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            app.UseCors((p) =>
            {
                p.AllowAnyOrigin();
                p.AllowAnyMethod();
                p.AllowAnyHeader();
            });
            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            //midleware

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}