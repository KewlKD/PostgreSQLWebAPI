using Microsoft.EntityFrameworkCore;
using PostgreSQLWebAPI.DataAccess;





namespace PostgreSQLWebAPI
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

            var sqlConnectionString = Configuration["ConnectionStrings"];

            services.AddDbContext<PostgreSqlContext>
                (options => options.UseNpgsql(sqlConnectionString));  
  

            services.AddScoped<IDataAccessProvider, DataAccessProvider>();
            services.AddControllers();


            
        }
    



    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

          
        }
    }
}


