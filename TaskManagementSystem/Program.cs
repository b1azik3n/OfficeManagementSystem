using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Repository.AssignMember;
using DataAccessLayer.Repository.DailyLogs;
using DataAccessLayer.Repository.General;
using DataAccessLayer.Repository.Task;
using DataAccessLayer.Repository.UnitOfWork;
using DomainLayer.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskManagementSystem.Services.Authentication;
using TaskManagementSystem.Services.Clients;
using TaskManagementSystem.Services.DailyLogs;
using TaskManagementSystem.Services.GeneralService;
using TaskManagementSystem.Services.MemberAssign;
using TaskManagementSystem.Services.Projects;
using TaskManagementSystem.Services.Tasks;

namespace TaskManagementSystem
{

    public class Program
    { 

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<TaskDbContext>(options => options.
            UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"),
            b => b.MigrationsAssembly("TaskManagementSystem")));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = false,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };

                }); 
            builder.Services.AddAutoMapper(typeof(AutoMapping));
            builder.Services.AddScoped<ILogService, LogService>();
            builder.Services.AddScoped<ILogRepo, LogRepo>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IRepo, Repo>();
            builder.Services.AddScoped<IService,Service>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddScoped<IProjectAssignRepo, ProjectAssignRepo>();
            builder.Services.AddScoped<IProjectAssignService, ProjectAssignService>();    
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ITaskRepo,TaskRepo>();
            builder.Services.AddScoped<ITaskService,TaskService>();
            builder.Services.AddScoped<IClientService, ClientService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();
            SeedDatabase();


            app.Run();
            void SeedDatabase()
            {
                using (var scope = app.Services.CreateScope())
                {
                    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                    dbInitializer.Initializer();
                }
            }

        }
    }
}
