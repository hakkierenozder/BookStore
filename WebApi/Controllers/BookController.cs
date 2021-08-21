using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DbOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
    private readonly BookStoreDbContext _context;
    public BookController(BookStoreDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery query = new GetBooksQuery(_context);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        GetByIdBookQuery query = new GetByIdBookQuery(_context);
        query.Id = id;
        var result = query.Handle();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult AddBook([FromBody]CreateBookModel newBook)
    {
         CreateBookCommand command = new CreateBookCommand(_context);
        try
        {
            command.Model = newBook; 
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
       
       
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook)
    {
        UpdateBookCommand command = new UpdateBookCommand(_context);
        try
        {
            command.Model = updatedBook; 
            command.Id = id;
            command.Handle();
        }
        catch (Exception ex)
        {
            
            return BadRequest(ex.Message); 
        }
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        DeleteBookCommand command = new DeleteBookCommand(_context);
        try
        {
            command.Id = id;
            command.Handle();
        }
        catch (Exception ex)
        {
            
            return BadRequest(ex.Message); 
        }
        return Ok();
    }
    }
}