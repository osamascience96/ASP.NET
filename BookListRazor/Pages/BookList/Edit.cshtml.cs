using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly Model.ApplicationDbContext _db;

        public EditModel(Model.ApplicationDbContext _db)
        {
            this._db = _db;
        }

        [BindProperty]
        public Model.Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await this._db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookObjectDb = await this._db.Book.FindAsync(Book.Id);
                bookObjectDb.Name = this.Book.Name;
                bookObjectDb.Author = this.Book.Author;
                bookObjectDb.ISBN = this.Book.ISBN;

                await this._db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
