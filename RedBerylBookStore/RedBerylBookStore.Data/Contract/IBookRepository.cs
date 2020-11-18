namespace RedBerylBookStore.Data.Contract
{
    using System.Linq;
    using BO = ServiceModels;

    public interface IBookRepository
    {
        IQueryable<BO.Book> Get();

        BO.Book Create(BO.Book book);
    }
}