using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidli.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidli.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Enter Movie Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Enter Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Enter Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Enter Number In Stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Select Genre from List")]
        public byte GenreId { get; set; }
    }
}