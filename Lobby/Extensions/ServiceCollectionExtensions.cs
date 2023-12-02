namespace Lobby.Extensions;

using Lobby.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDatabase(this IServiceCollection serviceCollection, WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        serviceCollection.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
    }
}