using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public ApplicationUser ApplicationUser { get; set; }
    }
}