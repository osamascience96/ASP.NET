using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly Model.ApplicationDbContext _db;

        public BookController(Model.ApplicationDbContext _db)
        {
            this._db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new {data = await this._db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            // book from db
            var bookFromDb = await this._db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if(bookFromDb == null)
            {
                return Json(new {success=false, message = "Error While Deleting" });
            }

             this._db.Book.Remove(bookFromDb);
            await this._db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
