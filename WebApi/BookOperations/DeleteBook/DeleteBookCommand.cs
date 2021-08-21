using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public int Id { get; set; }
        private readonly BookStoreDbContext _context;
        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
        var book = _context.Books.SingleOrDefault(x=>x.Id == Id);
        if(book is null)
             throw new InvalidOperationException("Kitap bulunamadı.");

        _context.Books.Remove(book);
        _context.SaveChanges();
        }


        public class DeleteBookModel
        {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        }
    }
}