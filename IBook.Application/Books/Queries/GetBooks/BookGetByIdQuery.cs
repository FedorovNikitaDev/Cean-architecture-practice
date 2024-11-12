using AutoMapper;
using IBook.Application.Common;
using IBook.Application.Common.Repositories;
using IBook.Application.DTOs;
using IBook.Application.Extension;
using IBook.Application.Models;
using IBook.Domain.Entities;
using IBook.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IBook.Application.Books.Queries.GetBooks;

public record BookGetByIdQuery(long Id) : IRequest<Response<BookDto>>
{
    public long Id { get; set; } = Id;
}

public class BookGetByIdQueryHandler : BaseHandler<BookGetByIdQuery, Response<BookDto>>
{
    private readonly IBookCacheRepository _bookCacheRepository;
    
    public BookGetByIdQueryHandler(IMapper mapper, IBookCacheRepository bookCacheRepository, 
        ILogger<BookGetByIdQueryHandler> logger) : base(mapper, logger)
    {
        _bookCacheRepository = bookCacheRepository;
    }

    public override async Task<Response<BookDto>> Handle(BookGetByIdQuery request, CancellationToken cancellationToken)
    {
        Logger.LogInformationDateTime($"Id - {request.Id}.");
        var book = await _bookCacheRepository.GetById(request.Id);

        if (book is null) throw new NotFoundEntityException(nameof(Book), request.Id);
        
        Logger.LogInformationDateTime("Book was found.");

        return new Response<BookDto>(book.Map<BookDto>(Mapper));
    }
}