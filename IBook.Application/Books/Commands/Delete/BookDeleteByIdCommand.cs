using IBook.Application.Common;
using IBook.Application.Common.Repositories;
using IBook.Application.Models;
using IBook.Domain.Entities;
using IBook.Domain.Exceptions;
using MediatR;

namespace IBook.Application.Books.Commands.Delete;

public record BookDeleteByIdCommand : IRequest<Response<bool>>
{
    public long Id { get; set; }
}

public class BookDeleteByIdCommandHandler : BaseHandler<BookDeleteByIdCommand, Response<bool>>
{
    private readonly IBookRepository _bookRepository;
    
    public BookDeleteByIdCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public override async Task<Response<bool>> Handle(BookDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await _bookRepository.GeyById(request.Id);

        if (entity is null) throw new NotFoundEntityException(nameof(Book), request.Id);

        var result = await _bookRepository.Delete(entity);

        return new Response<bool>(result);
    }
}