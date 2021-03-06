﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidli.Models;

namespace Vidli.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime? DateAdded { get; set; }

        [Required]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }


    }
}