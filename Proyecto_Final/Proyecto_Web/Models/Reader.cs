
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto_Web.Models
{
    public class Reader
    {
        public int Id { get; set; }

        public string ReaderId { get; set; }
        [ForeignKey("ReaderId")]
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Favorite> Favorites { get; set; }
    }
}