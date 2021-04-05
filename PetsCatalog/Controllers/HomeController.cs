using Microsoft.AspNetCore.Mvc;
using PetsCatalog.Data;
using System.Linq;

namespace PetsCatalog.Controllers
{
    public class HomeController : Controller
    {
        private PetContext _context;

        public HomeController(PetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var groupedResult = _context.Animals.OrderByDescending(a => a.Comments.Count).Take(2).ToList(); //Saving the most highly commented animals (top 2)

            return View(groupedResult);
        }
    }
}
