using IBook.Application.Common.Interfaces;
using IBook.Application.Common.Repositories;
using IBook.Infrastructure.Cache.Repositories;
using IBook.Infrastructure.Data;
using IBook.Infrastructure.Data.Repositories;
using IBook.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBook.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStringDb = configuration.GetConnectionString("db");
        var connectionStringRedis = configuration.GetConnectionString("redis");
        
        ArgumentException.ThrowIfNullOrEmpty(connectionStringDb, "Connection string for db not found.");
        ArgumentException.ThrowIfNullOrEmpty(connectionStringRedis, "Connection string for redis not found.");

        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<ICacheService, CacheService>();
        services.AddTransient<IBookCacheRepository, BookCacheRepository>();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionStringDb);
        });
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = connectionStringRedis;
        });

        return services;
    }
}