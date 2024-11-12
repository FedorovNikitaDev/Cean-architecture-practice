using IBook.Domain.Entities;

namespace IBook.Application.Common.Repositories;

public interface IBookCacheRepository
{
    Task<Book?> GetById(long id);

    Task<IReadOnlyCollection<Book>> GetAll();
}