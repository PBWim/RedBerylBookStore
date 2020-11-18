namespace RedBerylBookStore.Data.Contract
{
    using System.Linq;
    using BO = ServiceModels;

    public interface IBookRepository
    {
        IQueryable<BO.Book> Get();

        IQueryable<BO.Book> Get(string search);

        BO.Book Create(BO.Book book);
    }
}