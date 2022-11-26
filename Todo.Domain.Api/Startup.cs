using Microsoft.EntityFrameworkCore;

using Todo.Domain.Handlers;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api
{
    /// <summary>
    /// Class used to segregatte services, ioc and http pipeline
    /// </summary>
    public class Startup
    {

        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Add services to the container
        /// </summary>
        /// <param name="services"></param>
        public void ConfigurationServices( IServiceCollection services )
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            #region IOC

            //Option with SQL in memory
            //services.AddDbContext<DataContext>( opt => opt.UseInMemoryDatabase( "Database" ) );

            //Option with SQL 
            services.AddDbContext<DataContext>(
                opt =>
                                                opt.UseSqlServer(
                                                    Configuration.GetConnectionString( "connectionString" ) ) );

            services.AddTransient<ITodoRepository, TodoRepository>();
            services.AddTransient<TodoHandler, TodoHandler>();

            #endregion
        }

        /// <summary>
        /// Configure the HTTP request pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="environment"></param>
        public void Configure( WebApplication app, IWebHostEnvironment environment )
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();
        }
    }
}
