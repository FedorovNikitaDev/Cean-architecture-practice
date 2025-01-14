using AutoMapper;
using IBook.Application.Common;
using IBook.Application.Common.Repositories;
using IBook.Application.Extension;
using IBook.Application.Models;
using IBook.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IBook.Application.Books.Commands.Create;

public record BookCreateCommand : IRequest<Response<long>>
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Pages { get; set; }
}

public class BookCreateCommandHandler : BaseHandler<BookCreateCommand, Response<long>>
{
    private readonly IBookRepository _bookRepository;

    public BookCreateCommandHandler(IBookRepository bookRepository, IMapper mapper, 
        ILogger<BookCreateCommandHandler> logger) : base(mapper, logger)
    {
        _bookRepository = bookRepository;
    }
    
    public override async Task<Response<long>> Handle(BookCreateCommand request, CancellationToken cancellationToken)
    {
        Logger.LogInformationDateTime($"Start book create.");
        
        var entity = Mapper.Map<Book>(request);

        await _bookRepository.Create(entity);

        var response = new Response<long>()
        {
            Data = entity.Id
        };

        return response;
    }
}