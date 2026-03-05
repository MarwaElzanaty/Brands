using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocalBrands.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAll();
            return View("Index", categories);
        }

        public IActionResult Details(int id, string? brandName)
        {
            var category = _categoryRepo.GetById(id);
            if (category == null) return NotFound();

            if (!string.IsNullOrEmpty(brandName))
            {
                category.Products = category.Products.Where(p => p.Brand != null && p.Brand.Name.ToLower().Contains(brandName.ToLower())).ToList();
            }
            return View("Details", category);
        }
   
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                return RedirectToAction("Index");
            }
            return View("Create", category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _categoryRepo.GetById(id);
            if (category == null) return NotFound();

            return View("Delete", category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoryRepo.DeleteById(id);
            _categoryRepo.Save();
            return RedirectToAction("Index");
        }
    }
}