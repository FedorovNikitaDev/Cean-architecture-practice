using AutoMapper;
using IBook.Domain.Common;

namespace IBook.Application.Extension;

public static class MappingExtension
{
    public static async Task<IReadOnlyCollection<T1>> MapCollection<T1, T2>(this Task<IReadOnlyCollection<T2>> entities, IMapper mapper)
    {
        return mapper.Map<IReadOnlyCollection<T1>>(await entities);
    }

    public static T1 Map<T1>(this BaseEntity entity, IMapper mapper)
    {
        return mapper.Map<T1>(entity);
    }
}