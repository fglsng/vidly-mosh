using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; } = new DateTime(1980, 1, 1);

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Range(1, 20)]
        public int Stock { get; set; }

        [Required]
        public byte GenreTypeId { get; set; }
    }
}