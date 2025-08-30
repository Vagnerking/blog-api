using blog_api.Database;
using blog_api.Repository;
using blog_api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace blog_api
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

            bool localRun = !builder.Environment.IsDevelopment() && !builder.Environment.IsProduction();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var connStr = builder.Configuration.GetConnectionString("BlogDb");

                if (localRun)
                    options.UseSqlite(connStr);
                else
                    options.UseSqlServer(connStr);
            });


            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();

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
