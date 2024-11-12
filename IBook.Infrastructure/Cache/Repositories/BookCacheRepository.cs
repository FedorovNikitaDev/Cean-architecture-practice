using IBook.Application.Common.Interfaces;
using IBook.Application.Common.Repositories;
using IBook.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace IBook.Infrastructure.Cache.Repositories;

public class BookCacheRepository : BaseCacheRepository, IBookCacheRepository
{
    private readonly IBookRepository _bookRepository;
    
    public BookCacheRepository(IBookRepository bookRepository, ICacheService cacheService, 
        ILogger<BookCacheRepository> logger) : base(cacheService, logger)
    {
        _bookRepository = bookRepository;
    }
    
    public async Task<Book?> GetById(long id)
    {
        Logger.LogInformation($"Id - {id}");
        
        var cacheKey = CacheKeys.Book.GetById(id);
        var book = await CacheService.GetStringAsync<Book>(cacheKey);

        if (book is not null) return book;
        
        book = await _bookRepository.GeyById(id);

        if (book is null) return default;

        await CacheService.SetStringAsync(cacheKey, book, TimeSpan.FromMinutes(1));

        return book;
    }

    public async Task<IReadOnlyCollection<Book>> GetAll()
    {
        var key = CacheKeys.Book.GetAll();
        var books = await CacheService.GetStringAsync<IReadOnlyCollection<Book>>(key);

        if (books is not null) return books;

        books = await _bookRepository.GetAll();

        await CacheService.SetStringAsync(key, books, TimeSpan.FromMinutes(1));

        return books;
    }
}