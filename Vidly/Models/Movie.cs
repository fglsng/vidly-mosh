using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Display(Name = "Number in Stock")]
        public int Stock { get; set; }

        public GenreType GenreType { get; set; }

        [Display(Name = "Genre")]
        public byte GenreTypeId { get; set; }
    }

   
}