using LibraryApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class BooksController : ControllerBase
    {

        LibraryDataContext _context;

        public BooksController(LibraryDataContext context)
        {
            _context = context;
        }



        // GET /books - returns a collection of all our books.
        //            - can filter on genre
        [HttpGet("books")]
        public async Task<ActionResult> GetAllBooks()
        {
            var results = await _context.Books
                .Where(b => b.RemovedFromInventory == false)
                .ToListAsync();

            return Ok(results); //TODO THIS SUCKS FIX THIS!
        }

        // GET /books/{id} - get a single book or a 404

        // POST /books - Add a document to the collection

        // DELETE /books/{id} - remove a book from inventory

        // PUT /books/{id} - update a book (We'll talk a bunch about this when we get to it.)
    }
}
