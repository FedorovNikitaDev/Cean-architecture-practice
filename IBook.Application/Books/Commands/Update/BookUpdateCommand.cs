using AutoMapper;
using IBook.Application.Common;
using IBook.Application.Common.Repositories;
using IBook.Application.DTOs;
using IBook.Application.Models;
using IBook.Domain.Entities;
using IBook.Domain.Exceptions;
using MediatR;

namespace IBook.Application.Books.Commands.Update;

public record BookUpdateCommand : IRequest<Response<BookDto>>
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Pages { get; set; }
}

public class BookUpdateCommandHandler : BaseHandler<BookUpdateCommand, Response<BookDto>>
{
    private readonly IBookRepository _bookRepository;

    public BookUpdateCommandHandler(IBookRepository bookRepository, IMapper mapper) : base(mapper)
    {
        _bookRepository = bookRepository;
    }

    public override async Task<Response<BookDto>> Handle(BookUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _bookRepository.GeyById(request.Id);

        if (entity is null) throw new NotFoundEntityException(nameof(Book), request.Id);

        entity = Mapper.Map<Book>(request);

        await _bookRepository.Update(entity);

        var response = new Response<BookDto>()
        {
            Data = Mapper.Map<BookDto>(entity)
        };

        return response;
    }
}