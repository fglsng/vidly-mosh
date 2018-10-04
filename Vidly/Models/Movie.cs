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

        [Required]
        public string Name { get; set; }

        
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; } = new DateTime(1980, 1, 1);

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int Stock { get; set; }

        public GenreType GenreType { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreTypeId { get; set; }
    }

   
}