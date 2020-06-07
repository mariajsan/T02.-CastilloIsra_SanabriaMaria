using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Web.Models
{
    public class Comentary
    {
        public int Id { get; set; }

        [Display(Name = "Contenido")]
        [MaxLength(300)]
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }
    }
}