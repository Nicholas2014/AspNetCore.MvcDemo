using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.MvcDemo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string Starring { get; set; }
    }
}
