namespace IBook.Application.Models;

public class ResponseCollection<T> : Response<DataCollection<T>>
{
   public ResponseCollection(IReadOnlyCollection<T> collection, int totalCount)
   {
      var dataCollection = new DataCollection<T>(collection, totalCount);
      Data = dataCollection;
   }
}