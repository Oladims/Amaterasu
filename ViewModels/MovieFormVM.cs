using Amaterasu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Amaterasu.ViewModels
{
    public class MovieFormVM
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Number in stock must be between 1 - 100")]
        public int? NumberInStock { get; set; }

        [Required]
        public byte? GenreId { get; set; }

        public MovieFormVM()
        {
            Id = 0;
        }

        public MovieFormVM(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

    }
}

