using IBook.Domain.Common;

namespace IBook.Application.Specifications;

public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQueryable, Specification<TEntity> specification)
        where TEntity : BaseEntity
    {
        var query = inputQueryable;

        if (specification != null)
        {
            query = query.Where(specification.Criteria);
        }

        if (specification.OrderByExpression != null)
        {
            query = query.OrderBy(specification.OrderByExpression);
        }

        if (specification.OrderByDescendingExpression != null)
        {
            query = query.OrderByDescending(specification.OrderByDescendingExpression);
        }

        return query;
    }
}