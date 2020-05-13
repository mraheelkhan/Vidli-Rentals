using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidli.Models;
namespace Vidli.ViewModels
{
    public class MovieFormViewModel
    {
        //public MovieModel Movie { get; set; }
        public IEnumerable<Genre> Genre { get; set; }

        public int? Id { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public int? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Select Genre from List")]
        public byte? GenreId { get; set; }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
                // if (Id != null && Id != 0)
                //     return "Edit Movie";
                // return "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(MovieModel movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
            DateAdded = movie.DateAdded;
            ReleaseDate = movie.ReleaseDate;
        }
    }
}