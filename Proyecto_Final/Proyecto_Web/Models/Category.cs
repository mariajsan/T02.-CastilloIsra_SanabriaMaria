using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_Web.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(15)]
        [Required]
        public string Name { get; set; }
    }
}