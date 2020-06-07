using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Web.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(100)]
        [Required]
        public string Description { get; set; }

        [MaxLength(3000)]
        public string Content { get; set; }
        [Required]
        public DateTime Posted { get; set; }

        [Display(Name = "Encabezado")]
        [Required]
        public string ImgUrl{ get; set; }

        [Required]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public ICollection<Comentary> Comentaries { get; set; }
    }
}