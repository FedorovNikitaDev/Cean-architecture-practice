using IBook.Application.Books.Commands.Create;
using IBook.Application.Books.Commands.Delete;
using IBook.Application.Books.Commands.Update;
using IBook.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace IBook.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(GeneralProfile));

        services.AddMediatR(x => x.RegisterServicesFromAssemblies(
            typeof(BookCreateCommandHandler).Assembly, typeof(BookCreateCommand).Assembly,
            typeof(BookUpdateCommandHandler).Assembly, typeof(BookUpdateCommand).Assembly,
            typeof(BookDeleteByIdCommandHandler).Assembly, typeof(BookDeleteByIdCommand).Assembly
            ));

        return services;
    }
}