using DBFAAPI.Models;
using DBFAAPI.Repository;
using System.Text.Json.Serialization;

namespace DBFAAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddControllers();
            builder.Services.AddDbContext<BikeStoresContext>();
            builder.Services.AddScoped<IProductServices, ProductService>();
            builder.Services.AddScoped<ICategoryServices, CategoryService>();
            builder.Services.AddScoped<IStockServices, StockService>();
            builder.Services.AddScoped<IBrandServices, BrandService>();
            builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; });
            builder.Services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseResponseCompression();
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
