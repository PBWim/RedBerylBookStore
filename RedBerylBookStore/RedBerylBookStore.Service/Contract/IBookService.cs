namespace RedBerylBookStore.Service.Contract
{
    using System.Linq;
    using ServiceModels;

    public interface IBookService
    {
        IQueryable<Book> Get(string search = "");

        Book Create(Book book);
    }
}
