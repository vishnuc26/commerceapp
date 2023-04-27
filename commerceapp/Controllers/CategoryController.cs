
using commerce.Models;
using Commerce.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Commerce.DataAccess.Repository.IRepository;
using Commerce.DataAccess.Repository;

namespace commerceapp.Controllers
{
    public class CategoryController : Controller
    {

        private readonly CategoryRepository _categoryRepo;
        public CategoryController(CategoryRepository db)
        {
            _categoryRepo = db;
        }

        public IActionResult Index()
        {
            List<Category> objlist = _categoryRepo.GetAll().ToList();   
            return View(objlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid) {

                _categoryRepo.Add(obj);
                _categoryRepo.save();
                TempData["success"] = "created successfully";
                return RedirectToAction("Index");   
                
            }

            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            Category categoryFromDb = _categoryRepo.Get(u=>u.Id==id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            
            
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {

                _categoryRepo.Update(obj);
                _categoryRepo.save();
                TempData["success"] = "edited successfully";
                return RedirectToAction("Index");

            }

            return View();

        }



        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category?  categoryFromDb = _categoryRepo.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }


            return View(categoryFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category obj = _categoryRepo.Get(u => u.Id == id);
            if (obj == null)
            {

                return NotFound();
            }

            _categoryRepo.Remove(obj);
            _categoryRepo.save();
            TempData["success"] = "deleted successfully";
            return RedirectToAction("Index");

            

            

        }
    }
}
