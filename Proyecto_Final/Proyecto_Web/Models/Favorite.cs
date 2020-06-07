using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Web.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        [Required]
        public int ReaderId { get; set; }
        [ForeignKey("ReaderId")]
        public Reader Reader { get; set; }

        [Required]
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }
    }
}