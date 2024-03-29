﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amaterasu.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage ="Number in stock must be between 1 - 100")]
        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }

    }
}