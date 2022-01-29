using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eiga.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string MovieName { get; set; }
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Range(1, 50)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}