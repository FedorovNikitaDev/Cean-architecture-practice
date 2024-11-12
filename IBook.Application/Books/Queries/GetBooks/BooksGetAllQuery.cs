using AutoMapper;
using IBook.Application.Common;
using IBook.Application.Common.Repositories;
using IBook.Application.DTOs;
using IBook.Application.Extension;
using IBook.Application.Models;
using IBook.Domain.Entities;
using MediatR;

namespace IBook.Application.Books.Queries.GetBooks;

public record BooksGetAllQuery : IRequest<ResponseCollection<BookDto>>
{
    
}

public class BooksGetAllQueryHandler : BaseHandler<BooksGetAllQuery, ResponseCollection<BookDto>>
{
    private readonly IBookCacheRepository _bookCacheRepository;
    
    public BooksGetAllQueryHandler(IBookCacheRepository bookCacheRepository, IMapper mapper) : base(mapper)
    {
        _bookCacheRepository = bookCacheRepository;
    }

    public override async Task<ResponseCollection<BookDto>> Handle(BooksGetAllQuery request, CancellationToken cancellationToken)
    {
        var entities = await _bookCacheRepository.GetAll().MapCollection<BookDto, Book>(Mapper);
        
        return new ResponseCollection<BookDto>(entities, entities.Count);
    }
}