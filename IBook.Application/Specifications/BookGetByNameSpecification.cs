using IBook.Domain.Entities;

namespace IBook.Application.Specifications;

public class BookGetByNameSpecification : Specification<Book>
{
    public BookGetByNameSpecification(string name) : base(book => book.Name == name)
    {
        
    }
}