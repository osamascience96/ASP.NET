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
    }
}
