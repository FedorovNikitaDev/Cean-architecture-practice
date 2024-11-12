using IBook.Domain.Common;

namespace IBook.Domain.Entities;

public class Book : BaseEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Pages { get; set; }
}