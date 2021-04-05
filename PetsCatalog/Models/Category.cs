using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsCatalog.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category: ")]
        public string Name { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }

    }
}
