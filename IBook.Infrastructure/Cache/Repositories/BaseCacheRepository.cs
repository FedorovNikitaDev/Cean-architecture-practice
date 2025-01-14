using IBook.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace IBook.Infrastructure.Cache.Repositories;

public abstract class BaseCacheRepository
{
    protected readonly ICacheService CacheService;

    protected readonly ILogger<BookCacheRepository> Logger;

    protected BaseCacheRepository(ICacheService cacheService, ILogger<BookCacheRepository> logger)
    {
        CacheService = cacheService;
        Logger = logger;
    }
}