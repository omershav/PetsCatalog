using PetsCatalog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsCatalog.ViewModels
{
    public class AnimalCategoriesViewModel
    {
        public IEnumerable<Animal> Animals { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Category Category { get; set; }
    }
}
