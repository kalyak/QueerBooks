using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueerBooksAPI.Models;

namespace QueerBooksAPI.Controllers
{
    [Route("api/QueerBooks")]
    [ApiController]
    public class QueerBooksController : ControllerBase
    {
        private readonly QueerBooksContext _context;

        public QueerBooksController(QueerBooksContext context)
        {
            _context = context;
        }

        // GET: api/QueerBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            return await _context.Books.ToListAsync();
        }

        // GET: api/QueerBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(long id)
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/QueerBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QueerBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
          if (_context.Books == null)
          {
              return Problem("Entity set 'QueerBooksContext.Books'  is null.");
          }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBook", new { id = book.Id }, book);
            return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
        }

        // DELETE: api/QueerBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(long id)
        {
            return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
