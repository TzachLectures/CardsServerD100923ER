
using CardsServerD100923ER.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
