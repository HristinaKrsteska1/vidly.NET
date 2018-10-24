﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.NET.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public byte NumberInStock { get; set; }
        
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }

    }
}