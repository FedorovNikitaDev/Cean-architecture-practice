using Microsoft.Extensions.Logging;

namespace IBook.Infrastructure.Data.Repositories;

public class BaseRepository
{
    protected readonly ApplicationDbContext Context;
    protected readonly ILogger<BaseRepository> Logger;

    protected BaseRepository(ApplicationDbContext context, ILogger<BaseRepository> logger)
    {
        Context = context;
        Logger = logger;
    }
}