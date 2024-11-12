using System.Text.Json;
using IBook.Application.Common.Interfaces;
using IBook.Application.Extension;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace IBook.Infrastructure.Services;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    private readonly ILogger<CacheService> _logger;

    public CacheService(IDistributedCache cache, ILogger<CacheService> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<T?> GetStringAsync<T>(string key)
    {
        _logger.LogInformationDateTime($"Key - {key}");
        var resultString = await _cache.GetStringAsync(key);

        if (resultString == null)
        {
            _logger.LogInformationDateTime($"String was not found");
            return default;
        }
        
        _logger.LogInformationDateTime($"String was found");

        var result = JsonSerializer.Deserialize<T>(resultString);
        return result;
    }

    public async Task SetStringAsync(string key, object value, TimeSpan time)
    {
        _logger.LogInformationDateTime($"Set cache with key - {key}");
        var valueString = JsonSerializer.Serialize(value);
        await _cache.SetStringAsync(key, valueString, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = time
        });
    }
}