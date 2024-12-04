
using CardsServerD100923ER.Application.Interfaces;
using CardsServerD100923ER.Application.Services;
using CardsServerD100923ER.Core.Interfaces;
using CardsServerD100923ER.Infrastructure.Data;
using CardsServerD100923ER.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CardsServerD100923ER
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            string connectionString = "Server=LAPTOP-M1H6FNPI\\MSSQLSERVER02; Database=CardsProjectDb; Trusted_Connection=True; TrustServerCertificate=True;";

            builder.Services.AddDbContext<CardsProjectDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddSingleton<IAuth, JwtAuthService>();

            builder.Services.AddScoped<IUserRepository, UserRepository > ();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "CardsServer",
                        ValidAudience = "CardReactApp",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("F8C2E94F-694F-4888-B434-7B0B228239D4"))
                    };
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("MustBeBusiness",policy=>policy.RequireClaim("isBusiness","true"));
                options.AddPolicy("MustBeAdmin", policy => policy.RequireClaim("isAdmin", "true"));
            });

            builder.Services.AddCors(
            options => options.AddPolicy("myCorsPolicy",
            policy => policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
            );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("myCorsPolicy");
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
