using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.NET.Models;

namespace vidly.NET.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}