using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices(services =>
                {
                    // Add services to the container.
                    services.AddControllers();
                    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                    services.AddEndpointsApiExplorer();
                    services.AddSwaggerGen();
                })
                .Configure(app =>
                {
                    var env = app.ApplicationServices.GetRequiredService<IHostEnvironment>();

                    // Configure the HTTP request pipeline.
                    if (env.IsDevelopment())
                    {
                        app.UseSwagger();
                        app.UseSwaggerUI();
                    }

                    app.UseHttpsRedirection();
                    app.UseAuthorization();
                    app.UseRouting();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });
            });
}
