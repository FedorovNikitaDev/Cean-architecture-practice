namespace IBook.Application.Models;

public class DataCollection<T>
{
    public IReadOnlyCollection<T> Items { get; }
    public int TotalPage { get; }

    public DataCollection(IReadOnlyCollection<T> items, int totalPage)
    {
        Items = items;
        TotalPage = totalPage;
    }
}