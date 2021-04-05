using Microsoft.AspNetCore.Mvc;
using PetsCatalog.Data;
using PetsCatalog.Models;
using PetsCatalog.ViewModels;
using System.Linq;

namespace PetsCatalog.Controllers
{
    public class CatalogController : Controller
    {
        private PetContext _context;

        public CatalogController(PetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            AnimalCategoriesViewModel animalCategoriesViewModel = new AnimalCategoriesViewModel()
            {
                Categories = _context.Categories.ToList(),
                Animals = _context.Animals.ToList()
            };

            return View(animalCategoriesViewModel);
        }

        public IActionResult CatalogByCategory(Category category)
        {
            var animalSorted = _context.Animals.Where(a => a.CategoryId == category.CategoryId); //Saving all the animals by the input category

            AnimalCategoriesViewModel animalCategoriesViewModel = new AnimalCategoriesViewModel()
            {
                Categories = _context.Categories.ToList(),
                Animals = animalSorted.ToList()
            };

            return View("Index", animalCategoriesViewModel);
        }

        public IActionResult AnimalDetails(int animalId, bool isSucceed = false)
        {
            var animalSorted = _context.Animals.SingleOrDefault(a => a.AnimalId == animalId); //Saving the required animal to get details of
            var commentsSorted = _context.Comments.Where(c => c.AnimalId == animalId); //Saving all the comments of the required animal

            ViewBag.isSucceed = isSucceed; //For alerting the user if the add comment operation succeeded

            AnimalDetailsViewModel animalDetailsViewModel = new AnimalDetailsViewModel()
            {
                Animal = animalSorted,
                Comments = commentsSorted
            };

            return View(animalDetailsViewModel);
        }

        public IActionResult AddComment(Comment comment, int animalId)
        {
            if (ModelState.IsValid)
            {
                _context.Comments.Add(new Comment { CommentData = comment.CommentData, AnimalId = animalId });
                _context.SaveChanges();
                return RedirectToAction("AnimalDetails", new { animalId = animalId, isSucceed = true });
            }

            return RedirectToAction("AnimalDetails", new { animalId = animalId });
        }
    }
}
