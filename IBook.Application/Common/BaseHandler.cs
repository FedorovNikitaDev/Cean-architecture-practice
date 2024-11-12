using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IBook.Application.Common;

public abstract class BaseHandler<T1, T2> : IRequestHandler<T1, T2> where T1 : IRequest<T2>
{
    protected readonly IMapper Mapper;
    
    protected readonly ILogger<BaseHandler<T1, T2>> Logger;

    protected BaseHandler(IMapper mapper)
    {
        Mapper = mapper;
    }
    
    protected BaseHandler() {}

    protected BaseHandler(IMapper mapper, ILogger<BaseHandler<T1, T2>> logger)
    {
        Mapper = mapper;
        Logger = logger;
    }

    public abstract Task<T2> Handle(T1 request, CancellationToken cancellationToken);
}