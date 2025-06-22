using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        builder.Services.AddDbContext<DatabaseContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
        );
        
        //builder.Services.AddScoped<IDbService, DbService>();

        var app = builder.Build();
        
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}