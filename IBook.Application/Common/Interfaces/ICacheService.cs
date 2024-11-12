namespace IBook.Application.Common.Interfaces;

public interface ICacheService
{
    Task<T?> GetStringAsync<T>(string key);
    Task SetStringAsync(string key, object value, TimeSpan time);
}