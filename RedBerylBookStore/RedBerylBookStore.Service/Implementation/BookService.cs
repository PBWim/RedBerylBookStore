namespace RedBerylBookStore.Service.Implementation
{
    using System.Linq;
    using Data.Contract;
    using Microsoft.Extensions.Logging;
    using ServiceModels;
    using Service.Contract;

    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly ILogger<BookService> logger;

        public BookService(ILogger<BookService> logger, IBookRepository bookRepository)
        {
            this.logger = logger;
            this.bookRepository = bookRepository;
        }

        public IQueryable<Book> Get(string search)
        {
            this.logger.LogInformation($"Get books on {nameof(Get)} in BookService");
            var result = string.IsNullOrWhiteSpace(search) ? this.bookRepository.Get() :
                this.bookRepository.Get(search);
            return result;
        }

        public Book Create(Book book)
        {
            this.logger.LogInformation($"Create book on {nameof(Create)} in BookService with book details : {book}");
            var result = this.bookRepository.Create(book);
            return result;
        }
    }
}