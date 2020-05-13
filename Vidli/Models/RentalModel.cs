using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidli.Models
{
    public class RentalModel
    {
        public int Id { get; set; }
        
        [Required]
        public CustomerModel Customer { get; set; }

        // public int CustomerId { get; set; }

        [Required]
        public MovieModel Movie { get; set; }

        // public int MovieId { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}