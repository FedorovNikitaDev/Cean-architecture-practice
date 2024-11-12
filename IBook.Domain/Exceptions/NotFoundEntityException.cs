namespace IBook.Domain.Exceptions;

public class NotFoundEntityException : Exception
{
    public NotFoundEntityException(string name, long key) : base($"Entity \"{name}\" with id {key} was not found") {}
}