using IDS.Core.Interfaces;
using IDS.Core.Models;
using IDS.Core.Repositories;
using IDS.Services;
using IDS.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;

namespace FinalBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure the application services and middleware
            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the request pipeline
            Configure(app);

        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers();
            //  services.AddAutoMapper(typeof(Program));
            services.AddEndpointsApiExplorer();
            services.AddDbContext<IdsbookingSystemContext>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IdsbookingSystem", Version = "v1" });

            });
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<IdsbookingSystemContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("IDS.Data")));

        }

        private static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdsbookingSystem");
                });
            }
            // app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
