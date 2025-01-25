using Company.Core.Repository;
using Company.Repository;
using Company.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Company.APls
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configur Services

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));




            #endregion


            var app = builder.Build();


            #region Updata DataBase

            using var Scope = app.Services.CreateScope();

            var Service = Scope.ServiceProvider;

            var dbContext = Service.GetRequiredService<StoreContext>();

            await dbContext.Database.MigrateAsync();


            #endregion




            #region Configur - Configure the Http Request 

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
