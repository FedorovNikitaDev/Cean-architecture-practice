using IBook.Application.Common.Repositories;
using IBook.Application.Extension;
using IBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IBook.Infrastructure.Data.Repositories;

public class BookRepository : BaseRepository, IBookRepository
{
    public BookRepository(ApplicationDbContext context, ILogger<BookRepository> logger) : base(context, logger) {}

    public async Task<Book?> GeyById(long id)
    {
        Logger.LogInformationDateTime($"Id - {id}");
        var result = await Context.Books.FirstOrDefaultAsync(b => b.Id == id);

        if (result is not null) return result;
        
        Logger.LogInformationDateTime("Book was not found");
        return default;

    }

    public async Task<long> Create(Book book)
    {
        var result = await Context.AddAsync(book);
        await Context.SaveChangesAsync();
        Logger.LogInformationDateTime($"Book was created with id {result.Entity.Id}");
        return result.Entity.Id;
    }

    public async Task<Book> Update(Book book)
    {
        Context.ChangeTracker.Clear();
        var result = Context.Update(book);
        await Context.SaveChangesAsync();
        Logger.LogInformationDateTime($"Book was updated with id {book.Id}");
        return result.Entity;
    }

    public async Task<IReadOnlyCollection<Book>> GetAll()
    {
        var result = await Context.Books.ToListAsync();
        Logger.LogInformationDateTime($"Books count - {result.Count}");
        return result;
    }

    public async Task<bool> Delete(Book book)
    {
        try
        {
            Context.Books.Remove(book);
            await Context.SaveChangesAsync();
            Logger.LogInformationDateTime($"Book was deleted with id - {book.Id}");
            return true;
        }
        catch (Exception ex)
        {
            Logger.LogInformationDateTime($"Books was not deleted with id - {book.Id}");
            return false;
        }
    }
}