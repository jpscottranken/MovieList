using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MovieList.Models
{
    public class Movie
    {
        //  Entity Framework will instruct the database
        //  to automatically generated this value (non-seed data).
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter movie name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter year movie released")]
        [Range(1889, 2999, ErrorMessage = "Year must be between 1889 and 2999")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a movie rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int? Rating { get; set; }

        [Required(ErrorMessage = "Please enter a movie genre")]
        public string GenreId { get; set; }

        [ValidateNever]
        public Genre Genre { get; set; } = null;

        public string Slug =>
                Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString() ?? string.Empty;
    }
}
