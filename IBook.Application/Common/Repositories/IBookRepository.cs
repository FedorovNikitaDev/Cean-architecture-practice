using IBook.Domain.Entities;

namespace IBook.Application.Common.Repositories;

public interface IBookRepository
{
    Task<Book?> GeyById(long id);
    Task<long> Create(Book book);
    Task<Book> Update(Book book);
    Task<IReadOnlyCollection<Book>> GetAll();
    Task<bool> Delete(Book book);
}