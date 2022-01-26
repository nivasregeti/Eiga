using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Eiga.Models;

namespace Eiga.ViewModels
{
    public class MovieFormviewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string MovieName { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 50)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return MovieId != 0 ? "Edit Movie":"New Movie";
            }
        }

        public MovieFormviewModel()
        {
            MovieId = 0;
        }

        public MovieFormviewModel(Movie movie)
        {
            MovieId = movie.MovieId;
            MovieName = movie.MovieName;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}