using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbdoZDiningHeaven.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required, StringLength(80, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        [Required, StringLength(255, ErrorMessage = "Location is too long.")]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
