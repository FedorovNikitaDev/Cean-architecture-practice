using IBook.Application.Books.Commands.Create;
using IBook.Application.Books.Commands.Delete;
using IBook.Application.Books.Commands.Update;
using IBook.Application.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IBook.API.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(BookCreateCommand command)
    {
        var id = await _mediator.Send(command);

        return Ok(id);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(BookUpdateCommand command)
    {
        var book = await _mediator.Send(command);

        return Ok(book);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var books = await _mediator.Send(new BooksGetAllQuery());

        return Ok(books);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteById(BookDeleteByIdCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _mediator.Send(new BookGetByIdQuery(id));

        return Ok(result);
    }
}