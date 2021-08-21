using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetByIdBookQuery
    {
        public int Id { get; set; }
        private readonly BookStoreDbContext _context;
        public GetByIdBookQuery(BookStoreDbContext context)
        {
            _context =context;
        }

        public BooksByIdViewModel Handle()
        {
            var book = _context.Books.Where(x=>x.Id == Id).SingleOrDefault();
            BooksByIdViewModel vm = new BooksByIdViewModel();
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            vm.Title = book.Title;

            return vm;
            

        }

        public class BooksByIdViewModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
        }
    }
}