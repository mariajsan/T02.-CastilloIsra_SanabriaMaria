using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Web.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Display(Name ="Descripción")]
        [MaxLength(100)]
        public string Description { get; set; }

        public string ApplicationUser_Id { get; set; }
        [ForeignKey("ApplicationUser_Id")]
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Article> Articles { get; set; }      
    }
}