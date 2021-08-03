using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        // we want the list of the books, so for that we need to init the model property for the book
        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            this.Books = await this._db.Book.ToListAsync();
        }

        // delete the book
        public async Task<IActionResult> OnPostDelete(int id)
        {
            // get the instance of .net book object from the db
            var book = await this._db.Book.FindAsync(id);

            // chcek if the book is null
            if(book == null)
            {
                // book not found
                return NotFound();
            }
            else
            {
                // remove the specific book
                this._db.Book.Remove(book);
                // save changes in db
                await this._db.SaveChangesAsync();

                // redirect to the index page
                return RedirectToPage("Index");
            }
        }
    }
}
