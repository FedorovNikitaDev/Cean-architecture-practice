using AutoMapper;
using IBook.Application.Books.Commands.Update;
using IBook.Application.DTOs;
using IBook.Domain.Entities;

namespace IBook.Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<BookUpdateCommand, Book>();
        CreateMap<Book, BookDto>();
    }
}