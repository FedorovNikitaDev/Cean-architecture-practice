namespace IBook.Infrastructure.Cache;

public static class CacheKeys
{
    public static class Book
    {
        private static string Base => "Book";
        
        public static string GetById(long id) => $"{Base}-GetById-{id}";

        public static string GetAll() => $"{Base}-GetAll";
    }
}