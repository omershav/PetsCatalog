using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PetsCatalog.Data;
using PetsCatalog.Models;
using PetsCatalog.ViewModels;
using System.IO;
using System.Linq;

namespace PetsCatalog.Controllers
{
    public class AdminController : Controller
    {
        private PetContext _context;
        private IWebHostEnvironment _hostEnvironment;

        public AdminController(PetContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index(bool isSucceed = false, bool isDeleted = false)
        {
            AnimalCategoriesViewModel animalCategoriesViewModel = new AnimalCategoriesViewModel()
            {
                Categories = _context.Categories.ToList(),
                Animals = _context.Animals.ToList()
            };

            ViewBag.isSucceed = isSucceed; //For alerting the user if the update/add operation succeeded
            ViewBag.isDeleted = isDeleted; //For alerting the user if the delete operation succeeded

            return View(animalCategoriesViewModel);
        }

        public IActionResult CatalogByCategoryAdmin(Category category)
        {
            var animalSorted = _context.Animals.Where(a => a.CategoryId == category.CategoryId); //Saving all the animals by the input category

            AnimalCategoriesViewModel animalCategoriesViewModel = new AnimalCategoriesViewModel()
            {
                Categories = _context.Categories.ToList(),
                Animals = animalSorted.ToList()
            };

            return View("Index", animalCategoriesViewModel);
        }

        public IActionResult DeleteAnimal(int animalId)
        {
            var animal = _context.Animals.SingleOrDefault(a => a.AnimalId == animalId); //Finding the required animal to be deleted by its animalId
            _context.Animals.Remove(animal);
            _context.SaveChanges();

            return RedirectToAction("Index", new { isDeleted = true });
        }

        public IActionResult NewAnimal()
        {
            ViewBag.Categories = _context.Categories.ToList(); //Passing all the categories by ViewBag

            return View();
        }

        public IActionResult CreateAnimal(Animal animal)
        {
            ModelState.Remove("PictureName"); //For not checking the PictureName required property, instead check the required ImageAnimal property

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileName(animal.AnimalImage.FileName);
                string path = Path.Combine(wwwRootPath + "/pics/" + fileName);

                using (var fileStram = new FileStream(path, FileMode.Create))
                {
                    animal.AnimalImage.CopyTo(fileStram);
                }

                _context.Animals.Add(new Animal { Name = animal.Name, CategoryId = animal.CategoryId, Description = animal.Description, Age = animal.Age, PictureName = fileName });
                _context.SaveChanges();

                return RedirectToAction("Index", new { isSucceed = true });
            }

            return RedirectToAction("NewAnimal");
        }

        public IActionResult EditAnimal(int animalId)
        {
            ViewBag.Categories = _context.Categories.ToList(); //Passing all the categories by ViewBag

            return View(_context.Animals.SingleOrDefault(a => a.AnimalId == animalId));
        }

        public IActionResult UpdateAnimal(Animal animal, int animalId)
        {
            ModelState.Remove("PictureName"); //For not checking the PictureName required property of animal model
            ModelState.Remove("AnimalImage"); //For not checking the AnimalImage required property of animal model

            if (ModelState.IsValid)
            {
                var updatedAnimal = _context.Animals.SingleOrDefault(a => a.AnimalId == animalId);

                updatedAnimal.Name = animal.Name;
                updatedAnimal.Age = animal.Age;
                updatedAnimal.CategoryId = animal.CategoryId;
                updatedAnimal.Description = animal.Description;

                _context.Update(updatedAnimal);
                _context.SaveChanges();

                return RedirectToAction("Index", new { isSucceed = true });
            }

            return RedirectToAction("EditAnimal");
        }
    }
}
