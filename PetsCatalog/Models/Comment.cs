using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsCatalog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter a comment")]
        [Display(Name = "Your comment: ")]
        public string CommentData { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
