using System;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Api.BindingModels
{
    public class AddBook
    {
        [Required]
        // [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required]
        // [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        
        [Required]
        // [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        
        [Required]
        // [DataType(DataType.ImageUrl)]
        [Display(Name = "ImageHref")]
        public string? ImageHref { get; set; }
        
        [Required]
        [Display(Name = "PublisherId")]
        public int PublisherId { get; set; }
        
    }
}