using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Repository;
using TaskSystem.Repository.Interface;

namespace TaskSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<TaskSystemDBContext>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))    
                );


            builder.Services.AddScoped<IUserRespository, UserRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();



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