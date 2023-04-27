using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Razarpagescrud.Data;
using Razarpagescrud.Models;

namespace Razarpagescrud.Pages.categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;

        
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet(int? id)
        {
            

            if(id!=0 && id!=null)
            {
                Category = _db.categories.Find(id);
            }

            


            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Updated successfully";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
