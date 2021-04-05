using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetsCatalog.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Please fill the animal name")]
        [Display(Name = "Animal name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill the animal age")]
        [Range(0, 100)]
        [Display(Name = "Animal age")]
        public int Age { get; set; }
        [Required]
        public string PictureName { get; set; }
        [Required(ErrorMessage = "Please fill the description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        [NotMapped]
        [Display(Name = "Picture name")]
        [Required(ErrorMessage = "Please select the picture")]
        public IFormFile AnimalImage { get; set; }
    }
}
